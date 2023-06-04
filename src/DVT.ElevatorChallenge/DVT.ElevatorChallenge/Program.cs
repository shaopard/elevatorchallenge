// See https://aka.ms/new-console-template for more information

using DVT.ElevatorChallenge.Application;
using DVT.ElevatorChallenge.Services.Abstract;
using DVT.ElevatorChallenge.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
    .AddSingleton<IConfigurationReader, ConfigurationReader>()
    .BuildServiceProvider();

var myApp = ActivatorUtilities.CreateInstance<MyApp>(serviceProvider);
myApp.Run();