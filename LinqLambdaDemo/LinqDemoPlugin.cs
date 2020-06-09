using SyntraAB.Tools.CLI;
using System;
using SyntraAB.Tools.Extensions;
using Syntra.Data.Models;
using System.Linq;
using System.Collections.Generic;

namespace LinqLambdaDemo {

  public static class LinqDemoExtensions {
    public static void WriteToConsole(this IEnumerable<Country> src) {
      foreach (var item in src?? new Country[] { }) { Console.WriteLine($"{item.Name} {item.Continent} {item.Currency} {item.Capital}"); }

    }
  
  }
  internal class LinqDemoPlugin: IPlugin {
    public string Name => "LinqDemo";
    CountryRepository _repos = null;

    public CountryRepository Repos { get { _repos ??= CreatRepository(); return _repos; } set => _repos = value; }

    private CountryRepository CreatRepository() {
      CountryRepository r = new CountryRepository();
      r.FillWithInitialData();
      return r;
    }

    public delegate int TelOp(int a);

    public bool Execute(CLIBase parent, CliCommand Input) {
      switch (Input.Command) {
        case "lambda":
          int b = -5;
          TelOp opteller = a => a + b;
          b = Input.Parameters[1].ToInt();
          Console.WriteLine(opteller(Input.Parameters[0].ToInt()));
          break;
        case "all":
          foreach (var item in Repos.Members) { Console.WriteLine($"{item.Name} {item.Continent} {item.Currency} {item.Capital}"); }
          break;
        case "currency":
          Repos.Members.Where(t => t.Currency?.ToLower().Contains(Input.Parameters[0]?.ToLower() ?? "") == true).OrderBy(o=>o.Capital).Reverse().WriteToConsole();
          break;
        case "continent":
          if (Input.Parameters.Count > 0) {
            Repos.Members.Where(t => t.Continent?.ToLower().Contains(Input.Parameters[0]?.ToLower() ?? "")==true).WriteToConsole();
          }
          break;
      }
      return true;
    }

    public void ShowHelp() {

    }
  }
}