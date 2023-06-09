
using Microsoft.EntityFrameworkCore;
using BrainerHubDemo.Helper;
using BrainerHubDemoModel.POcSampleDB;
using BrainerHubDemoModel.SpDbContext;
using BrainerHubDemoService.BrainerHubDemoRepository.Implementation;
using BrainerHubDemoService.BrainerHubDemoRepository.Interface;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.PlatformAbstractions;
using FluentValidation.AspNetCore;
using BrainerHubDemoModel.RequestModel;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using System.Reflection;
using MicroElements.Swashbuckle.FluentValidation;

namespace BrainerHubDemo
{
    /// <summary>
    /// Program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()
                   .AddNewtonsoftJson(options =>
                       options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                       );
            var _configuration = builder.Configuration;
            
            #region Set DB Connection
            string? connectionstring = _configuration.GetConnectionString("DefaultConnection");


            builder.Services.AddDbContext<POCSampleContext>((serviceProvider, options) =>
            {

                options.UseSqlServer(connectionstring,
                                               sqlServerOptionsAction: sqlOptions =>
                                               {
                                                   sqlOptions.EnableRetryOnFailure();
                                               });
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                options.EnableSensitiveDataLogging(true);
            });
            builder.Services.AddDbContext<POCSpContext>((serviceProvider, options) =>
            {

                options.UseSqlServer(connectionstring,
                                               sqlServerOptionsAction: sqlOptions =>
                                               {
                                                   sqlOptions.EnableRetryOnFailure();
                                               });
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                options.EnableSensitiveDataLogging(true);
            });
            builder.Services.AddDbContext<POCSpDbContext>((serviceProvider, options) =>
            {

                options.UseSqlServer(connectionstring,
                                               sqlServerOptionsAction: sqlOptions =>
                                               {
                                                   sqlOptions.EnableRetryOnFailure();
                                               });
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                options.EnableSensitiveDataLogging(true);
            });
            #endregion

            #region DependencyInjection
            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<IJobsRepository, JobsRepository>();
            builder.Services.AddScoped<ITaskRepository, TaskRepository>();
            #endregion

            #region Add FluentValidation
            builder.Services
        .AddMvc()
        // Adds fluent validators to Asp.net
        .AddFluentValidation(c =>
        {
            c.RegisterValidatorsFromAssemblyContaining<StudentRequestModel>();
            // Optionally set validator factory if you have problems with scope resolve inside validators.
            c.ValidatorFactoryType = typeof(HttpContextServiceProviderValidatorFactory);
        });

            builder.Services.AddTransient<IValidatorInterceptor, FluentInterceptor>();
            builder.Services.AddFluentValidationRulesToSwagger();

            #endregion

            #region Add Swagger
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "POCSample.xml");
                c.IncludeXmlComments(xmlPath);

                xmlPath = Path.Combine(basePath, "POCSampleModel.xml");
                c.IncludeXmlComments(xmlPath);

            });
            builder.Services.AddSwaggerGenNewtonsoftSupport();
            #endregion

            builder.Services.AddLocalization(opt => { opt.ResourcesPath = "Resources"; });
            builder.Services.AddControllersWithViews().AddDataAnnotationsLocalization();

            var app = builder.Build();

            app.UseHttpStatusCodeExceptionMiddleware();

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            app.UseSwagger();
            app.UseSwaggerUI();
            //}

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}