using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SSB.Keys.Mnemonic.Tests_GUI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			var words = "body hair useful camp warm into cause riot two bamboo kick educate dinosaur advice seed type crisp where guilt avocado output rely lunch goddess";
			var keys = new Keys
			{
				Curve = "ed25519",
				Public = "1nf1T1tUSa43dWglCHzyKIxV61jG/EeeL1Xq1Nk8I3U=.ed25519",
				Private = "GO0Lv5BvcuuJJdHrokHoo0PmCDC/XjO/SZ6H+ddq4UvWd/VPW1RJrjd1aCUIfPIojFXrWMb8R54vVerU2TwjdQ==.ed25519",
				ID = "@1nf1T1tUSa43dWglCHzyKIxV61jG/EeeL1Xq1Nk8I3U=.ed25519"
			};

			txtWords.Text = words;
			txtKeys.Text = keys.ToString();
		}

		private void ButtonKeysToWords_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				var keys = Keys.FromString(txtKeys.Text);

				var mnemonic = new MnemonicConverter();

				var words = mnemonic.KeysToWords(keys);

				txtWords.Text = words;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				txtWords.Text = string.Empty;
			}
		}

		private void ButtonWordsToKeys_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				var words = txtWords.Text;

				var mnemonic = new MnemonicConverter();

				var keys = mnemonic.WordsToKeys(words);

				txtKeys.Text = keys.ToString();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				txtKeys.Text = string.Empty;
			}
		}
	}
}
