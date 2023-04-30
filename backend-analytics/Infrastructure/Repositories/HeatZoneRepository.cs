﻿using Abstractions.Models;
using Abstractions.IRepositories;

namespace Infrastructure.Repositories
{
    public class HeatZoneRepository : IHeatZoneRepository
    {
        private static double Xmin = 132.617758;
        private static double Xmax = 132.922474;

        private static double Ymin = 35.281593;
        private static double Ymax = 35.514545;

        private static double size = 0.005765;

        private int[] heat = { 0, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };

        private IEnumerable<HeatZone> Generate()
        {
            var lst = new List<HeatZone>();
            
            Random rnd = new Random();


            for (var x = Xmin; x < Xmax; x+= size)
            {
                for (var y = Ymin; y < Ymax; y += size)
                {
                    lst.Add(new HeatZone
                    {
                        Temperature = heat[rnd.Next(0, heat.Length-1)],
                        ZoneCoordinates = new()
                        {
                            new ZoneCoordinates { X = x, Y =  y},
                            new ZoneCoordinates { X = x, Y =  y + size},
                            new ZoneCoordinates { X = x + size, Y =  y + size},
                            new ZoneCoordinates { X = x + size, Y =  y },
                        }
                    });
                }
            }

            return lst;
        }

        public async Task<IEnumerable<HeatZone>> GetAsync(IEnumerable<string> sourceCode)
        {
            if(sourceCode == null || !sourceCode.Any())
            {
                return Enumerable.Empty<HeatZone>();
            }

                return Generate();

            return new List<HeatZone>
            {
                new HeatZone
                {
                    Temperature = 80,
                    ZoneCoordinates = new List<ZoneCoordinates>
                    {
                        new ZoneCoordinates { X = 132.883406, Y = 35.415208},
                        new ZoneCoordinates { X = 132.883406, Y = 35.410543},
                        new ZoneCoordinates { X = 132.889171, Y = 35.410543},
                        new ZoneCoordinates { X = 132.889171, Y = 35.415208},
                    }
                },
            };
        }
    }
}
