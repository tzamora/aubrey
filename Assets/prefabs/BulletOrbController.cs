using UnityEngine;
using System.Collections;
using System.Linq;

public class BulletOrbController : MonoBehaviour {

    public BulletController.BulletTypeEnum currentBulletType;

    public Material[] bulletMaterials;

    public GameObject[] bodyGameobjects;

    public AudioClip pickItem;

    // Use this for initialization
    void Start () {

        //
        // init the main type
        //

        SetBullet(currentBulletType);

	}

    void OnCollisionEnter(Collision collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();

        if (player)
        {
            SoundManager.Get.PlayClip(pickItem, false);

            player.addBullet(currentBulletType);

            Destroy(gameObject);
        }
    }
    
    public void SetBullet(BulletController.BulletTypeEnum bulletType)
    {
        currentBulletType = bulletType;

        if (bulletType == BulletController.BulletTypeEnum.Black)
        {
            foreach (Renderer renderer in bodyGameobjects.Select(b => b.GetComponent<Renderer>())){
                renderer.material = bulletMaterials[0];
            }
        }

        if (bulletType == BulletController.BulletTypeEnum.Blue)
        {
            foreach (Renderer renderer in bodyGameobjects.Select(b => b.GetComponent<Renderer>()))
            {
                renderer.material = bulletMaterials[1];
            }
        }

        if (bulletType == BulletController.BulletTypeEnum.Red)
        {
            foreach (Renderer renderer in bodyGameobjects.Select(b => b.GetComponent<Renderer>()))
            {
                renderer.material = bulletMaterials[2];
            }
        }

        if (bulletType == BulletController.BulletTypeEnum.Yellow)
        {
            foreach (Renderer renderer in bodyGameobjects.Select(b => b.GetComponent<Renderer>()))
            {
                renderer.material = bulletMaterials[3];
            }
        }
    }

}
