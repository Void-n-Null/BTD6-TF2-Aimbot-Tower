using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RegisterTypeInIl2Cpp]
public class MoneyMovement : MonoBehaviour
{
    public MoneyMovement(IntPtr ptr) : base(ptr) { }

    public float rotationSpeed = 0.3f;
    public float maxUp = 0.1f;
    public float maxDown = -0.1f;
    public float offset = 0.5f;
    public float floatSpeed = 0.1f;

    public bool goingUp;
    // Update is called once per frame
    void Update()
    {

        if (goingUp)
        {
            transform.localPosition += new Vector3(0, floatSpeed * Time.deltaTime * transform.localScale.magnitude, 0);
            if (transform.localPosition.y >= (maxUp + offset) * transform.localScale.magnitude)
            {
                goingUp = false;
            }
        }
        else
        {
            transform.localPosition -= new Vector3(0, floatSpeed * Time.deltaTime * transform.localScale.magnitude, 0);
            if (transform.localPosition.y <= (maxDown + offset) * transform.localScale.magnitude)
            {
                goingUp = true;
            }
        }

        transform.Rotate(0, rotationSpeed, 0);

    }

    private void Start()
    {
        transform.localPosition = new Vector3(0, offset, 0);
    }
}
