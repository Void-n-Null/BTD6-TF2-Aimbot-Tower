using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Display;
using BTD_Mod_Helper.Api.Display;
using UnityEngine;
using static Il2CppAssets.Scripts.Simulation.SMath.Vector3;
using MelonLoader.Utils;
using SniperAimbot;
using BTD_Mod_Helper.Extensions;

namespace SniperAimbot;

public class Displays
{
    public class Tower
    {
        public class Base: ModDisplay
        {
            public override string BaseDisplay => Generic2dDisplay;
            public override void ModifyDisplayNode(UnityDisplayNode node)
            {
                Helper.SniperifyNode(node, "Sniper-000", mod);
            }
        }

        public class Gibus : ModDisplay
        {
            public override string BaseDisplay => Generic2dDisplay;
            public override void ModifyDisplayNode(UnityDisplayNode node)
            {
                Helper.SniperifyNode(node, "Sniper-010", mod);
            }
        }

        public class AusGibus : ModDisplay
        {
            public override string BaseDisplay => Generic2dDisplay;
            public override void ModifyDisplayNode(UnityDisplayNode node)
            {
                Helper.SniperifyNode(node, "Sniper-020", mod);
            }
        }

        public class ToweringPillar : ModDisplay
        {
            public override string BaseDisplay => Generic2dDisplay;
            public override void ModifyDisplayNode(UnityDisplayNode node)
            {
                Helper.SniperifyNode(node, "Sniper-030", mod);
            }
        }

        public class Dimmadome : ModDisplay
        {
            public override string BaseDisplay => Generic2dDisplay;
            public override void ModifyDisplayNode(UnityDisplayNode node)
            {
                Helper.SniperifyNode(node, "Sniper-050", mod);
            }
        }
    }

    public class Projectile
    {
        public class Money : ModDisplay
        {
            public override string BaseDisplay => Generic2dDisplay;
            public override void ModifyDisplayNode(UnityDisplayNode node)
            {
                node.transform.rotation = Quaternion.identity;
                node.GetRenderer<SpriteRenderer>().sprite = null;
                var prefab = Helper.LoadAsset<GameObject>("Money-Prefab", GetBundle("sniper"));
                var moneyObject = UnityEngine.Object.Instantiate(prefab, node.transform.GetChild(0).transform);
                node.transform.GetChild(0).gameObject.AddComponent<MoneyMovement>();
                node.transform.GetChild(0).transform.rotation = Quaternion.identity;
                node.transform.GetChild(0).transform.localScale *= 12;

            }
        }
    }
}