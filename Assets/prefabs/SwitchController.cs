using UnityEngine;
using System;
using System.Collections;
using matnesis.TeaTime;

public class SwitchController : MonoBehaviour
{
    public BulletController.BulletTypeEnum bulletType;

    public GameObject body;

    // Use this for initialization
    void Start()
    {
        rotateSwitchRoutine();

        setSwitchType(bulletType);

    }

    void setSwitchType(BulletController.BulletTypeEnum bType) {

        switch (bType) {
            case BulletController.BulletTypeEnum.None:
                body.GetComponent<Renderer>().material.color = Color.green;
                break;
            case BulletController.BulletTypeEnum.Black:
                body.GetComponent<Renderer>().material.color = Color.black;
                break;
            case BulletController.BulletTypeEnum.Red:
                body.GetComponent<Renderer>().material.color = Color.red;
                break;
            case BulletController.BulletTypeEnum.Blue:
                body.GetComponent<Renderer>().material.color = Color.blue;
                break;
            case BulletController.BulletTypeEnum.Yellow:
                body.GetComponent<Renderer>().material.color = Color.yellow;
                break;
        }

    }

    void rotateSwitchRoutine()
    {
        this.tt("rotateSwitchRoutine").Loop(delegate (ttHandler handler)
        {
            float rotationSpeed = 2f;

            body.transform.Rotate(new Vector3(0f, 1f, 0f) * rotationSpeed);

        });
    }

    void OnCollisionEnter(Collision collision)
    {
        //
        // first detect that it is a bullet
        //

        BulletController bullet = collision.gameObject.GetComponent<BulletController>();

        if (bullet)
        {
            handleHit(bullet);
        }

    }

    void handleHit(BulletController bullet) {

        if (this.bulletType == BulletController.BulletTypeEnum.None)
        {
            //
            // hit
            //

            Destroy(gameObject);
        }
        else if (bullet.bulletType == this.bulletType)
        {

            //
            // hit
            //

            Destroy(gameObject);
        }
        else
        {

            //
            // miss
            //

        }
    }
}
