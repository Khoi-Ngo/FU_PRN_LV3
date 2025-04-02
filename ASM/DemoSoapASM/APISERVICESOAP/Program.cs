using APISERVICESOAP.SoapService;
using BuService;
using SoapCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddSoapCore();
builder.Services.AddScoped<IQuizResultService, QuizResultService>();
builder.Services.AddScoped<IQuizResultSoapService, QuizResultSoapService>();




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseSoapEndpoint<IQuizResultSoapService>("/PremaritalCounselingSoapService.asmx", new SoapEncoderOptions());


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
