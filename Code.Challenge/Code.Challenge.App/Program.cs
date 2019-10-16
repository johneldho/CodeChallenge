using System;
using System.Collections.Generic;
using System.IO;
using AutoMapper;
using Code.Challenge.DataLayer.DTO;
using Code.Challenge.DataLayer.Mapper;
using Code.Challenge.LogicLayer;
using Code.Challenge.LogicLayer.FileProcessor;
using Code.Challenge.LogicLayer.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Code.Challenge.App
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                var config = new ConfigurationBuilder()
                    .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .Build();

                var servicesProvider = BuildDi(config);

                using (servicesProvider as IDisposable)
                {
                    var horseService = servicesProvider.GetService<IHorseDetails>();
                    var horseData = horseService.GetHorseDetails().Result;

                    foreach (var horse in horseData)
                    {
                        Console.WriteLine("HorseName : " + horse.HorseName + " Price :" + horse.Price);
                    }

                    Console.WriteLine("Press ANY key to exit");
                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {
               Console.WriteLine("Error Occurred while processing the request");
               //Log error to file
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
            RegisterFileProcessor(serviceCollection);
            return serviceCollection.BuildServiceProvider();
        }
        private static void RegisterFileProcessor(IServiceCollection services)
        {
            services.AddTransient<CaulfieldRaceFileProcessor>();
            services.AddTransient<WolferhamptonRaceFileProcessor>();

            services.AddTransient<Func<RaceName, IRaceFileProcessor>>(fileProcessor => key =>
            {
                switch (key)
                {
                    case RaceName.Caulfield_Race1:
                        return fileProcessor.GetService<CaulfieldRaceFileProcessor>();
                    case RaceName.Wolferhampton_Race1
                        :
                        return fileProcessor.GetService<WolferhamptonRaceFileProcessor>();
                    default:
                        throw new KeyNotFoundException();
                }
            });
        }
    }
}
