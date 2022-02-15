//using System.Collections.Generic;

namespace PlutoRover.Logic
{
    public interface IRover
    {
        //List<Command> Route { get; set; } // This would be useful in undoing / redoing commands for a Rover
        string MoveBackward();
        string MoveForward();
        string TurnLeft();
        string TurnRight();
        string CurrentPosition();
    }
}