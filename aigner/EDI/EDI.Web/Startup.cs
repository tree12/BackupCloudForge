using EDI.DataAccess;
using EDI.Web.Filters;
using EDI.Web.Models;
using EDI.Web.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
//using Microsoft.OpenApi.Models;
using Portal.Common.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using EDI.DataAccess.Entities.Codes;
using EDI.Web.BackgroundService;
using EdiFabric;
using log4net;
using log4net.Appender;
using log4net.Repository.Hierarchy;
using Microsoft.Extensions.Logging;
using ILoggerFactory = Microsoft.Extensions.Logging.ILoggerFactory;

namespace EDI.Web
{
	public class Startup
	{
		public IConfiguration Configuration { get; }
		public IWebHostEnvironment Env { get; }

		public Startup(IConfiguration configuration, IWebHostEnvironment env)
		{
			Configuration = configuration;
			Env = env;
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddHttpContextAccessor();
			services.AddCors();
			services.AddControllers();
			//services.AddSwaggerGen(c =>
			//{
			//	c.SwaggerDoc("v1", new OpenApiInfo { Title = "EDI.Web", Version = "v1" });
			//});
			// Register the Swagger services
			services.AddSwaggerDocument();
			// configure basic authentication 
			services
				.AddAuthentication("BasicAuthentication")
				.AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

			var connectionString = Configuration.GetConnectionString("DBConnectionString") ?? string.Empty;
			services.AddDbContext<ApplicationDbContext>(options =>
			{
				if (Env.IsDevelopment())
				{
					options.EnableSensitiveDataLogging();
				}
				else
				{
					options.EnableSensitiveDataLogging(false);
				}

				options.UseSqlServer(connectionString, builder =>
				{
					builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.GetName().Name);
				});
			});

			//services.AddScoped<DbContextBase>(provider => provider.GetService<ApplicationDbContext>());  //register same service

