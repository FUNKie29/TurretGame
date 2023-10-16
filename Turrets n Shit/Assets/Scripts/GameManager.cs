using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Playing,
        GameOver
    }
    GameState currentGameState;

    // Start is called before the first frame update
    void Start()
    {
        currentGameState = GameState.Playing;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
