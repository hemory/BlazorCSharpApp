using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ChuckNorrisJokesApp;
using ChuckNorrisJokesApp.Data;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddScoped<JokeService>();
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
