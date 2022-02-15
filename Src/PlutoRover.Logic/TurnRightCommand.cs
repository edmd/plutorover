
namespace PlutoRover.Logic
{
	public class TurnRightCommand : Command
	{
		public override void Execute(IRover rover)
		{
			rover.TurnRight();
		}
	}
}