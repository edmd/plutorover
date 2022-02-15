using System;

namespace PlutoRover.Logic
{
	public class CommandHandler : ICommandHandler
	{
		private Command[] _route;

		public CommandHandler(string commands)
		{
			if (string.IsNullOrEmpty(commands.Trim()))
			{
				_route = new Command[100];

				for (var action = 0; action < 100; action++)
				{
					Random rnd = new Random();
					var move = rnd.Next((int)Action.L);

					if (Enum.IsDefined(typeof(Action), move))
					{
						switch (move)
						{
							case (int)Action.F:
								_route[action] = new MoveForwardCommand();
								break;
							case (int)Action.L:
								_route[action] = new TurnLeftCommand();
								break;
							case (int)Action.B:
								_route[action] = new MoveBackwardCommand();
								break;
							case (int)Action.R:
								_route[action] = new TurnRightCommand();
								break;
						}
					}
				}
			}
			else
			{
				var moves = commands.Split(' ');
				_route = new Command[moves.Length];

				for (var action = 0; action < moves.Length; action++)
				{
					switch (moves[action].ToString())
					{
						case "F":
							_route[action] = new MoveForwardCommand();
							break;
						case "L":
							_route[action] = new TurnLeftCommand();
							break;
						case "B":
							_route[action] = new MoveBackwardCommand();
							break;
						case "R":
							_route[action] = new TurnRightCommand();
							break;
					}
				}
			}
		}

		public void ProcessCommands(IRover rover)
		{
			for (var position = 0; position <= _route.Length - 1; position++)
			{
				_route[position].Execute(rover);
			}
		}
	}
}