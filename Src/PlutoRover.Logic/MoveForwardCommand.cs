
namespace PlutoRover.Logic
{
	public class MoveForwardCommand : Command
	{
		public override void Execute(IRover rover)
		{
			rover.MoveForward();
		}
	}
}