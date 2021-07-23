using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Srr : MonoBehaviour
{
    private void Update()
    {
        if (GameManager0.GetInstane().srrBool == true)
        {
            Invoke("ChangeScreen", 3);
        }
    }

    public void ChangeScreen()
    {
        GameManager0.GetInstane().GoToSignIn();
    }
}
