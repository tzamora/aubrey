using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using matnesis.TeaTime;

public class SwitchController : MonoBehaviour
{
    public BulletController.BulletTypeEnum bulletType;

    public List<GameObject> body;

    public bool buttonIsPressed;

    public Animator animator;

	public AudioClip pressedSound;

    // Use this for initialization
    void Start()
    {
        setSwitchType(bulletType);
    }

    void setSwitchType(BulletController.BulletTypeEnum bType) {

        switch (bType) {
            case BulletController.BulletTypeEnum.None:
                body.ForEach(delegate (GameObject go) {
                    go.GetComponent<Renderer>().material.color = Color.gray;
                });
                break;
            case BulletController.BulletTypeEnum.Black:
                body.ForEach(delegate (GameObject go) {
                    go.GetComponent<Renderer>().material.color = Color.black;
                });
                break;
            case BulletController.BulletTypeEnum.Red:
                body.ForEach(delegate (GameObject go) {
                    go.GetComponent<Renderer>().material.color = Color.red;
                });
                break;
            case BulletController.BulletTypeEnum.Blue:
                body.ForEach(delegate (GameObject go) {
                    go.GetComponent<Renderer>().material.color = Color.blue;
                });
                break;
            case BulletController.BulletTypeEnum.Yellow:
                body.ForEach(delegate (GameObject go) {
                    go.GetComponent<Renderer>().material.color = Color.yellow;
                });
                break;
        }

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
            if (!buttonIsPressed)
            {

                buttonIsPressed = true;
                animator.SetTrigger("pressButton");

            } else {

                buttonIsPressed = false;
                animator.SetTrigger("unpressButton");

            }
        }
        else if (bullet.bulletType == this.bulletType)
        {

            //
            // hit
            //

            if (!buttonIsPressed)
            {

                buttonIsPressed = true;

                animator.SetTrigger("pressButton");

                GameManager.Get.player.pistol.bulletsCounter[bulletType]--;

                GameManager.Get.player.pistol.pistolText.text = "" + GameManager.Get.player.pistol.bulletsCounter[bulletType];

				SoundManager.Get.PlayClip (pressedSound, false);

            }

        }
        else
        {

            //
            // miss
            //

        }
    }
}
