using UnityEngine;
using System.Collections;
using matnesis.TeaTime;

public class GameManager : MonoSingleton<GameManager> {

    public PlayerController player;

    public Vector3 LastCheckPoint;

    //
    // guarantee this will be always a singleton only - can't use the constructor!
    //
    protected GameManager() {

    }

}
