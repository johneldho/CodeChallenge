using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Code.Challenge.DataLayer.DTO;

namespace Code.Challenge.LogicLayer.Interface
{
    public interface IRaceFileProcessor
    {
        Task<List<Horse>>Process(string raceFileName);
    }
}
