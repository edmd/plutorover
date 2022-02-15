
namespace PlutoRover.Logic
{
	public class MoveBackwardCommand : Command
	{
		public override void Execute(IRover rover)
		{
			rover.MoveBackward();
		}
	}
}