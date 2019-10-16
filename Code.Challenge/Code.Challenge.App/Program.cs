using System;
using AutoMapper;
using Code.Challenge.DataLayer.Mapper;
using Code.Challenge.LogicLayer;
using Code.Challenge.LogicLayer.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Code.Challenge.App
{
    class Program
    {
        static void Main(string[] args)
        {


            var config = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            var servicesProvider = BuildDi(config);

            using (servicesProvider as IDisposable)
            {

                Console.WriteLine("Press ANY key to exit");
                Console.ReadKey();
            }
           
             
        }

        private static IServiceProvider BuildDi(IConfiguration config)
        {
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new RaceDataMapper());  
            });

            var mapper = mappingConfig.CreateMapper();

            var serviceCollection = new ServiceCollection();
            
            serviceCollection.AddTransient<IHorseManagerLL, HorseManagerLL>();
            serviceCollection.AddSingleton(mapper); 

            return serviceCollection.BuildServiceProvider();
        }
    }
}
