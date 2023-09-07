using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ToDo.SPAv2;
using ToDo.SPAv2.ViewModels.TodoViewModels;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddTransient<ToDoViewModel>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7012/") });

await builder.Build().RunAsync();
