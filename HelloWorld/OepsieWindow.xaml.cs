using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HelloWorld {
	/// <summary>
	/// Interaction logic for OepsieWindow.xaml
	/// </summary>
	public partial class OepsieWindow :Window {
		public OepsieWindow() {
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e) {

		}

		private void CloseButton_Click(object sender, RoutedEventArgs e) {
			DialogResult = false;
		}

		private void OkButton_Click(object sender, RoutedEventArgs e) {
			DialogResult = true;
		}
	}
}
