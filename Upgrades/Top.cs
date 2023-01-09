using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;

namespace SniperAimbot.Upgrades;

public class Top
{
    public class Tier1 : ModUpgrade<Tower>
    {
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.GetWeapon().rate /= 2;
        }

        public override string Name => "Speed Hack";
        public override string Description => "Changes the tick speed of the Aimbot's client, doubles fire speed";
        public override int Path => 0;
        public override int Tier => 1;
        public override int Cost => 1200;

        public override string Icon => "speedhack_icon";
    }
    
    public class Tier2 : ModUpgrade<Tower>
    {
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.GetWeapon().rate /= 3;
        }

        public override string Name => "Overclock";
        public override string Description => "Overclocks the CPU of the Aimbot! Triples fire speed.";
        public override int Path => 0;
        public override int Tier => 2;
        public override string Icon => "overclock_icon";
        public override int Cost => 3200;
    }

    public class Tier3 : ModUpgrade<Tower>
    {
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.GetWeapon().projectile.GetDamageModel().damage *= 2;
            towerModel.AddBehavior(new OverrideCamoDetectionModel("OverrideCamoDetectionModel_", true));
            towerModel.GetAttackModel().attackThroughWalls = true;
            towerModel.GetWeapon().projectile.GetDamageModel().immuneBloonProperties = Il2Cpp.BloonProperties.None;
        }

        public override string Name => "Wall Hacks";
        public override string Description => "Toggle ESP! See baloons through walls and see camo!";
        public override int Path => 0;
        public override int Tier => 3;
        public override int Cost => 6000;

        public override string Icon => "walls_icon";
    }

    public class Tier4 : ModUpgrade<Tower>
    {
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.GetWeapon().projectile.GetDamageModel().damage *= 2;
            towerModel.GetWeapon().rate /= 4;
            towerModel.GetWeapon().projectile.pierce = 2;
        }

        public override string Name => "RTX-GRAPHICS-CARD";
        public override string Description => "MY FPS ARE OVER 9000!";
        public override int Path => 0;
        public override int Tier => 4;
        public override int Cost => 9001;
        public override string Icon => "rtx_icon";
    }

    public class Tier5 : ModUpgrade<Tower>
    {
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.GetWeapon().projectile.GetDamageModel().damage *= 5;
            towerModel.GetWeapon().rate /= 2;
            towerModel.GetWeapon().projectile.pierce = 4;
        }

        public override string Name => "Super Computer";
        public override string Description => "All your bloon are belong to us.";
        public override int Path => 0;
        public override int Tier => 5;
        public override int Cost => 37000;
        public override string Icon => "supercomp_icon";
    }

}