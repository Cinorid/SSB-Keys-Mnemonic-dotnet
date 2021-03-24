# SSB.Keys.Mnemonic

Module that converts from/to SSB keys and [BIP39](https://github.com/bitcoin/bips/blob/master/bip-0039.mediawiki) mnemonic codes.

C# (.NET Standard) implementation of the https://github.com/staltz/ssb-keys-mnemonic

## Usage
```c#
using SSB.Keys.Mnemonic;
```

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
