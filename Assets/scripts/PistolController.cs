﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PistolController : MonoBehaviour {

    public enum BulletTypeEnum { Black, Blue, Red, Yellow };

    public Dictionary<BulletController.BulletTypeEnum, int> bulletsCounter;

    public Material[] bulletMaterials;

    public BulletController currentBulletPrefab;

    public float bulletSpeed = 50f;

    public  TextMesh pistolText;


    // Use this for initialization
    void Start () {

        bulletsCounter = new Dictionary<BulletController.BulletTypeEnum, int>();

        bulletsCounter[BulletController.BulletTypeEnum.Black] = 0;
        bulletsCounter[BulletController.BulletTypeEnum.Blue] = 0;
        bulletsCounter[BulletController.BulletTypeEnum.Red] = 0;
        bulletsCounter[BulletController.BulletTypeEnum.Yellow] = 0;

        pistolText.text = "∞";

        SetBullet(BulletTypeEnum.Black);

    }

    public void shoot(){

        //
        // instantiante the bullet and fire it
        //

        bool isInfiniteBullet = currentBulletPrefab.bulletType == BulletController.BulletTypeEnum.Black;

        if (bulletsCounter[currentBulletPrefab.bulletType] > 0 || isInfiniteBullet) {

            GameObject bullet = (GameObject)Instantiate(currentBulletPrefab.gameObject, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;

        }

        
    }

    public void addBullet(BulletController.BulletTypeEnum bulletType)
    {
        bulletsCounter[bulletType]++;

        //
        // update if we see the current bullet being
        //

        if (currentBulletPrefab.bulletType == bulletType) {
            pistolText.text = "" + bulletsCounter[bulletType];
        }

        
    }

    public void SetBullet(BulletTypeEnum bulletType){

        if (bulletType == BulletTypeEnum.Black) {

            pistolText.color = Color.black;

            pistolText.text = "∞";

            currentBulletPrefab.GetComponent<Renderer>().material = bulletMaterials[0];

            currentBulletPrefab.bulletType = BulletController.BulletTypeEnum.Black;

            currentBulletPrefab.GetComponent<TrailRenderer>().sharedMaterial.SetColor("_EmissionColor", new Color(0.0f, 0.0f, 0.0f));
        }

        if (bulletType == BulletTypeEnum.Blue){

            pistolText.color = Color.blue;

            pistolText.text = "" + bulletsCounter[BulletController.BulletTypeEnum.Blue];

            currentBulletPrefab.GetComponent<Renderer>().material = bulletMaterials[1];

            currentBulletPrefab.bulletType = BulletController.BulletTypeEnum.Blue;

            currentBulletPrefab.GetComponent<TrailRenderer>().sharedMaterial.SetColor("_EmissionColor", new Color(0.0f, 0.0f, 1.0f));
        }

        if (bulletType == BulletTypeEnum.Red){

            pistolText.color = Color.red;

            pistolText.text = "" + bulletsCounter[BulletController.BulletTypeEnum.Red];

            currentBulletPrefab.GetComponent<Renderer>().material = bulletMaterials[2];

            currentBulletPrefab.bulletType = BulletController.BulletTypeEnum.Red;

            currentBulletPrefab.GetComponent<TrailRenderer>().sharedMaterial.SetColor("_EmissionColor", new Color(1.0f, 0.0f, 0.0f));
        }

        if (bulletType == BulletTypeEnum.Yellow)
        {
            pistolText.color = Color.yellow;

            pistolText.text = "" + bulletsCounter[BulletController.BulletTypeEnum.Yellow];

            currentBulletPrefab.GetComponent<Renderer>().material = bulletMaterials[3];

            currentBulletPrefab.bulletType = BulletController.BulletTypeEnum.Yellow;

            currentBulletPrefab.GetComponent<TrailRenderer>().sharedMaterial.SetColor("_EmissionColor", new Color(1.0f, 1.0f, 0.0f));
        }
    }
}
