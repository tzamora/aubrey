using UnityEngine;
using System;
using System.Collections;
using matnesis.TeaTime;

public class TotemController : MonoBehaviour
{
    public int hp = 3;

    public GameObject LittleHead;

    public GameObject totemBody;

    public BulletController.BulletTypeEnum bulletType;

    public GameObject bulletOrbPrefab;

    public int bulletsToSpawn;

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

        BulletController bullet = collision.gameObject.GetComponent<BulletController>();

        if (bullet) {
            handleDamage(bullet);
        }

    }

    void handleDamage(BulletController bullet){

        //
        // remove one point damage 
        //

        hp--;

        if (hp <= 0) {

            destroyTotem();
        }

        //
        // damage animation
        //

        Color totemDefaultColor = totemBody.GetComponent<Renderer>().material.color;

        this.tt("damageAnimation").Add(delegate() {

            totemBody.GetComponent<Renderer>().material.color = Color.red;

        }).Add(0.1f, delegate() {

            totemBody.GetComponent<Renderer>().material.color = totemDefaultColor;

        });

    }

    void destroyTotem() {

        //
        // spawn bullets
        //

        int repeatCounter = 0;

        Debug.Log("---->" + repeatCounter);

        this.tt("spawnRoutine").Loop(100f, delegate (ttHandler handler){

            GameObject bulletOrb = (GameObject)Instantiate(bulletOrbPrefab, transform.position + new Vector3(0f, 2f, 0f), Quaternion.identity);

            bulletOrb.GetComponent<BulletOrbController>().SetBullet(bulletType);

            bulletOrb.GetComponent<Rigidbody>().AddForce(Vector3.up * 100f);

            repeatCounter++;

            Debug.Log("---->" + repeatCounter);

            if (repeatCounter > bulletsToSpawn) {
                handler.EndLoop();
            }

        }).Add(delegate() {
            Destroy(gameObject);
        });
    }
}

