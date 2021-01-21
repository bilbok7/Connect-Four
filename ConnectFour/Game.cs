using System;
using System.IO;


namespace Connect4
{
	class Game
	{
		static void Main(string[] args)
		{

			char ch;
			Console.WriteLine("1. Game vs. Player");
			Console.WriteLine("2. Game vs. Computer");
			Console.WriteLine("3. Leaderboard");
			Console.WriteLine("4. Help");
			Console.WriteLine("5. Exit");
			Console.WriteLine("Please enter the number of your choice from above");
			ch = char.Parse(Console.ReadLine());

			switch (ch)
			{
				case '1':
					Board current_board = new Board();
					current_board.print_state();

					bool win = false;
					int current_player = 1;

					while (!win)
					{
						Console.Write("Please enter column Player " + current_player + "\n");
						string scol = Console.ReadLine();
						int col;
						while (!int.TryParse(scol.ToString(), out col))
						{
							Console.Write("Please enter column Player " + current_player + "\n");
							scol = Console.ReadLine();
						}

						int row = current_board.drop(col, current_player);
						if (row == -1) continue;

						win = current_board.check_win(col, row, current_player);

						current_board.print_state();

						current_player = (current_player == 1) ? 2 : 1;
					}
					current_board.print_state();
					break;

				case '2':
					break;

				case '3':
					break;

				case '4':

					try
					{
						string contents = File.ReadAllText(@"C:\Users\bilib\Desktop\ConnectFour\ConnectFour\HelpForConnect4.txt");
						Console.Write(contents);

					}
					catch (IOException e)
					{
						Console.WriteLine("The file could not be read:");
						Console.WriteLine(e.Message);
					}
					break;

				case '5':
					Environment.Exit(0);
					break;
			}
		}
	}
}