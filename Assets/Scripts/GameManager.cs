using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    static GameManager instance;

    public static GameManager GetInstance()
    {
        return instance; 
    }

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public Action<GAME_STATE> onGameStateChanged;
    public GAME_STATE currentGameState;

    public void ChangeGameState(GAME_STATE _newGameState)
    {
        if(currentGameState == _newGameState) return;

        currentGameState = _newGameState;
        Debug.Log("Game state changed to: " + currentGameState);

        if(onGameStateChanged != null)
        {
            onGameStateChanged.Invoke(currentGameState);
        }
    }

    public Action<SKIN_SELECTED> onSkinChanged;
    public SKIN_SELECTED currentSkin;

    public void ChangeSkinState(SKIN_SELECTED _selectedSkin)
    {
        currentSkin = _selectedSkin;
        Debug.Log("Current skin: " + currentSkin);

        if(onSkinChanged != null)
        {
            onSkinChanged.Invoke(currentSkin);
        }
    }

    public void SkinBlue()
    {
        GameManager.GetInstance().ChangeSkinState(SKIN_SELECTED.BLUE);
    }

    public void SkinYellow()
    {
        GameManager.GetInstance().ChangeSkinState(SKIN_SELECTED.YELLOW);
    }

    public void SkinBlack()
    {
        GameManager.GetInstance().ChangeSkinState(SKIN_SELECTED.BLACK);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameManager.GetInstance().ChangeGameState(GAME_STATE.PLAY);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            GameManager.GetInstance().ChangeGameState(GAME_STATE.PAUSE);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            GameManager.GetInstance().ChangeGameState(GAME_STATE.GAME_OVER);
        }
    }
}

public enum GAME_STATE
{
    PLAY,
    PAUSE,
    GAME_OVER
}

public enum SKIN_SELECTED
{
    BLUE,
    YELLOW,
    BLACK
}
