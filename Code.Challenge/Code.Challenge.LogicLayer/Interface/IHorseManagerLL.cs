﻿using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Code.Challenge.DataLayer.DTO;

namespace Code.Challenge.LogicLayer.Interface
{
    public interface IHorseManagerLL
    {
        Task<List<Horse>> GetHorseDetails();
    }
}
