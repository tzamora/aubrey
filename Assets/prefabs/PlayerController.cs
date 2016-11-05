using UnityEngine;
using System;
using System.Collections;
using matnesis.TeaTime;

public class PlayerController : MonoBehaviour {

    public GameObject bulletPrefab;

    public float bulletSpeed = 100f;

    public Transform pistol;

    // Use this for initialization
    void Start () {

        shootInputRoutine();
	
	}

    void shootInputRoutine() {

        this.tt("shootInputRoutine").Loop(delegate(ttHandler handler) {

            if (Input.GetMouseButtonDown(0)) {

                shoot();

            }

        });

    }

    // Update is called once per frame
    void shoot () {

        //
        // instantiante the bullet and fire it
        //

        Debug.Log("vamos a ver que ocurre");

        GameObject bullet = (GameObject)Instantiate(bulletPrefab, pistol.position, Quaternion.identity);

        bullet.GetComponent<Rigidbody>().velocity = pistol.forward * bulletSpeed;

	}
}
