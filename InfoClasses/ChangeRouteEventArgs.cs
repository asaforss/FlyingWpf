// Åsa Forss InfoClasses 2012-03-21

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modul5
{
    /// <summary>
    /// Class that inherits EventArgs
    /// </summary>
    public class ChangeRouteEventArgs :EventArgs
    {
        //Fields
        private string flightNr; // Number of the flight
        private string position; // changed position
        /// <summary>
        /// Constructor with 2 parameters
        /// </summary>
        /// <param name="flightNr"></param>
        /// <param name="position"></param>
        public ChangeRouteEventArgs(string flightNr, string position)
        {
            this.flightNr = flightNr;
            this.position = position;
        }
        /// <summary>
        /// Property for Flight Number
        /// </summary>
	    public string FlightNr 
        {
		    get { return flightNr; }
		    set { flightNr = value; }
	    }
        /// <summary>
        /// Property for Postion
        /// </summary>
	    public string Position 
        {
		    get { return position; }
		    set { position = value; }
	    }
    }
}
