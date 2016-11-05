using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class TestSceneUIController : MonoBehaviour {

    public Button dieButton;

    // Use this for initialization
    void Start()
    {

        dieButton.onClick.AddListener(delegate () {

            Debug.Log("vamos a ver que pasa");

            SceneManager.LoadScene("StartScene");
        });

    }
}
