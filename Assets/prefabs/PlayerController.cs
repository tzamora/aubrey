using UnityEngine;
using System;
using System.Collections;
using matnesis.TeaTime;

public class PlayerController : MonoBehaviour {

    public PistolController pistol;

    // Use this for initialization
    void Start () {

        shootInputRoutine();

        changeBulletRoutine();
	
	}

    void shootInputRoutine() {

        this.tt("shootInputRoutine").Loop(delegate(ttHandler handler) {

            if (Input.GetMouseButtonDown(0)) {

                pistol.shoot();

            }

        });

    }

    void changeBulletRoutine() {

        this.tt("changeBulletRoutine").Loop(delegate (ttHandler handler) {

            if (Input.GetKeyDown(KeyCode.Alpha1)){
                pistol.SetBullet(PistolController.BulletTypeEnum.Black);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2)){
                pistol.SetBullet(PistolController.BulletTypeEnum.Yellow);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                pistol.SetBullet(PistolController.BulletTypeEnum.Red);
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                pistol.SetBullet(PistolController.BulletTypeEnum.Blue);
            }

        });
    }
}
