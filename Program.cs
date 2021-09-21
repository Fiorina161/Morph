using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Morph
{
	internal class Program
	{
		private const string USAGE = "Usage: morph <infile>\n";

		private static int Main(string[] args)
		{
			try
			{
				foreach (var line in File.ReadAllLines(args[0]))
				{
					var tmp = ExpandVariables(line);
					Console.WriteLine(tmp);
				}
			}
			catch (IOException e)
			{
				Console.Error.WriteLine(e.Message);
				Console.Error.WriteLine(USAGE);
				return 1;
			}

			Console.ReadKey();
			return 0;
		}

		private static string ExpandVariables(string line)
		{
			return Regex.Replace(line, @"\{\{(?<vname>.*?)\}\}", ExpandVariable);
		}

		private static string ExpandVariable(Match match)
		{
			var name = match.Groups["vname"].Value;
			var fallback = "";
			var m = Regex.Match(name, @"(?<name>.*?)\|(?<default>.*?)$",RegexOptions.ExplicitCapture);
			
			if (m.Success)
			{
				name = m.Groups["name"].Value;
				fallback=m.Groups["default"].Value;
			}

			return Environment.GetEnvironmentVariable(name)??fallback;
		}
	}
}