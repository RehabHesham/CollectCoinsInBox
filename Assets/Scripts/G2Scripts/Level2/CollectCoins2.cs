using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoins2 : MonoBehaviour
{
    public bool followPlayer = false;


    private static CollectCoins2 sharedInstance;
    private void Awake()
    {
        sharedInstance = this;
    }

    public static CollectCoins2 GetInstane()
    {
        return sharedInstance;
    }

    private void Update()
    {
        if (followPlayer == true)
        {
            this.transform.position = GameManager2.GetInstane().player.transform.position;
        }
    }

    void CollectCoin()
    {
        followPlayer = false;
        // destroy the coin
        Destroy(this.gameObject);
        GameManager2 gm = GameManager2.GetInstane();
        // update coins number
        gm.CollectCoins();
        print("coins collected = " + gm.GetCollectedCoins());
        GenerateRandomCoins grc = GenerateRandomCoins.GetInstane();
        // generate new coin
        grc.CoinLocation();
    }



    private void OnTriggerEnter(Collider collision)
    {
        // only the player can collect the coin
        if (collision.tag == "Player")
        {
            followPlayer = true;
        }

        if (collision.tag == "Box")
        {
            CollectCoin();
        }
    }


}

