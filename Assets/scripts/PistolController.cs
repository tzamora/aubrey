using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PistolController : MonoBehaviour {

    public enum BulletTypeEnum { Black, Blue, Red, Yellow };

    public Material[] bulletMaterials;

    public BulletController bulletPrefab;

    public float bulletSpeed = 50f;

    // Use this for initialization
    void Start () {
	
	}

    public void shoot(){

        //
        // instantiante the bullet and fire it
        //

        GameObject bullet = (GameObject)Instantiate(bulletPrefab.gameObject, transform.position, Quaternion.identity);

        bullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
    }

    public void SetBullet(BulletTypeEnum bulletType){

        if (bulletType == BulletTypeEnum.Black) {

            bulletPrefab.GetComponent<Renderer>().material = bulletMaterials[0];

            bulletPrefab.bulletType = BulletController.BulletTypeEnum.Black;

            bulletPrefab.GetComponent<TrailRenderer>().sharedMaterial.SetColor("_EmissionColor", new Color(0.0f, 0.0f, 0.0f));
        }

        if (bulletType == BulletTypeEnum.Blue){

            bulletPrefab.GetComponent<Renderer>().material = bulletMaterials[1];

            bulletPrefab.bulletType = BulletController.BulletTypeEnum.Red;

            bulletPrefab.GetComponent<TrailRenderer>().sharedMaterial.SetColor("_EmissionColor", new Color(0.0f, 0.0f, 1.0f));
        }

        if (bulletType == BulletTypeEnum.Red){

            bulletPrefab.GetComponent<Renderer>().material = bulletMaterials[2];

            bulletPrefab.bulletType = BulletController.BulletTypeEnum.Red;

            bulletPrefab.GetComponent<TrailRenderer>().sharedMaterial.SetColor("_EmissionColor", new Color(1.0f, 0.0f, 0.0f));
        }

        if (bulletType == BulletTypeEnum.Yellow)
        {

            bulletPrefab.GetComponent<Renderer>().material = bulletMaterials[3];

            bulletPrefab.bulletType = BulletController.BulletTypeEnum.Red;

            //bullet.GetComponent<TrailRenderer>().material.SetColor("_EmissionColor", Color.red);

            bulletPrefab.GetComponent<TrailRenderer>().sharedMaterial.SetColor("_EmissionColor", new Color(1.0f, 1.0f, 0.0f));
        }
    }
}
