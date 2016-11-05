using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartUIController : MonoBehaviour {

    public Button startButton;

	// Use this for initialization
	void Start () {

        startButton.onClick.AddListener(delegate() {

            Debug.Log("vamos a ver que pasa");

            Application.LoadLevel("TestScene");

        });

	}
}
