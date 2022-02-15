namespace PlutoRover.Logic
{
	public interface ICommandHandler
	{
		void ProcessCommands(IRover rover);
	}
}