using EasyData.Export;
using EqDemo;
using Korzh.EasyQuery.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);
Korzh.EasyQuery.AspNetCore.License.Key = "RHk1jkYkxGvFISrdi1i30xLjRMQUedteiYIYSuJ8cJADCUZFGYZ5KEW";
Korzh.EasyQuery.AspNetCore.JSLicense.Key = "LsfCXckwGAS_VmWlhlH2ROnIzRK1Y0AQSN7F6KSH2YEBNJ4FG95VKEW";

builder.Services.AddDbContext<AppDbContext>(
			//	options => options.UseSqlite(DbConnectionString)
			options => options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=northwind")
			);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddMvc().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
builder.Services.AddKendo();
builder.Services.AddEasyQuery()
		.UseSqlManager()
		.AddDefaultExporters()
		.AddDataExporter<PdfDataExporter>("pdf")
		.AddDataExporter<ExcelDataExporter>("excel")
		.UseSessionCache()
		.RegisterDbGate<Korzh.EasyQuery.DbGates.SqlServerGate>();

var app = builder.Build();
var DbConnectionString = app.Configuration.GetConnectionString("EqDemoDb");

app.UseEasyQuery(
	 options =>
	 {
		 // options.SaveNewQuery = false;
		 // options.ConnectionString = DbConnectionString;
		 options.UseDbContext<AppDbContext>();
		 // options.StoreModelInCache = false;
		 // options.StoreQueryInCache = false;
		 options.UseQueryStore((_) => new FileQueryStore("App_Data"));
	 }

);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();