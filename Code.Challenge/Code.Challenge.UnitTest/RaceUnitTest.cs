using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Code.Challenge.DataLayer.Entities;
using Code.Challenge.DataLayer.Mapper;
using Xunit;

namespace Code.Challenge.UnitTest
{
    public class RaceUnitTest
    {
        [Fact]
        public void AutoMapper_Configuration_IsValid()
        {
            var config = new MapperConfiguration(opts => { opts.AddProfile(new RaceDataMapper()); });
            var mapper = config.CreateMapper();
            config.AssertConfigurationIsValid();
        }


        [Fact]
        public void HorseDataMapperCaulfield_Horse_Mapper_Test()
        {
            var config = new MapperConfiguration(opts => { opts.AddProfile(new RaceDataMapper()); });
            var mapper = config.CreateMapper();


            var source = new CaulfieldRaceDataSource()
            {
                Meeting = new Meeting()
                {
                    Races = new Races()
                    {
                        Race = new Race()
                        {

                            Horses = new Horses()
                            {
                                Horse = new List<Horse>()
                                {
                                    new Horse()
                                    {
                                        Name = "Jacky",
                                        Number = "2",
                                        Price = "3"

                                    },
                                    new Horse()
                                    {
                                        Name = "Star",
                                        Number = "3",
                                        Price = "7"


                                    },
                                    new Horse()
                                    {
                                        Name = "Mandy",
                                        Number = "1",
                                        Price = "4"

                                    }
                                }
                            }

                        }
                    }
                }
            };

            var houseList = mapper.Map<List<Horse>>(source.Meeting.Races.Race.Horses.Horse);
            Assert.NotNull(houseList);
            Assert.Equal("3", houseList.First()?.Price);
        }


   

        [Fact]
        public void HorseDataMapperCaulfield_Mapper_Test()
        {
            var config = new MapperConfiguration(opts => { opts.AddProfile(new RaceDataMapper()); });
            var mapper = config.CreateMapper();



            var source = new CaulfieldRaceDataSource()
            {
                Meeting = new Meeting()
                {
                    Races = new Races()
                    {
                        Race = new Race()
                        {

                            Horses = new Horses()
                            {
                                Horse = new List<Horse>()
                                {
                                    new Horse()
                                    {
                                        Name = "Jacky",
                                        Number = "2",
                                        Price = "3"

                                    },
                                    new Horse()
                                    {
                                        Name = "Star",
                                        Number = "3",
                                        Price = "7"


                                    },
                                    new Horse()
                                    {
                                        Name = "Mandy",
                                        Number = "1",
                                        Price = "4"

                                    }
                                }
                            }

                        }
                    }
                }
            };

            var houseList = mapper.Map<List<Challenge.DataLayer.DTO.Horse>>(source);
            Assert.NotNull(houseList);
            Assert.Equal( 3, houseList.First()?.Price);
        }

        [Fact]
        public void HorseDataMapperWolferHampton_Mapper_Test()
        {
            var config = new MapperConfiguration(opts => { opts.AddProfile(new RaceDataMapper()); });
            var mapper = config.CreateMapper();


            var source = new WolferhamptonDataSource()
            {
                RawData = new RaceDetails()
                {
                    Markets = new List<Market>()
                    {
                        new Market()
                        {
                            Id = "NbSeMfzhDCHT_HdtAYZF_7zjFkI",
                            Selections =  new[]
                            {
                                new Selection(){Id="1asdasd",Price = 2.2f , Tags =  new SectionTag()
                                {
                                    Participant = "1",
                                    Name = "John"
                                }},

                                new Selection(){Id="3asdasd",Price = 1.2f , Tags =  new SectionTag()
                                {
                                    Participant = "3",
                                    Name = "Eldho"
                                }},

                                new Selection(){Id="2asdasd",Price = 5.2f , Tags =  new SectionTag()
                                {
                                    Participant = "2",
                                    Name = "Sam"
                                }}

                            },

                        }
                    },
                    Participants = new[]
                    {
                        new Participant(){Id = 1,Name = "John", Tags = new ParticipantsTags(){Drawn="abc"}},
                        new Participant(){Id = 3,Name = "Eldho", Tags = new ParticipantsTags(){Drawn="bcd"}},
                        new Participant(){Id = 2,Name = "Sam", Tags = new ParticipantsTags(){Drawn="cde"}},
                    }
                }
            };

            var houseList = mapper.Map<List<Challenge.DataLayer.DTO.Horse>>(source);

            Assert.NotNull(houseList);
            Assert.Equal( 2.2f, houseList.First()?.Price);
        }

       

    }
}
