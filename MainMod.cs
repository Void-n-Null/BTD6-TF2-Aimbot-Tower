using MelonLoader;
using BTD_Mod_Helper;
using SniperAimbot;
using Il2CppAssets.Scripts.Models.Effects;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.Profile;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons.Behaviors;
using Il2CppAssets.Scripts.Simulation.Towers.Weapons.Behaviors;
using Il2CppAssets.Scripts.Unity.Display;
using Il2CppAssets.Scripts.Unity.Effects;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using HarmonyLib;
using Il2CppSystem.Collections.Generic;
using UnityEngine;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppInterop.Runtime.Injection;
using SniperAimbot;
using static SniperAimbot.Displays;
using System.IO;
using System.Media;
using static BTD_Mod_Helper.Api.ModContent;
using BTD_Mod_Helper.Api.ModOptions;
using BTD_Mod_Helper.Api.Components;

[assembly: MelonInfo(typeof(SniperAimbot.MainMod), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace SniperAimbot;

public class MainMod : BloonsTD6Mod
{
    public static readonly ModSettingBool EnableVoice = new ModSettingBool(true)
    {
        displayName = "Enable Sniper Voice Lines"
    };

    [HarmonyPatch(typeof(AudioFactory), nameof(AudioFactory.Start))]
    public class AudioFactoryStart_Patch
    {
        [HarmonyPostfix]
        public static void Postfix(AudioFactory __instance)
        {
            var bundle = GetBundle<MainMod>("sniper");
            var bundleRequest = bundle.LoadAllAssetsAsync<AudioClip>();
            foreach (uObject asset in bundleRequest.allAssets)
            {
                __instance.RegisterAudioClip(asset.name, asset.Cast<AudioClip>());
            }
        }
    }


    
    
    public override void OnApplicationStart()
    {
        ClassInjector.RegisterTypeInIl2Cpp<Spin>();
        ClassInjector.RegisterTypeInIl2Cpp<MoneyMovement>();
        ClassInjector.RegisterTypeInIl2Cpp<SniperSound>();
        ModHelper.Msg<MainMod>("Snipin's a good job mate");
    }
}