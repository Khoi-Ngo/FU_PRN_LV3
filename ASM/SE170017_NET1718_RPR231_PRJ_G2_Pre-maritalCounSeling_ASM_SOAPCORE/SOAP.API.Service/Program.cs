using Microsoft.Extensions.DependencyInjection.Extensions;
using SoapServiceLayer;
using SoapCore;
using Pre_maritalCounSeling.BAL;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSoapCore();
//builder.Services.TryAddSingleton<QuizResultServiceContract,QuizResultServieContractImp>();
builder.Services.AddScoped<QuizResultServiceContract, QuizResultServieContractImp>();
builder.Services.AddHttpContextAccessor();
builder.Services.ConfigureAppServices();
builder.Services.AddControllers().AddJsonOptions(
    options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.Never;
    }
    );
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




var app = builder.Build();
app.UseRouting();
app.UseEndpoints(endpoints => {
    endpoints.UseSoapEndpoint<QuizResultServieContractImp>(
        path: "/QuizResultService.asmx",
        encoder: new SoapEncoderOptions(),
        serializer: SoapSerializer.DataContractSerializer,
        caseInsensitivePath: true);
});
app.UseCors("AllowOrigin");
app.Run();