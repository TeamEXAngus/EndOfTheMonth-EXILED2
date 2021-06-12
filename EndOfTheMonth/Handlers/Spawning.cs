using Exiled.Events.EventArgs;
using Exiled.API.Features;
using MEC;

namespace EndOfTheMonth.Handlers
{
    internal class Spawning
    {
        private EndOfTheMonth Plugin = EndOfTheMonth.Instance;
        public static Room Location;
        private float Delay = 1f;

        public void OnSpawning(SpawningEventArgs ev)
        {
            if (ev.Player.SessionVariables.ContainsKey("EndOfTheMonth: Has Spawned")) { return; }
            ev.Player.SessionVariables.Add("EndOfTheMonth: Has Spawned", null);

            Timing.CallDelayed(Delay, () => //Prevents the plugin breaking when OnSpawning is called before OnRoundStarted
            {
                if (!Plugin.EventRound) { return; }

                switch (Plugin.RNG.Next(0, 2))
                {
                    case 0:

                        ev.Player.SetRole(RoleType.FacilityGuard);
                        Timing.CallDelayed(Delay, () => ev.Player.Position = Location.Position);
                        break;

                    case 1:

                        ev.Player.SetRole(RoleType.ClassD);
                        //Class D will spawn in their normal spawn point if the event is happening in Class D cells
                        if (!Plugin.Config.EventInClassDCells) { Timing.CallDelayed(Delay, () => ev.Player.Position = Location.Position); }
                        break;

                    default: break;
                }
            });
        }
    }
}