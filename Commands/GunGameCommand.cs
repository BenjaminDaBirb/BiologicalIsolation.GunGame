using System;
using Exiled.API.Features;
using CommandSystem;
using Mirror;


namespace GunGame
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class GunGame : ICommand
    {
        public string Command { get; } = "GunGame";

        public string[] Aliases { get; } = new[] { "gg" };

        public string Description { get; } =  "A type of a mini-game like Csgo";


        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player senderPlayer = Player.Get(sender);
            senderPlayer.SetRole(RoleType.Tutorial);
            Round.IsLocked = true;
            foreach (Ragdoll doll in UnityEngine.Object.FindObjectsOfType<Ragdoll>())
            {
                if (!doll) { break; }
                NetworkServer.Destroy(doll.gameObject);
            }
            Door.LockAll(9999, Exiled.API.Enums.DoorLockType.AdminCommand);
            Respawn.NtfTickets = 1;
            Respawn.ChaosTickets = 1;
            foreach (Player player in Player.List)
            {
                player.SetRole(RoleType.ClassD);
                player.AddItem(ItemType.GunCOM15);
                player.AddItem(ItemType.Medkit);
                player.AddItem(ItemType.ArmorHeavy);
                player.AddItem(ItemType.Ammo9x19, 10);
                player.AddItem(ItemType.Ammo762x39, 10);
                player.AddItem(ItemType.Ammo556x45, 10);
                player.AddItem(ItemType.Ammo44cal, 10);
                player.AddItem(ItemType.Ammo12gauge, 10);
                //Pre-add ammo for future weapons
                
            }
            Cassie.Message("5. 4. 3. 2. 1, Go!", isNoisy:true);
            Server.FriendlyFire = true;
            senderPlayer.Broadcast(20, "Minden beállítva! Kérjük, teleportálja az összes játékost arra a helyre, ahol az eseményt szeretné megtartani, és indítsa el az eseményt!");
            response = "Minden be van állítva! Most elkezdheti";
            return true;
        }
    }
}
