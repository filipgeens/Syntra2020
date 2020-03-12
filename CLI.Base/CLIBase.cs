using System;
using System.Collections.Generic;
using System.Text;

namespace CliLib {

	

	public class CLIBase {

		public delegate bool ExecuteCallback(CLIBase parent, CliCommand Input);

		bool _exit = false;
		string _cursor = "Cmd>";
		CliCommand _command = new CliCommand();
		ExecuteCallback _cb = null;
		public CLIBase() {		}
		public CLIBase(ExecuteCallback cb) { Callback = cb; }
		public bool Exit { get { return _exit; } set => _exit = value; }
		public CliCommand Input { get => _command; private set => _command = value; }
		public ExecuteCallback Callback { get => _cb; set => _cb = value; }

		public void ShowError(string error) => ShowInColor(error, ConsoleColor.Red, ConsoleColor.Magenta);

		public void ShowInColor(string msg, ConsoleColor col, ConsoleColor optional) {
			ConsoleColor curColor = Console.ForegroundColor;
			ConsoleColor curBackCol = Console.BackgroundColor;
			Console.ForegroundColor = curColor != col ? col : optional;
			if (Console.BackgroundColor == Console.ForegroundColor) Console.BackgroundColor = Console.BackgroundColor == col ? optional : col;
			Console.WriteLine();
			Console.WriteLine(msg);
			Console.WriteLine();
			Console.ForegroundColor = curColor;
			Console.BackgroundColor = curBackCol;
		}

		public void Run(string[] args) {
			while (!Exit) {
				Console.Write(_cursor);
				Input.CommandLine = Console.ReadLine();
				if (Input.IsValid) {
					switch (Input.Command) {
						case "exit":
						case "quit":
							Exit = true;
							break;
						case "cursor":
							_cursor = Input[0].Length > 0 ? Input[0] : _cursor;
							break;
						case "cls":
						case "clear":
							Console.Clear();
							break;
						case "print":
						case "echo":
							ShowInColor(Input.ParameterLine, ConsoleColor.Blue, ConsoleColor.Green);
							break;
						case "colors":
							Input.CommandLine = "color list";
							goto case "color";
						case "color":
						case "kleur":
							if (Input.HasParameters) {
								switch (Input[0].ToLower()) {
									case "lijst":
									case "list":
										foreach (var col in Enum.GetValues(typeof(ConsoleColor))) { Console.WriteLine(col); }
										break;
									case "foreground":
									case "voorgrond":
										if (Enum.TryParse(typeof(ConsoleColor), Input[1], out object fcol)) {
											Console.ForegroundColor = (ConsoleColor)fcol;
										}
										break;
									case "background":
									case "achtergrond":
										if (Enum.TryParse(typeof(ConsoleColor), Input[1], out object bcol)) {
											Console.BackgroundColor = (ConsoleColor)bcol;
										}
										break;
								}
							}
							break;
						default:
							bool wrongCommand = true;
							if (Callback != null) {
								wrongCommand = Callback(this, Input) == false;
							}
							if (wrongCommand) {
								ShowError($"Het commando '{Input.CommandLine}' is niet gekend");
							}
							break;
					}
					Console.WriteLine();
				}
			}
		}
	}
}
