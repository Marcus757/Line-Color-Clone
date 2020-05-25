using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public GameObject player;
    public GameObject mainMenu;
    public GameObject winMenu;
    public GameObject failMenu;
    public Camera primaryCamera;
    public Camera secondaryCamera;
    public GameObject cameraRotator;
    public GameObject treasureChest;
    private GameState gameState;
    

    public enum GameState
    {
        MainMenu,
        Playing,
        Win,
        Fail
    }



    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.MainMenu;
    }

    // Update is called once per frame
    void Update()
    {
        switch (gameState)
        {
            case GameState.MainMenu:
                DisplayMainMenu();
                WaitForInput();
                break;
            case GameState.Playing:
                EnablePlayer();
                break;
            case GameState.Win:
                DisplayWinMenu();
                SwitchCamera();
                StartCoroutine(PlayAnimations());
                break;
            case GameState.Fail:
                DisplayFailMenu();
                break;
            default:
                break;
        }
    }

    private void DisplayMainMenu()
    {
        if (!mainMenu.activeSelf)
            mainMenu.SetActive(true);
    }

    private void WaitForInput()
    {

        if (Input.touchCount > 0)
            StartCoroutine(SwitchGameState(GameState.Playing));

#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
            StartCoroutine(SwitchGameState(GameState.Playing));
#endif
    }

    private void EnablePlayer()
    {
        if (mainMenu.activeSelf)
            mainMenu.SetActive(false);

        if (!player.activeSelf)
        {
            gameState = GameState.Fail;
            StartCoroutine(SwitchGameState(GameState.Fail));
            return;
        }

        //if (!player.GetComponent<FollowCreatedPath>().isActiveAndEnabled)
        //    player.GetComponent<FollowCreatedPath>().enabled = true;

        if (player.GetComponent<FollowCreatedPath>().isPathCompleted)
            StartCoroutine(SwitchGameState(GameState.Win));
    }

    private void DisplayWinMenu()
    {
        winMenu.SetActive(true);
    }

    private void DisplayFailMenu()
    {
        if (!failMenu.activeSelf)
        {
            failMenu.SetActive(true);
            UpdatePercentageCompleted();
        }

        if (Input.touchCount > 0)
        {
            failMenu.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            failMenu.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
#endif
    }

    IEnumerator SwitchGameState(GameState state)
    {
        yield return new WaitForSeconds(.5f);
        gameState = state;
    }

    private void UpdatePercentageCompleted()
    {
        int percent = player.GetComponent<FollowCreatedPath>().GetPercentageComplete();

        GameObject percentageComplete = failMenu.transform.Find("PercentComplete").gameObject;
        percentageComplete.GetComponent<TextMeshProUGUI>().text = percent + "% COMPLETED";
    }

    private void SwitchCamera()
    {
        if (primaryCamera.enabled)
        {
            primaryCamera.enabled = false;
            secondaryCamera.enabled = true;
            cameraRotator.GetComponent<Rotate>().enabled = true;
        }

    }

    private void PlayOpenChestAnimation()
    {
        treasureChest.GetComponent<TreasureChest>().PlayOpenChestAnimation();
    }
    
    private void PlayTreasureChestShakeAnimation()
    {
        treasureChest.GetComponent<TreasureChest>().PlayTreasureChestShakeAnimation();
    }

    IEnumerator PlayAnimations()
    {
        PlayTreasureChestShakeAnimation();
        yield return new WaitForSeconds(5);
        PlayOpenChestAnimation();
    }
}
