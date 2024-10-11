using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject pauseScreen;
    
    void Start()
    {
        pauseScreen.SetActive(false);
        GameManager.GetInstance().onGameStateChanged += OnGameStateChanged;
    }

    void OnGameStateChanged(GAME_STATE _newGameState)
    {
        pauseScreen.SetActive(_newGameState == GAME_STATE.PAUSE);
        /*
        if(_newGameState == GAME_STATE.PAUSE)
        {
            pauseScreen.SetActive(true);
        }
        else
        {
            pauseScreen.SetActive(false);
        }*/
    }
}
