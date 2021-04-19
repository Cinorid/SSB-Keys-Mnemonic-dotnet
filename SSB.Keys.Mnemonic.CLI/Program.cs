using System;
using SSB.Keys;

namespace SSB.Keys.Mnemonic.CLI
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args.Length < 1)
			{
				Console.WriteLine(WriteHelp());
				return;
			}

			string sf = string.Empty;
			string s = string.Empty;
			string wf = string.Empty;
			string w = string.Empty;
			string mode = string.Empty;
			string resultSecret = string.Empty;
			string resultWords = string.Empty;

			foreach (string a in args)
			{
				var parts = a.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
				if (parts.Length > 1)
				{
					if (string.Compare("-m", parts[0]) == 0)
					{
						mode = parts[1];

						if (string.Compare(mode, "s2w") != 0 && string.Compare(mode, "w2s") != 0)
						{
							Console.WriteLine("invalid -m parameter, please use 's2w' or 'w2s'");
							return;
						}
					}
					else if (string.Compare("-sf", parts[0]) == 0)
					{
						sf = parts[1];
						if (string.IsNullOrEmpty(sf))
						{
							Console.WriteLine("invalid -sf parameter");
							return;
						}
					}
					else if (string.Compare("-wf", parts[0]) == 0)
					{
						wf = parts[1];
						if (string.IsNullOrEmpty(wf))
						{
							Console.WriteLine("invalid -wf parameter");
							return;
						}
					}
					else if (string.Compare("-s", parts[0]) == 0)
					{
						s = parts[1];
						if (string.IsNullOrEmpty(s))
						{
							Console.WriteLine("invalid -s parameter");
							return;
						}
					}
					else if (string.Compare("-w", parts[0]) == 0)
					{
						w = parts[1];
						if (string.IsNullOrEmpty(w))
						{
							Console.WriteLine("invalid -w parameter");
							return;
						}
					}	
				}	
			}

			if (mode == "s2w")
			{
				if (!string.IsNullOrEmpty(sf))
				{
					s = System.IO.File.ReadAllText(sf);
				}

				if(string.IsNullOrEmpty(s))
				{
					Console.WriteLine("no secret specified");
					return;
				}

				var key = Storage.ReconstructKeys(s);
				MnemonicConverter mnemonicConverter = new MnemonicConverter();
				resultWords = mnemonicConverter.KeysToWords(key);

				if (!string.IsNullOrEmpty(wf))
				{
					System.IO.File.WriteAllText(wf, resultWords);
				}
				else
				{
					Console.WriteLine(resultWords);
				}
			}
			else if (mode == "w2s")
			{
				if (!string.IsNullOrEmpty(wf))
				{
					w = System.IO.File.ReadAllText(wf);
				}

				if (string.IsNullOrEmpty(w))
				{
					Console.WriteLine("no words specified");
					return;
				}

				MnemonicConverter mnemonicConverter = new MnemonicConverter();

				var key = mnemonicConverter.WordsToKeys(w);
				resultSecret = Storage.ConstructKeys(key, false);

				if (!string.IsNullOrEmpty(sf))
				{
					System.IO.File.WriteAllText(sf, resultSecret);
				}
				else
				{
					Console.WriteLine(resultSecret);
				}
			}
		}

		static string WriteHelp()
		{
			return "Usage:\tSSB.Keys.Mnemonic.CLI [OPERAND]..." + Environment.NewLine +
				Environment.NewLine +
				"Secret file conversion, converting and formatting according to the operands." + Environment.NewLine +
				Environment.NewLine +
				"  -m=MODE\tconvertion mode, can be: 's2w' or 'w2s'" + Environment.NewLine +
				"    -m=s2w\tsecret to words" + Environment.NewLine +
				"    -m=w2s\twords to secret" + Environment.NewLine +
				Environment.NewLine +
				"  -s=\"secret\"\tsecret file content from stdin" + Environment.NewLine +
				"  -w=\"words\"\twords list from stdin" + Environment.NewLine +
				"  -sf=FILE\tsecret FILE name instead of stdin" + Environment.NewLine +
				"  -wf=FILE\twords FILE name instead of stdout" + Environment.NewLine +
				Environment.NewLine +
				"Samples:" + Environment.NewLine +
				"1.\tdotnet SSB.Keys.Mnemonic.CLI.dll -m=s2w -sf=C:\\Users\\user\\.ssb\\secret" + Environment.NewLine +
				"2.\tdotnet SSB.Keys.Mnemonic.CLI.dll -m=s2w -sf=C:\\Users\\user\\.ssb\\secret -wf=words.txt" + Environment.NewLine +
				"3.\tdotnet SSB.Keys.Mnemonic.CLI.dll -m=w2s -w=C:\\Users\\user\\.ssb\\secret -sf=secret.txt" + Environment.NewLine +
				"4.\tdotnet SSB.Keys.Mnemonic.CLI.dll -m=w2s -w=\"body hair useful camp warm into cause riot two bamboo kick educate dinosaur advice seed type crisp where guilt avocado output rely lunch goddess\" -sf=secret.txt";
		}
	}
}
