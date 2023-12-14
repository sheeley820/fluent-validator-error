using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using FluentValidation;
using WorkingWithRadzenStudi.Client.Shared;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();
builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddValidatorsFromAssemblyContaining<TestValidator>();

ValidatorOptions.Global.LanguageManager = new ValidationLanguageManager();

var host = builder.Build();
await host.RunAsync();