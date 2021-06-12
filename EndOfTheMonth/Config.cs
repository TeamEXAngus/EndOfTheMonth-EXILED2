using Exiled.API.Interfaces;

namespace EndOfTheMonth
{
    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public int PercentChance { get; set; } = 10;
        public bool EventInClassDCells { get; set; } = true;
        public bool EventInEvacShelter { get; set; } = true;
    }
}