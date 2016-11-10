using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartUIController : MonoBehaviour {

    public Button startButton;
	public Button aboutButton;

	// Use this for initialization
	void Start () {

		startButton.onClick.AddListener(delegate() {

            Application.LoadLevel("el-test");

        });

		aboutButton.onClick.AddListener(delegate() {

			Application.LoadLevel("AboutSceen");

		});

	}
}
