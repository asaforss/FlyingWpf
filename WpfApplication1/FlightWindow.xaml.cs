// Åsa Forss Modul5 2012-03-21

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Modul5
{
    /// <summary>
    /// Interaction logic for FlightWindow.xaml Publisher
    /// </summary>
    public partial class FlightWindow : Window
    {
        private string flightNr;
        /// <summary>
        /// Default Constructor
        /// </summary>
        public FlightWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Constructor with 1 parameter
        /// </summary>
        /// <param name="flightNr"></param>
        public FlightWindow(string flightNr)
        {
            InitializeComponent();
            this.flightNr = flightNr;
            InitialiseGUI();
            
        }
        /// <summary>
        /// Method that initialises GUI
        /// </summary>
        private void InitialiseGUI()
        {
            btnLand.IsEnabled = false;
            cmbRoute.ItemsSource = Enum.GetValues(typeof(RouteChangeType)).Cast<RouteChangeType>();
            cmbRoute.SelectedIndex = 0;
            cmbRoute.IsEnabled = false;
            this.Title = flightNr;
            // For the images to be displayed
            string flightLetters=flightNr.Substring(0,2);
            System.Drawing.Bitmap plane;
            switch (flightLetters)
            {
                case "SK":
                    plane = Properties.Resources.SAS;
                    break;
                case "KL":
                    plane =Properties.Resources.KLM;
                    break;
                case "LH":
                    plane=Properties.Resources.Lufthansa;
                    break;

		        default:
                    plane = Properties.Resources.Unknown;
                    break;
	        }
            imgFlight.Source = convertBitmapToBitmapSource(plane);
            
        }
        // Event handlers
            public event EventHandler<TakeOffEventArgs> SendTakeOffInfo;
            public event EventHandler<ChangeRouteEventArgs> SendChangeRouteInfo;
            public event EventHandler<LandEventArgs> SendLandingInfo;
        
        
        /// <summary>
            /// Method to return Bitmapsource from bitmap input taken from  http://social.msdn.microsoft.com/Forums/eu/wpf/thread/8b9ce0c7-45f4-43b8-8e35-bf2407732437
        /// </summary>
        /// <param name="bmp"></param>
        /// <returns></returns>
        System.Windows.Media.Imaging.BitmapSource convertBitmapToBitmapSource(System.Drawing.Bitmap bmp)
        {
            return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(bmp.GetHbitmap(),
                                                                                IntPtr.Zero,
                                                                                Int32Rect.Empty,
                                                                                System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
        }
        /// <summary>
        /// Event handler for start button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            
             TakeOffEventArgs flightInfo = new TakeOffEventArgs(flightNr);
             if (SendTakeOffInfo != null)
                SendTakeOffInfo(this,flightInfo);
             btnStart.IsEnabled = false;
             btnLand.IsEnabled = true;
             cmbRoute.IsEnabled = true;
        }
       
       
        /// <summary>
        /// Event handler for land button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLand_Click(object sender, RoutedEventArgs e)
        {
            LandEventArgs flightInfo = new LandEventArgs(flightNr);
            if (SendLandingInfo != null)
                SendLandingInfo(this, flightInfo);
            this.Close();

        }
        /// <summary>
        /// Event handler for combobox route selection changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbRoute_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbRoute.SelectedIndex != 0)
            {
                string heading = cmbRoute.SelectedItem.ToString();
                ChangeRouteEventArgs flightInfo = new ChangeRouteEventArgs(flightNr, "now heading " + heading);
                if (SendChangeRouteInfo != null)
                SendChangeRouteInfo(this, flightInfo);
            }
        }

        

    }
}
