using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using matnesis.TeaTime;

public class PlatformController : MonoBehaviour
{
    public List<SwitchController> requiredSwitches;

    public Transform endPosition;
    
    // Use this for initialization
    void Start()
    {

        this.tt("checkSwitchesRoutine").Loop(300f, delegate (ttHandler handler) {

            requiredSwitches.ForEach(delegate (SwitchController switchC) {

                //Debug.Log(switchC.buttonIsPressed);

            });

            bool stillPending = requiredSwitches.Any(r => !r.buttonIsPressed);

            if (!stillPending)
            {
                openDoor();
                handler.EndLoop();

            }

        });


    }

    void openDoor()
    {

        Vector3 startPosition = transform.position;

        this.tt("openDoorRoutine").Loop(2f, delegate (ttHandler handler) {

            transform.position = Vector3.Lerp(startPosition, endPosition.position, handler.t);

        });

    }

    void OnCollisionEnter(Collision collision)
    {

        PlayerController player = collision.gameObject.GetComponent<PlayerController>();

        Debug.Log(player);

        if (player)
        {
            player.transform.parent = transform;
        }

    }


    void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        Debug.Log(player);

        if (player)
        {
            player.transform.parent = transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        if (player)
        {
            Debug.Log("salio");

            player.transform.parent = null;
        }
    }
    
}