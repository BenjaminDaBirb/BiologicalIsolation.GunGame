using Exiled.Events.EventArgs;
using Exiled.API.Features;
using System.Collections;
using UnityEngine;

namespace GunGame
{
    public class PlayerHandler
    { 
        public static Dictionary<Player, int> Kills = new Dictionary<Player, int>();
        public static ItemType[] weapons = { ItemType.GunCOM18, ItemType.GunFSP9, ItemType.GunCrossvec
        , ItemType.GunE11SR, ItemType.GunAK, ItemType.GunShotgun, ItemType.GunLogicer, ItemType.ParticleDisruptor, ItemType.GunRevolver};
        System.Random random = new System.Random();
        int totalKills; 

        public void OnPlayerDie(DiedEventArgs ev)
        {
            Kills[ev.Killer]++;
            Kills.TryGetValue(ev.Killer, out totalKills); //Get value of player kills, and store them in the totalKills variable.
            ev.Target.Broadcast(20, $"Önt megölték {ev.Killer}, hamarosan újraszületik!");
            Log.Debug(totalKills);

            if(totalKills >= 2)
            {
                int index = random.Next(weapons.Length);
                ev.Killer.AddItem(weapons[index]);
            }

            if (ev.Killer.CurrentItem.IsWeapon && ev.Killer.CurrentItem.Equals(ItemType.GunRevolver))
            {
                ev.Killer.SetRole(RoleType.Scientist);
                Map.ShowHint("You won!", 20);
                Round.EndRound();
            }
          
            respawn(ev);
        }

        IEnumerator respawn(DiedEventArgs ev)
        {
            if(ev.Target.Role.Side == Exiled.API.Enums.Side.None)
            {
                yield return new WaitForSeconds(3);
                ev.Target.SetRole(RoleType.ClassD);
                ev.Target.AddItem(ItemType.GunCOM15);
                ev.Target.AddItem(ItemType.Medkit);
                ev.Target.AddItem(ItemType.ArmorHeavy);
                ev.Target.AddItem(ItemType.Ammo9x19, 10);
                ev.Target.AddItem(ItemType.Ammo762x39, 10);
                ev.Target.AddItem(ItemType.Ammo556x45, 10);
                ev.Target.AddItem(ItemType.Ammo44cal, 10);
                ev.Target.AddItem(ItemType.Ammo12gauge, 10);
            }
        }
    }

    
}
