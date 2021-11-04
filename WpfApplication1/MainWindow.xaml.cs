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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Modul5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml The subscriber
    /// </summary>
    public partial class MainWindow : Window
    {
          
       
        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            InitializeGui();
        }
        /// <summary>
        /// Method that initialise GUI
        /// </summary>
        private void InitializeGui()
        {
           

            //DataGrid
            //from http://www.devspoint.com/net/how-to-programatically-add-rows-and-columns-to-wpf-datagrid.html
            //Create new object of DatagridTextColumn for Product column
           DataGridTextColumn myFlightCode = new DataGridTextColumn();
           myFlightCode.Binding = new Binding("FlightNr");
 
           // for Price column
           DataGridTextColumn myStatus = new DataGridTextColumn();
           myStatus.Binding = new Binding("Position");

           DataGridTextColumn myTime = new DataGridTextColumn();
           myTime.Binding = new Binding("ThisTime");
 
           // add headers
           myFlightCode.Header = "Flight Code";
           myStatus.Header = "Status";
           myTime.Header = "Time";

            // set Width
           myFlightCode.Width = 120;
           myStatus.Width = 240;
           myTime.Width = 180;
 
           // add to dataGrid
            dtgFlight.Columns.Add(myFlightCode);
            dtgFlight.Columns.Add(myStatus);
            dtgFlight.Columns.Add(myTime);
            dtgFlight.GridLinesVisibility = (DataGridGridLinesVisibility)2;
          
        }
        /// <summary>
        /// Event handler for the send button. creates a publisher.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            if (txtNextFlight.Text.Substring(0,2).All(Char.IsLetter)) //Validates Input
            {
                // Create a window
                FlightWindow window = new FlightWindow(txtNextFlight.Text);
                // Open a window
                window.Show();
               
                dtgFlight.Items.Add(new FlightData() { FlightNr = txtNextFlight.Text, Position = "Send to runway", ThisTime = DateTime.Now.TimeOfDay.ToString() });
                window.SendTakeOffInfo += OnTakeOff;        //subscription
                window.SendChangeRouteInfo += OnChangeInFlight;  //subscription
                window.SendLandingInfo += OnLanding;     //subscription

            }
            else
                MessageBox.Show("You must first giva a Flight number with two letters in the beginning");
        }
        /// <summary>
        /// Subsribes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTakeOff(object sender, TakeOffEventArgs e)
        {
            
            dtgFlight.Items.Add(new FlightData() { FlightNr = e.FlightNr, Position = e.Position,ThisTime=DateTime.Now.TimeOfDay.ToString() });
            
            
         

        }
        /// <summary>
        /// Subscribes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnChangeInFlight(object sender, ChangeRouteEventArgs e)
        {
           
            dtgFlight.Items.Add(new FlightData() { FlightNr = e.FlightNr, Position = e.Position, ThisTime = DateTime.Now.TimeOfDay.ToString() });

        }
        /// <summary>
        /// Subscribes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLanding(object sender, LandEventArgs e)
        {
            
            dtgFlight.Items.Add(new FlightData() { FlightNr = e.FlightNr, Position = e.Position, ThisTime = DateTime.Now.TimeOfDay.ToString() });

        }
       
        /// <summary>
        /// Struct that keeps flight data
        /// </summary>
        public struct FlightData
        {
            public string FlightNr { set; get; }
            public string Position { set; get; }
            public string ThisTime { set; get; }
        }
    }
}

