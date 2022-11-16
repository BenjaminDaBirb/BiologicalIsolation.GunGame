using Exiled.API.Features;
using Player = Exiled.Events.Handlers.Player;

namespace GunGame
{
    public class Plugin : Plugin<Config>
    {
        public PlayerHandler playerHandler = new();

        public override string Name => "BiologicalIsolation.GunGame";
        public override string Author => "Biological Isolation - BasicallyBirb#3488";
        public override Version Version => new Version(1, 2, 0);

        public override void OnEnabled()
        {
            Player.Died += playerHandler.OnPlayerDie;
            Log.Info("BiologicalIsolation.GunGame Plugin has been loaded! Enjoy the command!");
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Player.Died -= playerHandler.OnPlayerDie;
            Log.Info("BiologicalIsolation.GunGame Plugin has been disabled.");
            base.OnDisabled();
        }
    }
}