using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodBye : MonoBehaviour
{
    private void Update()
    {
        if (GameManager0.GetInstane().exitBool == true)
        {
            Invoke("ChangeScreen", 3);
        }
    }


    public void ChangeScreen()
    {
        GameManager0.GetInstane().Exit();
    }
}
