using Pre_maritalCounSeling.APIService.GraphQLs;
using Pre_maritalCounSeling.BAL.ServiceQuiz;
using Pre_maritalCounSeling.DAL.Entities;
using Pre_maritalCounSeling.DAL.Repositories;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IQuizResultService, QuizResultService>();

builder.Services.AddHttpClient<QuizResultMutation>(client =>
{
    client.BaseAddress = new Uri("http://localhost:8080/");
});
builder.Services.AddScoped<QuizResultMutation>();
#region Config Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod()
                   .WithExposedHeaders("Authorization");
        });
});
#endregion


#region GRAPQL region add all query and mutation service

builder.Services.AddGraphQLServer().AddQueryType<QuizResultQuery>().AddMutationType<QuizResultMutation>().BindRuntimeType<DateTime, DateTimeType>();

#endregion




builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.Never;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors("AllowOrigin");
app.UseRouting().UseEndpoints(endpoints => { endpoints.MapGraphQL(); });
app.Run();
