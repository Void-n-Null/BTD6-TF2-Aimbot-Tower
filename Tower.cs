using SniperAimbot;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SniperAimbot
{
    public class Tower : ModTower
    {
        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            towerModel.ApplyDisplay<Displays.Tower.Base>();
            towerModel.GetAttackModel().RemoveBehavior<RotateToTargetModel>();
            towerModel.GetWeapon().projectile.AddBehavior(new TrackTargetModel("Track", 99999, false, false, 9999, true, 99999, true, false));
        }



        public override string Icon => "Icon";
        public override string Portrait => "Icon";

        public override string Name => "Aimbot Sniper";
        public override TowerSet TowerSet => TowerSet.Military;
        public override string BaseTower => TowerType.SniperMonkey;
        public override int Cost => 4000;
        public override int TopPathUpgrades => 5;
        public override int MiddlePathUpgrades => 5;
        public override int BottomPathUpgrades => 0;
    }
}
