using Exiled.API.Interfaces;
using System.ComponentModel;

namespace EndOfTheMonth
{
    public sealed class Config : IConfig
    {
        [Description("Whether or not this plugin is enabled.")]
        public bool IsEnabled { get; set; } = true;

        [Description("The percent chance that a round will be an event round.")]
        public int PercentChance { get; set; } = 10;

        [Description("Whether or not the event should happen in the Class D cells.")]
        public bool EventInClassDCells { get; set; } = true;

        [Description("Whether or not the event should happen in the Evac Shelter.")]
        public bool EventInEvacShelter { get; set; } = true;
    }
}