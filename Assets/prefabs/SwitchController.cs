using UnityEngine;
using System;
using System.Collections;
using matnesis.TeaTime;

public class SwitchController : MonoBehaviour {

    public vp_DamageHandler hitHandler;

	// Use this for initialization
	void Start () {

        rotateSwitchRoutine();

	}

    void rotateSwitchRoutine()
    {
        this.tt("rotateSwitchRoutine").Loop(delegate(ttHandler handler){

            Debug.Log("vamos a ver que pasa");

            float rotationSpeed = 10f;

            transform.Rotate(new Vector3(0f, 1f, 0f) * rotationSpeed);

        });
    }
}
