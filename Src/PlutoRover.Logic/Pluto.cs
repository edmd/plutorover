using System;

namespace PlutoRover.Logic
{
    public class Pluto : IPlanet
    {
        private const int _obstacleFrequency = 4;
        private int _maxDimension = 100;
        private int[,] _surface;

        public int[,] SurfaceArea { get => _surface; set => _surface = value; }

        public Pluto(int? maxDimension)
        {
            if(maxDimension.HasValue && maxDimension > 0)
            {
                _maxDimension = maxDimension.Value;
            }

            SurfaceArea = new int[_maxDimension, _maxDimension];
            ScanSurfaceArea();
        }

        private void ScanSurfaceArea()
        {
            for(var lat = 0; lat < _maxDimension; lat++)
            {
                for (var lon = 0; lon < _maxDimension; lon++)
                {
                    Random rnd = new Random();
                    var terrain = rnd.Next(_obstacleFrequency);

                    if((int)Terrain.ImpassableTerrain == terrain % (_obstacleFrequency - 1))
                    {
                        SurfaceArea[lat, lon] = (int)Terrain.ImpassableTerrain;
                    }
                }
            }

            // Overwrite the rover landing coordinate with a flat surface
            SurfaceArea[0, 0] = (int)Terrain.PassableTerrain;
        }
    }
}