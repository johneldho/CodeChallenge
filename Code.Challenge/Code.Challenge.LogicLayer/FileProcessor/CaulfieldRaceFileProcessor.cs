using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Code.Challenge.DataLayer.DTO;
using Code.Challenge.LogicLayer.Interface;

namespace Code.Challenge.LogicLayer.FileProcessor
{
    public class CaulfieldRaceFileProcessor:IRaceFileProcessor
    {
         
        public async Task<List<Horse>> Process(string raceFileName)
        {
            try
            {

                // process the file

                // logic for processing the file goes here

                // process the file

                //var racesourcedata = new CaulfieldRaceDataSource();
                //var raceData = _mapper.Map<List<Horse>>(racesourcedata);

                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
   
}
