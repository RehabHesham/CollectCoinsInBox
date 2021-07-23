using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGView : MonoBehaviour
{


    private static EndGView sharedInstance;

    // the UI objects used in display
    public Text sessionCoins;
    public Text totalCoins;
    public Text sessionTime;
    public Text totalTime;
    public Text sessionNum;

    public static EndGView GetInstance()
    {
        return sharedInstance;
    }

    private void Awake()
    {
        sharedInstance = this;
    }

    // used to determine the information about the sessions and preview it for user
    public void UpdateGui()
    {
        if (GameManager2.GetInstane().currentGameState == GameState2.endGame)
        {

            sessionCoins.text = GameManager2.GetInstane().GetCollectedCoins().ToString();
            totalCoins.text = GameManager2.GetInstane().GetTotalCollectedCoins().ToString();
            sessionTime.text = GameManager2.GetInstane().GetTime().ToString("F2");
            totalTime.text = GameManager2.GetInstane().GetTotalTime().ToString("F2");
            sessionNum.text = GameManager2.GetInstane().GetSessionNum().ToString();

        }
    }

}
