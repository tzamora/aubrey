using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

    public enum BulletTypeEnum { Black, Blue, Red, Yellow, None };

    public Material[] bulletMaterials;

    public BulletTypeEnum bulletType;

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
