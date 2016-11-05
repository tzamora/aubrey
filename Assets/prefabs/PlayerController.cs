using UnityEngine;
using System;
using System.Collections;
using matnesis.TeaTime;

public class PlayerController : MonoBehaviour {

    PistolController pistol;

    // Use this for initialization
    void Start () {

        shootInputRoutine();
	
	}

    void shootInputRoutine() {

        this.tt("shootInputRoutine").Loop(delegate(ttHandler handler) {

            if (Input.GetMouseButtonDown(0)) {

                pistol.shoot();

            }

        });

    }
}
