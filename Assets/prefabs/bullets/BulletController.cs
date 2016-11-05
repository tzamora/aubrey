using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

    public enum BulletTypeEnum { Black, Blue, Red, Yellow };

    public Material[] bulletMaterials;

    public BulletTypeEnum bulletType;

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("kill this mofo");
        Destroy(gameObject);
    }
}
