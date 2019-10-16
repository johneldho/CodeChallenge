using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Code.Challenge.DataLayer.DTO;
using Code.Challenge.LogicLayer.Interface;

namespace Code.Challenge.App
{
    public class HorseDetails : IHorseDetails
    {
        private readonly IHorseManagerLL _iHorseManagerll;
        public HorseDetails(IHorseManagerLL iHorseManagerll)
        {
            _iHorseManagerll = iHorseManagerll;
        }

        public async Task<List<Horse>> GetHorseDetails()
        {
            var horseData = await _iHorseManagerll.GetHorseDetails();

            return horseData;
        }
    }
}
