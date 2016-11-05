using UnityEngine;
using System.Collections;
using System.Linq;

public class BulletOrbController : MonoBehaviour {

    public BulletController.BulletTypeEnum bulletType;

    public Material[] bulletMaterials;

    public GameObject[] bodyGameobjects;

    // Use this for initialization
    void Start () {

        //
        // init the main type
        //

        SetBullet(bulletType);

	}

    void OnTriggerEnter(Collider other){
        
        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        if (player)
        {
            player.addBullet(bulletType);

            Destroy(gameObject);
        }
    }

    public void SetBullet(BulletController.BulletTypeEnum bulletType)
    {
        if (bulletType == BulletController.BulletTypeEnum.Black)
        {
            foreach (Renderer renderer in bodyGameobjects.Select(b => b.GetComponent<Renderer>())){
                renderer.material = bulletMaterials[0];
            }

            bulletType = BulletController.BulletTypeEnum.Black;
        }

        if (bulletType == BulletController.BulletTypeEnum.Blue)
        {
            foreach (Renderer renderer in bodyGameobjects.Select(b => b.GetComponent<Renderer>()))
            {
                renderer.material = bulletMaterials[1];
            }

            bulletType = BulletController.BulletTypeEnum.Blue;
        }

        if (bulletType == BulletController.BulletTypeEnum.Red)
        {
            foreach (Renderer renderer in bodyGameobjects.Select(b => b.GetComponent<Renderer>()))
            {
                renderer.material = bulletMaterials[2];
            }

            bulletType = BulletController.BulletTypeEnum.Red;
        }

        if (bulletType == BulletController.BulletTypeEnum.Yellow)
        {
            foreach (Renderer renderer in bodyGameobjects.Select(b => b.GetComponent<Renderer>()))
            {
                renderer.material = bulletMaterials[3];
            }

            bulletType = BulletController.BulletTypeEnum.Yellow;
        }
    }

}
