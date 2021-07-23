using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Welcome : MonoBehaviour
{
    // Start is called before the first frame update
    private void Update()
    {
        if (GameManager0.GetInstane().welcomeBool == true)
        {
            Invoke("ChangeScreen", 3);
        }
    }
    public void ChangeScreen()
    {
        GameManager0.GetInstane().GoToSRR();
    }
}
