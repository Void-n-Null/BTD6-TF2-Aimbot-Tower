global using Il2CppAssets.Scripts.Models.Towers;
global using Il2CppAssets.Scripts.Unity;
global using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;
global using Il2CppAssets.Scripts.Simulation.Towers;
global using Il2CppAssets.Scripts.Simulation.Towers.Weapons;
global using System.Collections.Generic;
global using System;
global using System.Linq;
global using UnityEngine;
global using MelonLoader;
global using HarmonyLib;
global using Il2CppAssets.Scripts.Models.Towers.Upgrades;
global using Il2CppInterop.Runtime;
global using uObject = UnityEngine.Object;
global using Il2CppAssets.Scripts.Unity.Display;
global using Il2CppAssets.Scripts.Unity.Audio;
global using Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Abilities;
global using Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu;
global using Il2CppAssets.Main.Scenes;
global using Il2CppAssets.Scripts.Unity.Player;
global using Il2CppAssets.Scripts.Models.Profile;
global using MelonLoader.Utils;
global using Il2CppAssets.Scripts.Models.TowerSets;
global using Il2CppAssets.Scripts.Models;
global using Il2CppNewtonsoft.Json;
global using System.Reflection;
global using Il2CppInterop.Runtime.InteropTypes.Arrays;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Extensions;
using SniperAimbot;
using static BTD_Mod_Helper.Api.ModContent;
using BTD_Mod_Helper;

namespace SniperAimbot
{

    public static class Helper
    {
        public static UnityEngine.Object? LoadAsset<T>(string Asset, AssetBundle Bundle)
        {
            try
            {
                return Bundle.LoadAssetAsync(Asset, Il2CppType.Of<T>()).asset;
            }
            catch(Exception error){
                MelonLogger.Msg("Failed to load "+Asset+" from "+Bundle.name);
                try
                {
                    MelonLogger.Msg("Attempting to get available assets");
                    foreach(string asset in Bundle.GetAllAssetNames()){
                        MelonLogger.Msg(asset);
                }
                }catch
                {
                    MelonLogger.Msg("Bundle is null");
                }
                string message = error.Message;
                message += "@\n" + error.StackTrace;
                MelonLogger.Msg(message, "error");
                return null;
                }
        }

        public static void SniperifyNode(UnityDisplayNode node, string PrefabName, BloonsMod mod)
        {
            node.GetRenderer<SpriteRenderer>().sprite = null;
            var bundle = GetBundle(mod, "sniper");
            var prefab = Helper.LoadAsset<GameObject>(PrefabName, bundle);
            var sniperGameObject = GameObject.Instantiate(prefab, node.transform.GetChild(0).transform);
            node.transform.GetChild(0).transform.localScale *= 6;
            node.transform.GetChild(0).transform.localRotation = Quaternion.Euler(0, 0, 0);
            node.transform.GetChild(0).transform.localPosition = Vector3.zero;
            node.transform.GetChild(0).transform.localPosition -= new Vector3(0, 0, 0);
            node.transform.GetChild(0).gameObject.AddComponent<Spin>();
            var sound = node.transform.GetChild(0).gameObject.AddComponent<SniperSound>();

        }

        public static void PlaySound(string name)
        {
            try
            {
                Game.instance.audioFactory.PlaySoundFromUnity(null, name, "Sniper", 8, 1);
            }
            catch (Exception error)
            {
                MelonLogger.Msg("Failed to play clip " + name);
                string message = error.Message;
                message += "@\n" + error.StackTrace;
                MelonLogger.Msg(message, "error");
            }
        }
    }
}
