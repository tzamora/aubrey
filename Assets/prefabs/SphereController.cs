using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour {

    public ColliderController greenZoneCollider;

    public ColliderController redZoneCollider;

    public ColliderController blackZoneCollider;

    public ColliderController blueZoneCollider;

    // Use this for initialization
    void Start () {

        greenZoneCollider.TriggerEnter += GreenZoneCollider_TriggerEnter;

        blackZoneCollider.TriggerEnter += BlackZoneCollider_TriggerEnter;

        blueZoneCollider.TriggerEnter += BlueZoneCollider_TriggerEnter;

        redZoneCollider.TriggerEnter += RedZoneCollider_TriggerEnter;



    }

    private void RedZoneCollider_TriggerEnter(Collider other)
    {
        BulletController bullet = other.GetComponent<BulletController>();

        if (bullet != null)
        {
            if (bullet.bulletType == BulletController.BulletTypeEnum.Red) {
                Destroy(redZoneCollider.gameObject);
            }
        }
    }

    private void BlueZoneCollider_TriggerEnter(Collider other)
    {
        BulletController bullet = other.GetComponent<BulletController>();

        if (bullet != null)
        {
            if (bullet.bulletType == BulletController.BulletTypeEnum.Blue)
            {
                Destroy(blueZoneCollider.gameObject);
            }
        }
    }

    private void BlackZoneCollider_TriggerEnter(Collider other)
    {
        BulletController bullet = other.GetComponent<BulletController>();

        if (bullet != null)
        {
            if (bullet.bulletType == BulletController.BulletTypeEnum.Black)
            {
                Destroy(blackZoneCollider.gameObject);
            }
        }
        
    }

    private void GreenZoneCollider_TriggerEnter(Collider other)
    {
        BulletController bullet = other.GetComponent<BulletController>();

        if (bullet != null)
        {
            if (bullet.bulletType == BulletController.BulletTypeEnum.Yellow)
            {
                Destroy(greenZoneCollider.gameObject);
            }
        }
    }
}
