 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowCoins2 : MonoBehaviour
{

    public Vector3 coinPosition;
    private Rigidbody rb;

    private Vector3 movement;
    public GameObject Box;

    public float moveSpeed = 2f;

    private float distance;
    private Vector3 lastSentPosition;

    private static PlayerFollowCoins2 sharedInstance;
    private void Awake()
    {
        sharedInstance = this;
    }

    public static PlayerFollowCoins2 GetInstane()
    {
        return sharedInstance;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager2.GetInstane().currentGameState == GameState2.inGame && CollectCoins2.GetInstane().followPlayer == false)
        {
            //print("Coin Case");
            coinPosition = GenerateRandomCoins.GetInstane().GetCoinPosition();
            coinPosition.z = 0;
            Vector3 direction = coinPosition - transform.position;
            direction.Normalize();
            movement = direction;
        }
        else
        {
            //print("Box Case");
            Vector3 boxPosition = Box.transform.position;
            boxPosition.z = 0;
            Vector3 direction = boxPosition - transform.position;
            direction.Normalize();
            movement = direction;
        }
        distance = (transform.position - lastSentPosition).magnitude;
        if (distance > 1f)
        {
            lastSentPosition = transform.position;
            float x = transform.position.x;
            float y = transform.position.y;
            string msg = x + " " + y;
            ConnectArduino.GetInstane().WriteToArduino(msg);
        }
    }

    private void FixedUpdate()
    {
        // move the player only in inGmae mode
        if (GameManager2.GetInstane().currentGameState == GameState2.inGame)
        {
            moveCharacter(movement);
        }
    }

    public void moveCharacter(Vector3 direction)
    {
        rb.MovePosition(transform.position + (direction * moveSpeed * Time.deltaTime));

    }

}
