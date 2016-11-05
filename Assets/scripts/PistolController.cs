using UnityEngine;
using System.Collections;

public class PistolController : MonoBehaviour {

    public enum BulletTypeEnum { Black, Blue, Red, Yellow };

    public GameObject bulletPrefab;

    public float bulletSpeed = 50f;

    // Use this for initialization
    void Start () {
	
	}

    public void shoot(){

        //
        // instantiante the bullet and fire it
        //

        GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        bullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;

    }
}
