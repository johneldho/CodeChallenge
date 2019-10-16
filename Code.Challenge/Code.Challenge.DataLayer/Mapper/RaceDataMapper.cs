using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Code.Challenge.DataLayer.Entities;


namespace Code.Challenge.DataLayer.Mapper
{
    public class RaceDataMapper :Profile
    {
        public RaceDataMapper()
        {
            CreateMap<Entities.Horse, Challenge.DataLayer.DTO.Horse>()
                .ForMember(d => d.HorseID, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Price, opt => opt.MapFrom(s => s.Price))
                .ForMember(d => d.HorseName, opt => opt.MapFrom(s => s.Name))
                // extent the horse DTO class to incorporate more properties. and add in here.
                //ignoring all other properties
                .ForAllOtherMembers(opt => opt.Ignore());

            //mapping complex object
            CreateMap<CaulfieldRaceDataSource, List<DTO.Horse>>().ConvertUsing<CaulFiledRaceDataConverter>();

            CreateMap<WolferhamptonDataSource, List<DTO.Horse>>().ConvertUsing<WolferhamptonDataSourceConverter>();


        }

    }
    public class CaulFiledRaceDataConverter : ITypeConverter<CaulfieldRaceDataSource, List<DTO.Horse>>
    {
        public List<DTO.Horse> Convert(CaulfieldRaceDataSource source, List<DTO.Horse> destination, ResolutionContext context)
        {
            var horses = source.Meeting.Races.Race.Horses.Horse;
            return horses == null ? null : context.Mapper.Map<List<DTO.Horse>>(horses);
        }
    }

    public class WolferhamptonDataSourceConverter : ITypeConverter<WolferhamptonDataSource, List<DTO.Horse>>
    {
        
        public List<DTO.Horse> Convert(WolferhamptonDataSource source, List<DTO.Horse> destination, ResolutionContext context)
        {
            var selections = source.RawData.Markets.FirstOrDefault()?.Selections.Select(s => new { ParticipantId = int.Parse(s.Tags.Participant), Price = s.Price });

            var participants = source.RawData.Participants
                .Select(p => new { ParticipantId = p.Id, HorseName = p.Name });

            if (selections == null)
                return null;
            else
            {
                var horseData = participants
                    .Join(selections,
                        participant => participant.ParticipantId,
                        selection => selection.ParticipantId,
                        (participant, selection) => new DTO.Horse()
                        {
                            HorseID = participant.ParticipantId,
                            HorseName = participant.HorseName,
                            Price = selection.Price
                        });

                return horseData.ToList();
            }
        }
    }

}
