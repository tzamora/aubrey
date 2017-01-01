using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using matnesis.TeaTime;


public class DoorController : MonoBehaviour {

    public List<SwitchController> requiredSwitches = new List<SwitchController>();

    public Transform endPosition;

	public AudioClip openDoorSound;

	// Use this for initialization
	void Start () {

		this.tt().Loop(delegate(ttHandler handler) {

            int numberOfButtonsPressed = requiredSwitches.Where(r => r.buttonIsPressed).Count();

            if (numberOfButtonsPressed == requiredSwitches.Count())
            {
                Debug.Log("abriendo puerta");
				SoundManager.Get.PlayClip(openDoorSound, false);
                openDoor();
                handler.EndLoop();
            }

			handler.Wait(0.3f);

        });


	}

    void openDoor() {

        Vector3 startPosition = transform.position;

        this.tt("openDoorRoutine").Loop(2f, delegate (ttHandler handler){

            transform.position = Vector3.Lerp(startPosition, endPosition.position, handler.t);

        });

    }
}
