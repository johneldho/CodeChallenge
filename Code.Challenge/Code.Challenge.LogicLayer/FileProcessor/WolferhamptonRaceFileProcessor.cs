using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Code.Challenge.DataLayer.DTO;
using Code.Challenge.LogicLayer.Interface;

namespace Code.Challenge.LogicLayer.FileProcessor
{
    public class WolferhamptonRaceFileProcessor :IRaceFileProcessor
    {
        public Task<List<Horse>> Process(string raceFileName)
        {
            throw new NotImplementedException();
        }
    }
}
