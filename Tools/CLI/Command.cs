using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;
using System.Text.RegularExpressions;

namespace SyntraAB.Tools.CLI {

	public class CliCommand {
		string _commandLine = string.Empty;
		string _command = string.Empty;
		List<string> _parameters = null;
		string _parameterLine = string.Empty;
		public CliCommand() { }
		public CliCommand(string cmd) { CommandLine = cmd; }
		public string CommandLine { get => _commandLine; set { _commandLine = value; UpdateParameters(); } }
		public List<string> Parameters { get { _parameters ??= new List<string>(); return _parameters; } protected set => _parameters = value; }
		public string Command { get => _command; protected set => _command = value; }
		public string ParameterLine { get => _parameterLine; set => _parameterLine = value; }
		public int Count { get => Parameters.Count; }
		public bool HasParameters { get => Count > 0; }
		public bool IsValid { get => Command?.Length > 0; }

		public string this[int pos] { get { if (pos >= 0 && pos < Parameters.Count) { return Parameters[pos]; } return string.Empty; } }
		private void UpdateParameters() {
			string cmd = CommandLine.Replace('"', '\'');
			MatchCollection results =Regex.Matches(cmd, @"'[\.\w -]+'");
			foreach (Match res in results) {
				cmd=cmd.Replace(res.Value, res.Value.Replace(' ', '\n'));
			}
			string[] prm = cmd.Split(" ");
			for (int i = 0;i < prm?.Length;i++) { prm[i] = prm[i].Replace('\n', ' ').Trim('\''); }
			if (prm?.Length > 0) {
				Command = prm[0]?.ToLower() ?? string.Empty;
				Parameters.Clear();
				for (int i = 1;i < prm.Length;i++) {
					Parameters.Add(prm[i]);
				}
				ParameterLine = CommandLine.Replace($"{Command} ", "");
			}
		}

		public string GetParameter(int idx, string defaultValue) => Parameters?.Count > idx ? Parameters[idx] : defaultValue;
	}
}
