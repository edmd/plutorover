using System;

namespace PlutoRover.Logic
{
    public class Rover : IRover
    {
        private IPlanet _planet;
        private Coordinate _coordinate;

        public Coordinate Coordinate { get => _coordinate; set => _coordinate = value; }

        // Deploy rover
        public Rover(IPlanet planet)
        {
            _planet = planet;

            _coordinate.Latitude = 0;
            _coordinate.Longitude = 0;
            _coordinate.Direction = Direction.N;
        }

        public string MoveForward()
        {
            var _previousLatitude = _coordinate.Latitude;
            var _previousLongitude = _coordinate.Longitude;

            // Determine the coordinate that the rover may land on
            switch (_coordinate.Direction)
            {
                case Direction.N:
                    if (_coordinate.Latitude > 0)
                    {
                        _coordinate.Latitude--;
                    }
                    else
                    {
                        _coordinate.Latitude = _planet.SurfaceArea.GetLength(0) - 1;
                    }
                    break;
                case Direction.E:
                    if (_coordinate.Longitude < _planet.SurfaceArea.GetLength(1) - 1)
                    {
                        _coordinate.Longitude++;
                    }
                    else
                    {
                        _coordinate.Longitude = 0;
                    }
                    break;
                case Direction.S:
                    if (_coordinate.Latitude < _planet.SurfaceArea.GetLength(0) - 1)
                    {
                        _coordinate.Latitude++;
                    }
                    else
                    {
                        _coordinate.Latitude = 0;
                    }
                    break;
                case Direction.W:
                    if (_coordinate.Longitude > 0)
                    {
                        _coordinate.Longitude--;
                    }
                    else
                    {
                        _coordinate.Longitude = _planet.SurfaceArea.GetLength(1) - 1;
                    }
                    break;
            }

            // Is the move possible?
            if(_planet.SurfaceArea[_coordinate.Longitude, _coordinate.Latitude] == (int)Terrain.ImpassableTerrain)
            {
                _coordinate.Longitude = _previousLongitude;
                _coordinate.Latitude = _previousLatitude;
                Console.WriteLine("Obstacle encountered. Move aborted.");
            }

            return ToString();
        }

        public string MoveBackward()
        {
            var _previousLatitude = _coordinate.Latitude;
            var _previousLongitude = _coordinate.Longitude;

            // Determine the coordinate that the rover may land on
            switch (_coordinate.Direction)
            {
                case Direction.N:
                    if (_coordinate.Latitude > _planet.SurfaceArea.GetLength(0) - 1)
                    {
                        _coordinate.Latitude++;
                    }
                    else
                    {
                        _coordinate.Latitude = 0;
                    }
                    break;
                case Direction.E:
                    if (_coordinate.Longitude > 0)
                    {
                        _coordinate.Longitude--;
                    }
                    else
                    {
                        _coordinate.Longitude = _planet.SurfaceArea.GetLength(1) - 1;
                    }
                    break;
                case Direction.S:
                    if (_coordinate.Latitude < 0)
                    {
                        _coordinate.Latitude--;
                    }
                    else
                    {
                        _coordinate.Latitude = _planet.SurfaceArea.GetLength(0) - 1;
                    }
                    break;
                case Direction.W:
                    if (_coordinate.Longitude < _planet.SurfaceArea.GetLength(1) - 1)
                    {
                        _coordinate.Longitude++;
                    }
                    else
                    {
                        _coordinate.Longitude = 0;
                    }
                    break;
            }

            // Is the move possible?
            if (_planet.SurfaceArea[_coordinate.Longitude, _coordinate.Latitude] == (int)Terrain.ImpassableTerrain)
            {
                _coordinate.Longitude = _previousLongitude;
                _coordinate.Latitude = _previousLatitude;
                return "Obstacle encountered. Move aborted.";
            }

            return ToString();
        }

        public string TurnLeft()
        {
            switch(_coordinate.Direction)
            {
                case Direction.N:
                    _coordinate.Direction = Direction.W;
                    break;
                case Direction.E:
                    _coordinate.Direction = Direction.N;
                    break;
                case Direction.S:
                    _coordinate.Direction = Direction.E;
                    break;
                case Direction.W:
                    _coordinate.Direction = Direction.S;
                    break;
            }

            return ToString();
        }

        public string TurnRight()
        {
            switch (_coordinate.Direction)
            {
                case Direction.N:
                    _coordinate.Direction = Direction.E;
                    break;
                case Direction.E:
                    _coordinate.Direction = Direction.S;
                    break;
                case Direction.S:
                    _coordinate.Direction = Direction.W;
                    break;
                case Direction.W:
                    _coordinate.Direction = Direction.N;
                    break;
            }

            return ToString();
        }

        public string CurrentPosition()
        {
            return this.ToString();
        }

        public override string ToString()
        {
            return String.Format("{0} {1}, {2}", _coordinate.Direction.ToString(), _coordinate.Longitude, _coordinate.Latitude);
        }
    }
}