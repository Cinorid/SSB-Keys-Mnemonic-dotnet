using NUnit.Framework;

namespace SSB.Keys.Mnemonic.Tests
{
	public class Tests
	{
		MnemonicConverter mnemonic;
		Keys keys;
		string words;

		[SetUp]
		public void Setup()
		{
			mnemonic = new MnemonicConverter();

			keys = new Keys
			{
				Curve = "ed25519",
				Public = "1nf1T1tUSa43dWglCHzyKIxV61jG/EeeL1Xq1Nk8I3U=.ed25519",
				Private = "GO0Lv5BvcuuJJdHrokHoo0PmCDC/XjO/SZ6H+ddq4UvWd/VPW1RJrjd1aCUIfPIojFXrWMb8R54vVerU2TwjdQ==.ed25519",
				ID = "@1nf1T1tUSa43dWglCHzyKIxV61jG/EeeL1Xq1Nk8I3U=.ed25519"
			};

			words = "body hair useful camp warm into cause riot two bamboo kick educate dinosaur advice seed type crisp where guilt avocado output rely lunch goddess";
		}

		[Test]
		public void TestKeysToWords()
		{
			var newWords = mnemonic.KeysToWords(keys);

			Assert.AreEqual(newWords, words);
		}

		[Test]
		public void TestWordsToKeys()
		{
			var newKeys = mnemonic.WordsToKeys(words);

			Assert.AreEqual(newKeys, keys);
		}
	}
}