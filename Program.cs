/*
 * Copyright (c) 2021, Alain Bacon <alain@fury161.org>
 */
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Morph
{
	internal class Program
	{
		private static int Main(string[] args)
		{
			if (args.Length != 1) {
				Console.Error.WriteLine("Usage: morph <infile>");
				return 1;
			}

			try {
				// Search instances of {{VariableName}} and ask Expand() for
				// the value to use as replacement.
				var input = File.ReadAllText(args[0]);
				var output = Regex.Replace(input, @"\{\{(?<var>.*?)\}\}", Expand);
				Console.WriteLine(output);
			}
			catch (IOException e) {
				Console.Error.WriteLine(e.Message);
			}

			return 0;
		}

		private static string Expand(Match match)
		{
			var name = match.Groups["var"].Value;
			var fallback = "";

			// Extract fallback value from variable name if any (name|fallback):
			var m = Regex.Match(name, @"(?<name>.*?)\|(?<fallback>.*?)$");

			if (m.Success) {
				name = m.Groups["name"].Value;
				fallback = m.Groups["fallback"].Value;
			}

			return Environment.GetEnvironmentVariable(name) ?? fallback;
		}
	}
}