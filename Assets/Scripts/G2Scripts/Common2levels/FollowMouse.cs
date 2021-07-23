using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{

    public float distance = 10.0f;
    public bool useCameraDistance = false;
    private float actualDistance;

    

    // Start is called before the first frame update
    void Start()
    {
        // calculate the distance
        if (useCameraDistance)
        {
            // calculate the prependicular distance
            Vector3 objectVector = transform.position - Camera.main.transform.position;
            Vector3 linearDistanceVector = Vector3.Project(objectVector, Camera.main.transform.forward);
            actualDistance = (linearDistanceVector).magnitude;
        }
        else
        {
            // fixed distance
            actualDistance = distance;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // move the player only in inGmae mode
        if (PlayerPrefs.GetString("ChosenGame") == "CollectCoinsBox" && GameManager2.GetInstane().currentGameState == GameState2.inGame)
        {
            Move();
        }
        
    }

    private void Move()
    {
        // make the player follow the mouse movement
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = actualDistance;
        transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
    }

}
