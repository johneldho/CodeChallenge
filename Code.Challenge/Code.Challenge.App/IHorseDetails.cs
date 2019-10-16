using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Code.Challenge.DataLayer.DTO;

namespace Code.Challenge.App
{
    public interface IHorseDetails
    {
        Task<List<Horse>> GetHorseDetails();
    }
}
