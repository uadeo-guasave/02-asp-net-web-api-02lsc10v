using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _02_asp_net_web_api_02lsc10v.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace _02_asp_net_web_api_02lsc10v
{
  public class Program
  {
    public static void Main(string[] args)
    {
      // CrearBaseDeDatos();
      CreateHostBuilder(args).Build().Run();
    }

    private static void CrearBaseDeDatos()
    {
      using (var db = new AmazonDbContext())
      {
        try
        {
          db.Database.EnsureCreated();
          var libros = db.Books.Include(b => b.Category).ToList().Take(10);
          foreach (var libro in libros)
          {
            System.Console.WriteLine($"Libro: {libro.Title}, Categoría: {libro.Category.Name}");
          }
        }
        catch (Exception ex)
        {
          System.Console.WriteLine(ex.Message);
        }
      }
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
              webBuilder.UseStartup<Startup>();
            });
  }
}
