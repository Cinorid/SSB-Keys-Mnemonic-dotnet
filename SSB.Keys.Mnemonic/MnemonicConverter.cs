using System;
using System.Linq;
using Bitcoin.BIP39;

namespace SSB.Keys.Mnemonic
{
	public class MnemonicConverter
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="keys"></param>
		/// <returns></returns>
		public string KeysToWords(Keys keys)
		{
			if (keys.Curve != "ed25519") throw new ArgumentException("only \"ed25519\" curve is supported");
			if (string.IsNullOrEmpty(keys.Public)) throw new ArgumentException("keys object is missing \"public\" field");
			if (string.IsNullOrEmpty(keys.Private)) throw new ArgumentException("keys object is missing \"private\" field");

			var pub = Convert.FromBase64String(keys.Public.Replace(".ed25519", ""));
			var priv = Convert.FromBase64String(keys.Private.Replace(".ed25519", ""));
			if (pub.Length != 32) throw new ArgumentException("public should be exactly 32 bytes");
			if (priv.Length != 64) throw new ArgumentException("private should be exactly 64 bytes");
			if (!Enumerable.SequenceEqual(SubArray(pub, 0, 32), SubArray(priv, 32, 32)))
			{
				throw new ArgumentException("public ed2519 key must be embedded within private key");
			}

			var seed = SubArray(priv, 0, 32);
			BIP39 bip39 = new BIP39(seed);
			var words = bip39.MnemonicSentence;
			
			return words;
		}

		public Keys WordsToKeys(string words)
		{
			var wordArr = words.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			var amount = wordArr.Length;
			if (amount != 24 && amount != 48) throw new ArgumentException("there should be 24 or 48 words");
			var fixedWords = string.Join(" ", SubArray(wordArr, 0, 24));
			
			BIP39 bip39 = new BIP39(fixedWords,"", BIP39.Language.English);
			var seed = bip39.EntropyBytes;

			Rebex.Security.Cryptography.Ed25519 ed25519 = new Rebex.Security.Cryptography.Ed25519();
			ed25519.FromSeed(seed);
			var secretKey = ed25519.GetPrivateKey();
			var publicKey = ed25519.GetPublicKey();

			var _public = Convert.ToBase64String(publicKey) + ".ed25519";
			var _private = Convert.ToBase64String(secretKey) + ".ed25519";
			var keys = new Keys
			{
				Curve = "ed25519",
				Public = _public,
				Private = _private,
				ID = "@" + _public,
			};

			return keys;
		}

		private static T[] SubArray<T>(T[] data, int index, int length)
		{
			T[] result = new T[length];
			Array.Copy(data, index, result, 0, length);
			return result;
		}
	}
}
