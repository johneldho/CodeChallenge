using System;
using System.Collections.Generic;

namespace Code.Challenge.DataLayer.Entities
{
    public class WolferhamptonDataSource
    {
        public string FixtureId { get; set; }
        public DateTime Timestamp { get; set; }
        public RaceDetails RawData { get; set; }
    }

    public class RaceDetails
    {
        public string FixtureName { get; set; }
        public string Id { get; set; }
        public DateTime StartTime { get; set; }
        public int Sequence { get; set; }
        public RaceTags Tags { get; set; }
        public List<Market> Markets { get; set; }
        public Participant[] Participants { get; set; }
    }
    public class Participant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ParticipantsTags Tags { get; set; }
    }
    public class ParticipantsTags
    {
        public string Weight { get; set; }
        public string Drawn { get; set; }
        public string Jockey { get; set; }
        public string Number { get; set; }
        public string Trainer { get; set; }
    }
    public class MarketTags
    {
        public string Places { get; set; }
        public string Type { get; set; }
    }
    public class Market
    {
        public string Id { get; set; }
        public Selection[] Selections { get; set; }
        public MarketTags Tags { get; set; }
    }
    public class Selection
    {
        public string Id { get; set; }
        public float Price { get; set; }
        public SectionTag Tags { get; set; }
    }
    public class SectionTag
    {
        public string Participant { get; set; }
        public string Name { get; set; }
    }
    public class RaceTags
    {
        public string CourseType { get; set; }
        public string Distance { get; set; }
        public string Going { get; set; }
        public string Runners { get; set; }
        public string MeetingCode { get; set; }
        public string TrackCode { get; set; }
        public string Sport { get; set; }
    }
}