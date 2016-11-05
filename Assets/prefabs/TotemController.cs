using UnityEngine;
using System;
using System.Collections;
using matnesis.TeaTime;

public class TotemController : MonoBehaviour
{
    public GameObject LittleHead;

    // Use this for initialization
    void Start()
    {
        rotateSwitchRoutine();
    }

    void rotateSwitchRoutine()
    {
        this.tt("rotateSwitchRoutine").Loop(delegate (ttHandler handler)
        {
            float rotationSpeed = 10f;

            LittleHead.transform.Rotate(new Vector3(0f, 1f, 0f) * rotationSpeed);

        });
    }

    void OnCollisionEnter(Collision collision)
    {
        //
        // first detect that it is a bullet
        //

        //
        // activated switch animation
        //

    }
}