			// configure DI for application services
			services.AddScoped<IUserService, UserService>();
            services.Configure<List<UserInfo>>(Configuration.GetSection("UserInfo"));
			services.Configure<EdiConfig>(option => Configuration.GetSection("EdiConfig").Bind(option));
			services.AddHostedService<AdjustEdiStatus>();
			AppDomain.CurrentDomain.GetAssemblies().ForEach(a => services.AutoRegisterServicesAsScoped(a));
            SerialKey.Set(Configuration.GetSection("EdiConfig:EdiSecretKey").Value);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext dbContext)
		{
			//if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseOpenApi();
				app.UseSwaggerUi3();
				//app.UseSwagger();
				//app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EDI.Web v1"));
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			// global cors policy
			if (env.IsDevelopment())
			{
				// Todo: Check Cors policies
				app.UseCors(x => x
					.AllowAnyOrigin()
					.AllowAnyMethod()
					.AllowAnyHeader());
			}
			else
			{
				// Todo: Check Cors policies
				app.UseCors();
			}

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

			dbContext.Database.Migrate();
			BaseCodeEntity<CodeAllowanceOrChargeCodeQualifier>.IterateAllCodes<CodeAllowanceOrChargeCodeQualifier>(dbContext);
			BaseCodeEntity<CodeDateTimePeriodFormatCode>.IterateAllCodes<CodeDateTimePeriodFormatCode>(dbContext);
			BaseCodeEntity<CodeDateTimePeriodFunctionCodeQualifier>.IterateAllCodes<CodeDateTimePeriodFunctionCodeQualifier>(dbContext);
			BaseCodeEntity<CodeDescriptionFormatCode>.IterateAllCodes<CodeDescriptionFormatCode>(dbContext);
			BaseCodeEntity<CodeDutyTaxFeeCategoryCode>.IterateAllCodes<CodeDutyTaxFeeCategoryCode>(dbContext);
			BaseCodeEntity<CodeDutyTaxFeeFunctionCodeQualifier>.IterateAllCodes<CodeDutyTaxFeeFunctionCodeQualifier>(dbContext);
			BaseCodeEntity<CodeDutyTaxFeeTypeNameCode>.IterateAllCodes<CodeDutyTaxFeeTypeNameCode>(dbContext);
			BaseCodeEntity<CodeItemTypeIdentificationCode>.IterateAllCodes<CodeItemTypeIdentificationCode>(dbContext);
			BaseCodeEntity<CodeLocationFunctionCodeQualifier>.IterateAllCodes<CodeLocationFunctionCodeQualifier>(dbContext);
			BaseCodeEntity<CodeMonetaryAmountTypeCodeQualifier>.IterateAllCodes<CodeMonetaryAmountTypeCodeQualifier>(dbContext);
			BaseCodeEntity<CodePaymentTermsDescriptionIdentifier>.IterateAllCodes<CodePaymentTermsDescriptionIdentifier>(dbContext);
			BaseCodeEntity<CodePaymentTermsTypeCodeQualifier>.IterateAllCodes<CodePaymentTermsTypeCodeQualifier>(dbContext);
			BaseCodeEntity<CodePercentageTypeCodeQualifier>.IterateAllCodes<CodePercentageTypeCodeQualifier>(dbContext);
			BaseCodeEntity<CodePriceCodeQualifier>.IterateAllCodes<CodePriceCodeQualifier>(dbContext);
			BaseCodeEntity<CodeQuantityTypeCodeQualifier>.IterateAllCodes<CodeQuantityTypeCodeQualifier>(dbContext);
			BaseCodeEntity<CodeReferenceCodeQualifier>.IterateAllCodes<CodeReferenceCodeQualifier>(dbContext);
			BaseCodeEntity<CodeSpecialServicedescriptionCode>.IterateAllCodes<CodeSpecialServicedescriptionCode>(dbContext);
			BaseCodeEntity<CodeTermsOfDeliveryOrTransportFunctionCode>.IterateAllCodes<CodeTermsOfDeliveryOrTransportFunctionCode>(dbContext);
			BaseCodeEntity<CodeTextSubjectCodeQualifier>.IterateAllCodes<CodeTextSubjectCodeQualifier>(dbContext);
			BaseCodeEntity<CodeTimeReferenceCode>.IterateAllCodes<CodeTimeReferenceCode>(dbContext);
			BaseCodeEntity<CodeTimeRelationCode>.IterateAllCodes<CodeTimeRelationCode>(dbContext);
			BaseCodeEntity<CodeTypePeriodCode>.IterateAllCodes<CodeTypePeriodCode>(dbContext);
            BaseCodeEntity<CodeIncotermCode>.IterateAllCodes<CodeIncotermCode>(dbContext);

            BaseCodeEntity<CodeMessageFunction>.IterateAllCodes<CodeMessageFunction>(dbContext);
            BaseCodeEntity<CodeDocumentName>.IterateAllCodes<CodeDocumentName>(dbContext);
            BaseCodeEntity<CodeItemCaracteristic>.IterateAllCodes<CodeItemCaracteristic>(dbContext);
            BaseCodeEntity<CodeItemDescriptionType>.IterateAllCodes<CodeItemDescriptionType>(dbContext); 
            BaseCodeEntity<CodeContactFunctionCode>.IterateAllCodes<CodeContactFunctionCode>(dbContext);

            BaseCodeEntity<CodeActionRequest>.IterateAllCodes<CodeActionRequest>(dbContext);
            BaseCodeEntity<CodeDeliveryPlanStatusIndicator>.IterateAllCodes<CodeDeliveryPlanStatusIndicator>(dbContext);
            BaseCodeEntity<CodeListQualifierCode>.IterateAllCodes<CodeListQualifierCode>(dbContext);
            BaseCodeEntity<CodeListResponsibleAgencyCode>.IterateAllCodes<CodeListResponsibleAgencyCode>(dbContext);
            BaseCodeEntity<CodePartyQualifier>.IterateAllCodes<CodePartyQualifier>(dbContext);
            BaseCodeEntity<CodeTextFunctionCode>.IterateAllCodes<CodeTextFunctionCode>(dbContext);
            BaseCodeEntity<CodeFreeTextCode>.IterateAllCodes<CodeFreeTextCode>(dbContext);
			BaseCodeEntity<CodeProductIdFunctionQualifier>.IterateAllCodes<CodeProductIdFunctionQualifier>(dbContext);

            BaseCodeEntity<CodeTermsOfPaymentIdentification>.IterateAllCodes<CodeTermsOfPaymentIdentification>(dbContext);
			

		}
	}
}
