using System.Collections.Generic;
using System.Text;
 
using Code.Challenge.DataLayer.DTO;

namespace Code.Challenge.LogicLayer.Interface
{
    public interface IHorseManagerLL
    {
        List<Horse> GetHorseDetails();
    }
}
