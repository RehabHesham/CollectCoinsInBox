using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour
{
    public Text remainTime;
    public Text coinsNum;

    public float timeStart = 60;
    //bool startTimer = false;


    private static GameView sharedInstance;
    public static GameView GetInstane()
    {
        return sharedInstance;
    }
    private void Awake()
    {
        sharedInstance = this;
    }


    // Start is called before the first frame update
    void Start()
    {

        remainTime.text = timeStart.ToString("F2");

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager2.GetInstane().currentGameState == GameState2.inGame)
        {
            // update time during the game
            timeStart -= Time.deltaTime;
            remainTime.text = timeStart.ToString("F2");
            GameManager2.GetInstane().UpdateSpentTime();
        }
        // if the timer have finished end the game
        if (timeStart <= 0 && GameManager2.GetInstane().currentGameState == GameState2.inGame)
        {

            GameManager2.GetInstane().GameOver();
        }
    }

    public void UpdateCoin()
    {
        coinsNum.text = GameManager2.GetInstane().GetCollectedCoins().ToString();

    }

    // restart the timer
    public void SetTimerAndCoins()
    {
        timeStart = 60.0f;
        coinsNum.text = "0";
    }

}
