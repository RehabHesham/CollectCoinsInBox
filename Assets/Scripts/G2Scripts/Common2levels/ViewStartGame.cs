using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewStartGame : MonoBehaviour
{
    public Text userName;

    // Start is called before the first frame update
    void Start()
    {
        userName.text = "HI, " + GameManager0.GetInstane().userName;
    }


}
