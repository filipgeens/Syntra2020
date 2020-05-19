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

namespace HelloWorld {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow :Window {
		public MainWindow() {
			InitializeComponent();
		}

		private void OepsieButton_Click(object sender, RoutedEventArgs e) {
			OepsieWindow oepsie = new OepsieWindow();
			if (oepsie.ShowDialog() == true) {
				HalloButton.Content = "Joepie!!!";
			} else {
				HalloButton.Content = "Ooooooh :(";

			}
		}

		private void OepsieButton_MouseMove(object sender, MouseEventArgs e) {
			HalloButton.Content = "Joehoe!!!";
		}

		private void OepsieButton_MouseLeave(object sender, MouseEventArgs e) {

			HalloButton.Content = "Hallo";
		}
	}
}
