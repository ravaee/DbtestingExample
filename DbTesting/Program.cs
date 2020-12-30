using DbTesting.Context;
using DbTesting.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DbTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var serviceProvider = new ServiceCollection()
            .AddLogging()
            .AddSingleton<Item>()
            .AddTransient<ApplicationDbContext>()
            .BuildServiceProvider();

        }


    }


}
