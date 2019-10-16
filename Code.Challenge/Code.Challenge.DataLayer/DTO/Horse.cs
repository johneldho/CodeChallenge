using System;
using System.Collections.Generic;
using System.Text;

namespace Code.Challenge.DataLayer.DTO
{
    public class Horse
    {
        public long HorseID { get; set; }
        //public string RaceSourceID { get; set; }
        public string HorseName { get; set; }
        public string Country { get; set; }
       
       
        public float Price { get; set; }
    }
}
