using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Code.Challenge.DataLayer.Entities;
using Code.Challenge.LogicLayer.Interface;
using Newtonsoft.Json;
using Horse = Code.Challenge.DataLayer.DTO.Horse;

namespace Code.Challenge.LogicLayer.FileProcessor
{
    public class WolferhamptonRaceFileProcessor :IRaceFileProcessor
    {
        private readonly IMapper _mapper;

        public WolferhamptonRaceFileProcessor(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<List<Horse>> Process(string raceDataFileName)
        {

            try
            {


                WolferhamptonDataSource raceItems;
                using (var r = new StreamReader(raceDataFileName))
                {
                    string json = r.ReadToEnd();
                    raceItems = JsonConvert.DeserializeObject<WolferhamptonDataSource>(json);
                }

                var horseData = _mapper.Map<List<Horse>>(raceItems);
                return horseData;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
