using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState2 { startGame, inGame, endGame }
public enum GameMode2 { mode1, mode2 }

public class GameManager2 : MonoBehaviour
{
    // diffrrent game status
    public GameState2 currentGameState = GameState2.startGame;
    public GameMode2 currentGameMode = GameMode2.mode2;


    // game menus
    public Canvas startGame;
    public Canvas inGame;
    public Canvas endGame;

    // player gameobject
    public GameObject player;

    // important values in the game
    int totalSessionNum = 0;
    int collectedCoinsOneSession = 0;
    int totalCollectedCoins = 0;
    public float spentTimeOneSession = 0.00f;
    public float totalTime = 0.00f;

    // shared instance for the game
    private static GameManager2 sharedInstance;
    private void Awake()
    {
        sharedInstance = this;
        PlayerPrefs.SetString("ChosenGame", "CollectCoinsBox");
    }

    public static GameManager2 GetInstane()
    {
        return sharedInstance;
    }

    // Start is called before the first frame update
    void Start()
    {
        totalSessionNum = 1;
        currentGameState = GameState2.startGame;
        startGame.enabled = true;
        inGame.enabled = false;
        endGame.enabled = false;
    }

    // Start our game
    public void StartGame()
    {

        collectedCoinsOneSession = 0;
        changeGameMode2(currentGameMode);
        changeGameState2(GameState2.inGame);
        GameView.GetInstane().SetTimerAndCoins();

    }


    // called when time ends or when click end game button
    public void GameOver()
    {
        // return player to start point
        player.transform.position = new Vector3(0, 0, 0);
        // store session time
        totalTime += spentTimeOneSession;
        // store collected coins
        totalCollectedCoins += collectedCoinsOneSession;
        changeGameState2(GameState2.endGame);
        EndGView.GetInstance().UpdateGui();

    }


    // called when player decides to quiet the game and go to the main menu
    // when need new session for same user
    public void BackToStartGame()
    {


        totalSessionNum++;

        changeGameState2(GameState2.startGame);

    }

    public void GoToSaveData()
    {
        PlayerPrefs.SetFloat("Time", totalTime);
        PlayerPrefs.SetInt("Coins", totalCollectedCoins);
        PlayerPrefs.SetString("GM0 State", "saveData");
        SceneManager.LoadScene(0);
    }


    void changeGameState2(GameState2 newGameState)
    {

        switch (newGameState)
        {
            case GameState2.startGame:
                // let's load main menu scene
                startGame.enabled = true;
                inGame.enabled = false;
                endGame.enabled = false;
                break;

            case GameState2.inGame:
                // unity Scene must show the real game 
                startGame.enabled = false;
                inGame.enabled = true;
                endGame.enabled = false;
                break;

            case GameState2.endGame:
                // let's load end of the game scene
                startGame.enabled = false;
                inGame.enabled = false;
                endGame.enabled = true;
                break;

            default:
                newGameState = GameState2.startGame;
                break;
        }

        currentGameState = newGameState;
    }



    public void changeGameMode2(GameMode2 newGameMode)
    {

        switch (newGameMode)
        {
            case GameMode2.mode1:
                // let's load main menu scene
                player.GetComponent<PlayerFollowCoins2>().enabled = true;
                player.GetComponent<FollowMouse>().enabled = false;
                break;

            case GameMode2.mode2:
                // unity Scene must show the real game 
                player.GetComponent<PlayerFollowCoins2>().enabled = false;
                player.GetComponent<FollowMouse>().enabled = true;
                break;

            default:
                newGameMode = GameMode2.mode2;
                break;
        }

        currentGameMode = newGameMode;
    }



    //Collect Coins function used to update coins number
    public void CollectCoins()
    {
        collectedCoinsOneSession++;
        GameView.GetInstane().UpdateCoin();
    }

    // update session time from in game view
    public void UpdateSpentTime()
    {
        spentTimeOneSession = 60.0f - GameView.GetInstane().timeStart;
    }

    public int GetCollectedCoins()
    {
        return collectedCoinsOneSession;
    }

    public int GetTotalCollectedCoins()
    {
        return totalCollectedCoins;
    }

    public int GetSessionNum()
    {
        return totalSessionNum;
    }

    public float GetTotalTime()
    {
        return totalTime;
    }

    public float GetTime()
    {
        return spentTimeOneSession;
    }
}
