using UnityEngine;
using System;
using System.Collections;
using matnesis.TeaTime;

public class TotemController : MonoBehaviour
{
    public int hp = 3;

    public GameObject LittleHead;

    public GameObject totemBody;

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

        //
        // drop bullets animation
        //

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

        //
        // destroy animation
        //

        Destroy(gameObject);
    }
}

