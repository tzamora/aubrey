using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using matnesis.TeaTime;

public class PlayerController : MonoBehaviour {

    public PistolController pistol;

    public Dictionary<BulletController.BulletTypeEnum, int> bulletsCounter;

    // Use this for initialization
    void Start () {

        bulletsCounter = new Dictionary<BulletController.BulletTypeEnum, int>();

        //bulletsCounter[BulletController.BulletTypeEnum.Black] = 0;
        //bulletsCounter[BulletController.BulletTypeEnum.Blue] = 0;
        //bulletsCounter[BulletController.BulletTypeEnum.Red] = 0;
        //bulletsCounter[BulletController.BulletTypeEnum.Yellow] = 0;

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
