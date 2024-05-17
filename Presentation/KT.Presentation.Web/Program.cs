using KT.Presentation.ClientsGenerated;
using KT.Presentation.Web.Components;
using KT.Presentation.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// add services
builder.Services.AddScoped<IClient, Client>(_ => new Client("http://localhost:5130", new HttpClient()));

builder.Services.AddScoped<ILearnerService, LearnerService>();
builder.Services.AddScoped<ICourseTemplateService, CourseTemplateService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();