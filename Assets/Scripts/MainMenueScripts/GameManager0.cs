using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public enum GameState0 { Welcome, srr, signIn, choseGame, saveData, goodBye }
public enum UserState { registered, guest }

public class GameManager0 : MonoBehaviour
{

    public Canvas welcome;
    public Canvas srr;
    public Canvas signIn;
    public Canvas choseGame;
    public Canvas saveData;
    public Canvas goodBye;

    public GameState0 currentGameState = GameState0.Welcome;
    public UserState currentUserState;

    public string userName;
    public string password;

    public float time;
    public int coins;

    public bool welcomeBool = false;
    public bool srrBool = false;
    public bool exitBool = false;

    private static GameManager0 sharedInstance;
    private void Awake()
    {
        sharedInstance = this;
    }

    public static GameManager0 GetInstane()
    {
        return sharedInstance;
    }

    // Start is called before the first frame update
    void Start()
    {

        currentGameState = GameState0.Welcome;
        welcome.enabled = true;
        welcomeBool = true;
        srr.enabled = false;
        signIn.enabled = false;
        choseGame.enabled = false;
        saveData.enabled = false;
        goodBye.enabled = false;

        try
        {
            print(PlayerPrefs.GetString("UserName"));
            if (PlayerPrefs.GetString("UserName").Equals("guest"))
            {
                currentUserState = UserState.guest;
            }
            if (PlayerPrefs.GetString("GM0 State").Equals("saveData") && Time.time != 0)
            {
                changeGameState(GameState0.saveData);
            }
            
        }
        catch (Exception e)
        {
            print(e);
        }


    }

    public void GoToGame1()
    {
        SceneManager.LoadScene("Game1");
    }
    public void GoToGame2L1()
    {
        SceneManager.LoadScene("Game2Level1");
    }

    public void GoToGame2L2()
    {
        SceneManager.LoadScene("Game2Level2");
    }

    public void GoToSRR()
    {
        welcomeBool = false;
        srrBool = true;
        changeGameState(GameState0.srr);
    }

    public void GoToSignIn()
    {
        srrBool = false;
        PlayerPrefs.DeleteKey("UserName");
        PlayerPrefs.DeleteKey("Time");
        PlayerPrefs.DeleteKey("Coins");
        PlayerPrefs.DeleteKey("GM0 State");
        PlayerPrefs.DeleteKey("ChosenGame");
        PlayerPrefs.DeleteKey("session_id");
        PlayerPrefs.DeleteKey("patient_id");
        changeGameState(GameState0.signIn);
    }

    public void GoToChoseGame()
    {
        changeGameState(GameState0.choseGame);
    }

    public void GoToSaveData()
    {
        changeGameState(GameState0.saveData);
    }

    public void GoToGoodBye()
    {
        exitBool = true;
        PlayerPrefs.DeleteKey("UserName");
        PlayerPrefs.DeleteKey("Time");
        PlayerPrefs.DeleteKey("Coins");
        changeGameState(GameState0.goodBye);
    }

    public void Exit()
    {
        Application.Quit();
    }


    void changeGameState(GameState0 newGameState)
    {

        switch (newGameState)
        {
            case GameState0.Welcome:
                // let's load main menu scene
                welcome.enabled = true;
                srr.enabled = false;
                signIn.enabled = false;
                choseGame.enabled = false;
                saveData.enabled = false;
                goodBye.enabled = false;
                welcome.GetComponent<Welcome>().enabled = true;
                srr.GetComponent<Srr>().enabled = false;
                break;

            case GameState0.srr:
                // unity Scene must show the real game 
                welcome.enabled = false;
                srr.enabled = true;
                signIn.enabled = false;
                choseGame.enabled = false;
                saveData.enabled = false;
                goodBye.enabled = false;
                welcome.GetComponent<Welcome>().enabled = false;
                srr.GetComponent<Srr>().enabled = true;
                break;

            case GameState0.signIn:
                // let's load end of the game scene
                welcome.enabled = false;
                srr.enabled = false;
                signIn.enabled = true;
                choseGame.enabled = false;
                saveData.enabled = false;
                goodBye.enabled = false;
                welcome.GetComponent<Welcome>().enabled = false;
                srr.GetComponent<Srr>().enabled = false;
                break;

            case GameState0.choseGame:
                // let's load end of the game scene
                welcome.enabled = false;
                srr.enabled = false;
                signIn.enabled = false;
                choseGame.enabled = true;
                saveData.enabled = false;
                goodBye.enabled = false;
                welcome.GetComponent<Welcome>().enabled = false;
                srr.GetComponent<Srr>().enabled = false;
                break;

            case GameState0.saveData:
                // let's load end of the game scene
                welcome.enabled = false;
                srr.enabled = false;
                signIn.enabled = false;
                choseGame.enabled = false;
                saveData.enabled = true;
                goodBye.enabled = false;
                welcome.GetComponent<Welcome>().enabled = false;
                srr.GetComponent<Srr>().enabled = false;
                break;

            case GameState0.goodBye:
                // let's load end of the game scene
                welcome.enabled = false;
                srr.enabled = false;
                signIn.enabled = false;
                choseGame.enabled = false;
                saveData.enabled = false;
                goodBye.enabled = true;
                welcome.GetComponent<Welcome>().enabled = false;
                srr.GetComponent<Srr>().enabled = false;
                break;

            default:
                newGameState = GameState0.Welcome;
                break;
        }

        currentGameState = newGameState;
    }
}
