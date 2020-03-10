using System;
using System.Collections.Generic;
using System.Text;

namespace CliExample {

	public class CliPlugin {
		public virtual bool Execute(CLIBase parent, CliCommand Input) {
			switch (Input.Command) {
				case "hallo":
					Console.WriteLine("hallo iedereen");
					break;
			}
			return false;
		}
	}

	public class CLIBase {
		bool _exit = false;
		string _cursor = "Cmd>";
		CliCommand _command = new CliCommand();
		CliPlugin _ext = null;

		public bool Exit { get { return _exit; } set => _exit = value; }
		public CliPlugin Plugin { get => _ext; set => _ext = value; }
		public CliCommand Input { get => _command; private set => _command = value; }



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
							Console.WriteLine(Input.ParameterLine);
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
							if (Plugin != null) {
								Plugin.Execute(this, Input);
							}
							break;
					}
					Console.WriteLine();
				}
			}
		}
	}
}
