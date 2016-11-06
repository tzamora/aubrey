using UnityEngine;
using System.Collections;

public class GameManager : MonoSingleton<GameManager> {

    public PlayerController player;

    //
    // guarantee this will be always a singleton only - can't use the constructor!
    //
    protected GameManager() {

    } 

}
