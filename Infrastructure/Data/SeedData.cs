using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Core.Entities;

namespace Infrastructure.Data
{
    public class SeedData
    {
        public static async Task SeedAsync(MovieContext context)
        {
            try
            {
                if (!context.Movies.Any())
                {
                    var movieData = File.ReadAllText("../Infrastructure/Data/SeedData/movies.json");
                    var movieJSON = JsonSerializer.Deserialize<List<Movies>>(movieData);

                    foreach (var movie in movieJSON)
                    {
                        context.Add(movie);
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
