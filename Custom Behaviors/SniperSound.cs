using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Audio;
using static BTD_Mod_Helper.Api.ModContent;
namespace SniperAimbot
{
    [RegisterTypeInIl2Cpp]
    public class SniperSound : MonoBehaviour
    {
        public SniperSound(IntPtr ptr) : base(ptr) { }

        public List<string> clips;
        public AudioSource source;
        private float timeSinceClip;
        private float timeToPlay;

        public void Start()
        {
            if (clips == null)
            {
                clips = new List<string>();
            }
            timeToPlay = UnityEngine.Random.Range(0f, 1f);
            source = (FindObjectOfType<AudioListener>()).gameObject.AddComponent<AudioSource>();
            source.volume = 1f;
            source.bypassListenerEffects = true;
            source.bypassEffects = true;
            source.bypassReverbZones = true;
            var bundle = GetBundle<SniperAimbot.MainMod>("sniper");
            var bundleReq = bundle.LoadAllAssetsAsync<AudioClip>();
            foreach (var item in bundleReq.allAssets)
            {
                clips.Add(item.name);
            }
        }

        public void Update()
        {
            if (SniperAimbot.MainMod.EnableVoice)
            {
                timeSinceClip += Time.fixedDeltaTime / 100;

                if (timeSinceClip > timeToPlay)
                {
                    var index = UnityEngine.Random.Range(0, clips.Count);
                    Helper.PlaySound(clips[index]);
                    timeToPlay = UnityEngine.Random.Range(4f, 15f);
                    timeSinceClip = 0f;
                }
            }
        }
    }
}
