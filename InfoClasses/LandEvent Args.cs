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
    public class LandEventArgs :EventArgs
    {
        // Fields
        private string flightNr; // Number of the flight
        private string position; // landed
        /// <summary>
        /// Constructor with 1 parameter
        /// </summary>
        /// <param name="flightNr"></param>
        public LandEventArgs(string flightNr)
        {
            this.flightNr = flightNr;
            this.position = "Landed";
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
