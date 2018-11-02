using System;

namespace PlutoRover.Logic
{
    public class Rover : IRover
    {
        private IPlanet _planet;
        private int _batteryLife;
        private Coordinate _coordinate;
        private Action[] _route;

        public Action[] Route { get => _route; set => _route = value; }
        public Coordinate Coordinate { get => _coordinate; set => _coordinate = value; }

        // Deploy rover
        public Rover(IPlanet planet, string commands)
        {
            _planet = planet;
            _batteryLife = 100;

            _coordinate.Latitude = 0;
            _coordinate.Longitude = 0;
            _coordinate.Direction = Direction.N;

            CalculateRoute(commands);
        }

        public void CalculateRoute(string commands)
        {
            if (string.IsNullOrEmpty(commands))
            {
                _route = new Action[_batteryLife];

                for (var action = 0; action < _batteryLife; action++)
                {
                    Random rnd = new Random();
                    var move = rnd.Next((int)Action.L);

                    if (Enum.IsDefined(typeof(Action), move))
                    {
                        _route[action] = (Action)move;
                    }
                }
            } else
            {
                var moves = commands.Split(' ');
                _route = new Action[moves.Length];

                for (var action = 0; action < moves.Length; action++)
                {
                    if (Enum.IsDefined(typeof(Action), moves[action]))
                    {
                        _route[action] = (Action)Enum.Parse(typeof(Action), moves[action]);
                    }
                    //else
                    //{
                    //    throw new Exception("Unknown command encountered.");
                    //}
                }
            }
        }

        public void ExecuteRoute()
        {
            for (var position = 0; position <= Route.Length - 1; position++)
            {
                switch(_route[position])
                {
                    case Action.F:
                        Forward();
                        break;
                    case Action.L:
                        Left();
                        break;
                    case Action.B:
                        Back();
                        break;
                    case Action.R:
                        Right();
                        break;
                }
            }
        }

        public string Forward()
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
                        _coordinate.Longitude = _planet.SurfaceArea.GetLength(1) - 1; ;
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

        public string Back()
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
                Console.WriteLine("Obstacle encountered. Move aborted.");
            }

            return ToString();
        }

        public string Left()
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

        public string Right()
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

        public string FinalPosition()
        {
            return String.Format("{0} {1}, {2}", _coordinate.Direction.ToString(), _coordinate.Longitude, _coordinate.Latitude);
        }

        public override string ToString()
        {
            Console.WriteLine("{0} {1}, {2}", _coordinate.Direction.ToString(), _coordinate.Longitude, _coordinate.Latitude);

            return null;
        }
    }
}
