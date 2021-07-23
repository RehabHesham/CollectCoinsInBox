using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    public Camera mainCamera;
    private Vector2 screenBounds;

    private float objectWidth;
    private float objectHeight;

    // Start is called before the first frame update
    void Start()
    {
        // get the screen bounds and the player dimentions
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        objectWidth = transform.GetComponent<MeshRenderer>().bounds.extents.x;
        objectHeight = transform.GetComponent<MeshRenderer>().bounds.extents.y;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        // limit the position of the player with the screen pounds
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x + objectWidth, screenBounds.x * -1 - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y + objectHeight, screenBounds.y * -1 - objectHeight);
        transform.position = viewPos;

    }
}
