using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using matnesis.TeaTime;

public class PlatformController : MonoBehaviour
{
    public List<SwitchController> requiredSwitches = new List<SwitchController>();

    public List<Transform> platformPositions;

	public List<int> switchesToProgress;

	private int currentProgressPosition = 0;

    public int platformTime = 2;
    
    // Use this for initialization
    void Start()
    {
		currentProgressPosition = 0;

		checkSwitchesRoutine ();
    }

	void checkSwitchesRoutine()
	{

        this.tt("checkSwitchesRoutine").Add(0.3f, delegate (ttHandler handler) {

            int numberOfButtonsPressed = requiredSwitches.Where(r => r.buttonIsPressed).ToList().Count(); ;

			List<Transform> orderedPlatformPositions = platformPositions.OrderBy(p => p.transform.position.y).ToList();

			switchesToProgress.Sort();

			for(int i = 0; i < switchesToProgress.Count; i++)
			{
				if(numberOfButtonsPressed == switchesToProgress[i])
				{
					bool differentProgressPosition = currentProgressPosition != i;

					

					if(differentProgressPosition)
					{
						movePlatform(orderedPlatformPositions[i].position);

						currentProgressPosition = i;

						break;

					}
				}
				else if(numberOfButtonsPressed < switchesToProgress[currentProgressPosition])
				{

					bool differentProgressPosition = currentProgressPosition != currentProgressPosition - 1;

					if(differentProgressPosition)
					{
						movePlatform(orderedPlatformPositions[currentProgressPosition - 1].position);

						currentProgressPosition = currentProgressPosition - 1;

						break;

					}

				}
			}

		}).Repeat();
	}

	void movePlatform(Vector3 newPosition)
    {

        Vector3 startPosition = transform.position;

        this.tt("openDoorRoutine").Reset().Loop(platformTime, delegate (ttHandler handler) {

			transform.position = Vector3.Lerp(startPosition, newPosition, handler.t);

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
            player.transform.parent = null;
        }
    }
}