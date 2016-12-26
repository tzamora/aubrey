using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointsController : MonoBehaviour {

    public ColliderController checkPointCollider;

	// Use this for initialization
	void Start () {
        checkPointCollider.TriggerEnter += delegate (Collider other)
        {
            if (other.GetComponent<PlayerController>() != null) {
                saveCheckPoint();
            }
        };

    }

    void saveCheckPoint() {

        GameManager.Get.LastCheckPoint = transform.position;

    }
}
