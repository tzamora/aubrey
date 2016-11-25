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

    public bool destroyed = false;

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

            if(LittleHead)
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

        if (destroyed)
        {
            return;
        }

        if (hp <= 0) {
            destroyTotem();
        }

        //
        // remove one point damage 
        //

        hp--;

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

        destroyed = true;

        //
        // spawn bullets
        //

        int repeatCounter = 1;

        Vector3 headPosition = LittleHead.transform.position;

        Destroy(LittleHead);

        this.tt("spawnRoutine").Loop(delegate (ttHandler handler){

            int side = repeatCounter % 4;

            print("viene el side");
            print(side);



            GameObject bulletOrb = (GameObject)Instantiate(bulletOrbPrefab, headPosition + new Vector3(0f, 0.25f, 0f), Quaternion.identity);

            bulletOrb.GetComponent<BulletOrbController>().SetBullet(bulletType);

            Vector3 direction = Vector3.zero;

            switch (side) {
                case 0 :
                    direction = Vector3.right;
                    break;
                case 1:
                    direction = Vector3.forward;
                    break;
                case 2:
                    direction = Vector3.left;
                    break;
                case 3:
                    direction = Vector3.back;
                    break;
            }

            bulletOrb.GetComponent<Rigidbody>().AddForce( (Vector3.up + direction)* 100f);

            repeatCounter++;

            handler.Wait(0.3f);

            if (repeatCounter > bulletsToSpawn) {
                handler.EndLoop();
            }

        }).Add(delegate() {
            Destroy(gameObject);
        });
    }
}

