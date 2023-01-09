using System;
using MelonLoader;
using UnhollowerRuntimeLib;
using UnityEngine;

namespace SniperAimbot;

[RegisterTypeInIl2Cpp]
public class Spin: MonoBehaviour
{
    public Spin(IntPtr ptr) : base(ptr) { }

    private static readonly Vector3 defaultSpeed = new Vector3(0, 1,0);
    public float speed = 500;
    public void Update()
    {
        transform.Rotate(defaultSpeed * speed * Time.deltaTime);
    }
}