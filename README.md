# SSB.Keys.Mnemonic

Module that converts from/to SSB keys and [BIP39](https://github.com/bitcoin/bips/blob/master/bip-0039.mediawiki) mnemonic codes.

C# (.NET Standard) implementation of the https://github.com/staltz/ssb-keys-mnemonic

## Usage
```c#
using SSB.Keys.Mnemonic;
```

## Donate
If you like this little project and find it worthy of a donation, send some coins to:<br/>
bitcoin: 3GSpoWVTwjbt9BGiivZmsWe9DBkTR87Wpf<br/>
ethereum: 0xF0942E600B976F343DE6660C53392D5a37A7ca12<br/>
monero: 4Jy22AgYpZEQ9D4yVrm8cD9MX5hPqycQmR7vA96r9LP18gASE8nFYGSLd7fZ4LZQChLTwFPZDbd2hDVTrLnaVXCcNYHc6U9jES2JErc8Uu<br/>

### string KeysToWords(Keys keys)

```c#
var mnemonic = new MnemonicConverter();
var keys = new Keys
{
	Curve = "ed25519",
	Public = "1nf1T1tUSa43dWglCHzyKIxV61jG/EeeL1Xq1Nk8I3U=.ed25519",
	Private = "GO0Lv5BvcuuJJdHrokHoo0PmCDC/XjO/SZ6H+ddq4UvWd/VPW1RJrjd1aCUIfPIojFXrWMb8R54vVerU2TwjdQ==.ed25519",
	ID = "@1nf1T1tUSa43dWglCHzyKIxV61jG/EeeL1Xq1Nk8I3U=.ed25519"
};
var words = mnemonic.KeysToWords(keys);
Console.WriteLine(words)
/*

body hair useful camp warm into cause riot two bamboo kick educate dinosaur advice seed type crisp where guilt avocado output rely lunch goddess

*/
```

### Keys WordsToKeys(string words)

```c#
var mnemonic = new MnemonicConverter();
var words = "body hair useful camp warm into cause riot two bamboo kick educate dinosaur advice seed type crisp where guilt avocado output rely lunch goddess";
var keys = mnemonic.WordsToKeys(words);
Console.WriteLine(keys)
/*

{
  "curve": "ed25519",
  "public": "1nf1T1tUSa43dWglCHzyKIxV61jG/EeeL1Xq1Nk8I3U=.ed25519",
  "private": "GO0Lv5BvcuuJJdHrokHoo0PmCDC/XjO/SZ6H+ddq4UvWd/VPW1RJrjd1aCUIfPIojFXrWMb8R54vVerU2TwjdQ==.ed25519",
  "id": "@1nf1T1tUSa43dWglCHzyKIxV61jG/EeeL1Xq1Nk8I3U=.ed25519"
}

*/
```

## License

MIT
