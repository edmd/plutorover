
namespace PlutoRover.Logic
{
	public class TurnLeftCommand : Command
	{
		public override void Execute(IRover rover)
		{
			rover.TurnLeft();
		}
	}
}