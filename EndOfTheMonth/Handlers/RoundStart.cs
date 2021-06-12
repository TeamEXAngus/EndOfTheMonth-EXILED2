using System.Linq;
using Exiled.API.Features;
using Exiled.API.Enums;
using Exiled.API.Extensions;
using Interactables.Interobjects.DoorUtils;

namespace EndOfTheMonth.Handlers
{
    internal class RoundStart
    {
        private EndOfTheMonth Plugin = EndOfTheMonth.Instance;

        public void OnRoundStart()
        {
            Plugin.EventRound = Plugin.Config.PercentChance >= Plugin.RNG.Next(1, 101);
            Plugin.EventRound &= EndOfTheMonth.CheckConfigValidity(); //Sets EventRound to false if config is invalid

            RoomType location = Plugin.Config.EventInClassDCells ? RoomType.LczClassDSpawn : RoomType.EzShelter;
            Spawning.Location = Map.Rooms.Where(room => room.Type == location).ElementAt(0);

            foreach (var door in Map.Doors)
            {
                //0 if the door is a Class D cell and 1 if it isn't
                door.ActiveLocks += GetBooleanValue(!IsClassDDoor(door));
            }
        }

        private ushort GetBooleanValue(bool boolean) => (ushort)(boolean ? 1 : 0);

        private bool IsClassDDoor(DoorVariant door) => door.Type() == DoorType.PrisonDoor;
    }
}