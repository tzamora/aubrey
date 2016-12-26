using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayerColliderController : MonoBehaviour {

    public ColliderController killPlayerCollider;

    // Use this for initialization
    void Start () {
        killPlayerCollider.TriggerEnter += KillPlayerCollider_TriggerEnter;

    }

    private void KillPlayerCollider_TriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>() != null)
        {
            toCheckPoint();
        }
    }

    void toCheckPoint()
    {
        GameManager.Get.player.transform.position = GameManager.Get.LastCheckPoint;
    }
}
