using System;
using Microsoft.Extensions.Configuration;

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

            Console.WriteLine("Hello World!");
        }
    }
}
