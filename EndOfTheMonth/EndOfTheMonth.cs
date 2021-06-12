using System;
using Exiled.API.Enums;
using Exiled.API.Features;
using PlayerHandler = Exiled.Events.Handlers.Player;
using ServerHandler = Exiled.Events.Handlers.Server;

namespace EndOfTheMonth
{
    public class EndOfTheMonth : Plugin<Config>
    {
        private static EndOfTheMonth singleton = new EndOfTheMonth();
        public static EndOfTheMonth Instance => singleton;
        public override PluginPriority Priority { get; } = PluginPriority.Medium;

        public override Version RequiredExiledVersion { get; } = new Version(2, 10, 0);
        public override Version Version { get; } = new Version(1, 0, 0);

        public Random RNG = new Random();
        public bool EventRound = false;

        private Handlers.Spawning spawning;
        private Handlers.RoundStart roundStart;

        private EndOfTheMonth()
        {
        }

        //Run startup code when plugin is enabled
        public override void OnEnabled()
        {
            RegisterEvents();
        }

        //Run shutdown code when plugin is disabled
        public override void OnDisabled()
        {
            UnregisterEvents();
        }

        //Plugin startup code
        public void RegisterEvents()
        {
            spawning = new Handlers.Spawning();
            roundStart = new Handlers.RoundStart();

            PlayerHandler.Spawning += spawning.OnSpawning;
            ServerHandler.RoundStarted += roundStart.OnRoundStart;
        }

        //Plugin shutdown code
        public void UnregisterEvents()
        {
            PlayerHandler.Spawning -= spawning.OnSpawning;
            ServerHandler.RoundStarted -= roundStart.OnRoundStart;

            spawning = null;
            roundStart = null;
        }

        public static bool CheckConfigValidity()
        {
            if (Instance.Config.EventInClassDCells == Instance.Config.EventInEvacShelter)
            {
                Log.Error("EventInClassDCells and EventInEvacShelter should not be set to the same value!");
            }

            if (Instance.Config.EventInClassDCells || Instance.Config.EventInEvacShelter)
            {
                return true;
            }

            Log.Error("Neither EventInClassDCells nor EventInEvacShelter were set to true! No events will happen this round.");
            return false;
        }
    }
}