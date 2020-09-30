using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesPVR.Logic
{
    /// <summary>
    /// 
    /// This class represent show timing of Movies
    /// </summary>
    public class ShowTime
    {
        // Time 
        public int Time { get; set; }

        // Time String representation
        public string TimeName { get; set; }

        // Prepare List of Available Show Timings
        public static List<ShowTime> GetShowTimes()
        {
            List<ShowTime> times = new List<ShowTime>();
            times.Add(new ShowTime { Time = 600, TimeName = "10:00" });
            times.Add(new ShowTime { Time = 780, TimeName = "13:00" });
            times.Add(new ShowTime { Time = 960, TimeName = "16:00" });
            times.Add(new ShowTime { Time = 1140, TimeName = "19:00" });
            return times;
        }
    }
}