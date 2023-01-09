using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;

namespace SniperAimbot.Upgrades;

public class Mid
{
    public class Tier1 : ModUpgrade<Tower>
    {
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.ApplyDisplay<Displays.Tower.Gibus>();
        }

        public override string Name => "Gibus";
        public override string Description => "Free to play firepower";
        public override int Path => 1;
        public override int Tier => 1;
        public override int Cost => 0;

        public override string Icon => "gibus_icon";
    }
    
    public class Tier2 : ModUpgrade<Tower>
    {
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.ApplyDisplay<Displays.Tower.AusGibus>();
        }

        public override string Name => "Australium Paint";
        public override string Description => "Paint your hat a shade of fake gold.";
        public override int Path => 1;
        public override int Tier => 2;
        public override int Cost => 3700;

        public override string Icon => "aus_icon";
    }

    public class Tier3 : ModUpgrade<Tower>
    {
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.ApplyDisplay<Displays.Tower.ToweringPillar>();
        }

        public override string Name => "Tripple Hats";
        public override string Description => "Who knew you could wear so many hats at once?";
        public override int Path => 1;
        public override int Tier => 3;
        public override int Cost => 8000;
        public override string Icon => "tripple_hat_icon";
    }

    public class Tier4 : ModUpgrade<Tower>
    {
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var MoneyMachine = Game.instance.model.GetTowerFromId("SpikeFactory-005").GetAttackModel().Duplicate();
            WeaponModel GunWeaponModel = MoneyMachine.weapons[0];
            GunWeaponModel.fireWithoutTarget = true;
            MoneyMachine.range *= 10f;
            GunWeaponModel.rate /= 2f;
            ProjectileModel projectileModel = MoneyMachine.weapons[0].projectile;
            projectileModel.RemoveBehavior<DamageModel>();
            projectileModel.RemoveBehavior<SetSpriteFromPierceModel>();
            projectileModel.pierce = 9999;
            projectileModel.ApplyDisplay<Displays.Projectile.Money>();
            towerModel.AddBehavior(MoneyMachine);
        }

        public override string Name => "Poor Financial Decisions";
        public override string Description => "Too much money? Just give it away!";
        public override int Path => 1;
        public override int Tier => 4;
        public override int Cost => 10000;

        public override string Icon => "money_icon";

    }

    public class Tier5 : ModUpgrade<Tower>
    {
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.ApplyDisplay<Displays.Tower.Dimmadome>();
        }

        public override string Name => "Doug Dimmadome";
        public override string Description => "The owner of the dimmsdale dimmadome?";
        public override int Path => 1;
        public override int Tier => 5;
        public override int Cost => 40000;
        public override string Icon => "dimmadome_icon";
    }

}