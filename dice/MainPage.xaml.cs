using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;

namespace dice
{
	public partial class MainPage : PhoneApplicationPage
	{

		public class clic
		{
			public static int   clac    =   0;
			public static int   nb      =   6;
		}
   
		// Constructor
		public MainPage()
		{
			InitializeComponent();

			// Set the data context of the listbox control to the sample data
			DataContext = App.ViewModel;
			this.Loaded += new RoutedEventHandler(MainPage_Loaded);
		}

		// Load data for the ViewModel Items
		private void MainPage_Loaded(object sender, RoutedEventArgs e)
		{
			if (!App.ViewModel.IsDataLoaded)
			{
				App.ViewModel.LoadData();
			}
		}

		private void button1_Click(object sender, RoutedEventArgs e)
		{
			/* First Dice */
			textBlock2.Text = String.Empty;
			textBlock3.Text = String.Empty;
			clic.clac = 0;
			Random rnd = new Random();
			int i = rnd.Next(1, clic.nb + 1); 
			textBlock1.Text = " " + i.ToString() + "\n";
			clic.clac = 1;
		}

		private void button2_Click(object sender, RoutedEventArgs e)
		{
			/* New One */
			Random rnd = new Random();
			int i = rnd.Next(1, clic.nb + 1);
			if (clic.clac < 6)
				textBlock1.Text += " " + i.ToString() + "\n";
			else if (clic.clac >= 6 && clic.clac < 12)
				textBlock2.Text += " " + i.ToString() + "\n";
			else
				textBlock3.Text += " " + i.ToString() + "\n";
			clic.clac++;
		}

		private void button3_Click(object sender, RoutedEventArgs e)
		{
			/* Clean */
			textBlock1.Text = String.Empty;
			textBlock2.Text = String.Empty;
			textBlock3.Text = String.Empty;
			clic.clac = 0;
		}

		private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
		{

		}

		private void radioButton1_Checked(object sender, RoutedEventArgs e)
		{
			/* d2 */
			clic.nb = 2;
		}

		private void radioButton2_Checked(object sender, RoutedEventArgs e)
		{
			/* d3 */
			clic.nb = 3;
		}

		private void radioButton3_Checked(object sender, RoutedEventArgs e)
		{
			/* d4 */
			clic.nb = 4;
		}

		private void radioButton4_Checked(object sender, RoutedEventArgs e)
		{
			/* d6  */
		   clic. nb = 6;
		}

		private void radioButton5_Checked(object sender, RoutedEventArgs e)
		{
			/* d8 */
			clic.nb = 8;
		}

		private void radioButton6_Checked(object sender, RoutedEventArgs e)
		{
			/* d10 */
			clic.nb = 10;
		}

		private void radioButton7_Checked(object sender, RoutedEventArgs e)
		{
			/* d12 */
			clic.nb = 12;
		}

		private void radioButton8_Checked(object sender, RoutedEventArgs e)
		{
			/* d20 */
			clic.nb = 20;
		}

		private void TextBlock_Tap(object sender, System.Windows.Input.GestureEventArgs e)
		{
			EmailComposeTask emailComposeTask = new EmailComposeTask();

			emailComposeTask.Subject = "[Alea]";
			emailComposeTask.Body = "Hello !\n You can put your message here.\n\nAlois";
			emailComposeTask.To = "alois.degouvello@thinks.pro";

			emailComposeTask.Show();
		}
	}
}