using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerState : MonoBehaviour
{
    public enum GameState
    {
        MainMenu,
        Playing,
        Win,
        Fail
    }

    private GameState gameState;

    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.MainMenu;
    }

    // Update is called once per frame
    void Update()
    {
        switch (GameState.MainMenu)
        {
            case GameState.MainMenu:
                DisplayMainMenu();
                break;
            case GameState.Playing:
                break;
            case GameState.Win:
                break;
            case GameState.Fail:
                break;
            default:
                break;
        }
    }

    private void DisplayMainMenu()
    {

    }
}
