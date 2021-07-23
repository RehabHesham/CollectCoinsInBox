using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeGameMode2 : MonoBehaviour
{
    public Slider sliderInstance;

    private static ChangeGameMode2 sharedInstance;
    private void Awake()
    {
        sharedInstance = this;
    }

    public static ChangeGameMode2 GetInstane()
    {
        return sharedInstance;
    }

    private void Start()
    {
        sliderInstance.minValue = 0;
        sliderInstance.maxValue = 1;
        sliderInstance.wholeNumbers = true;
        sliderInstance.value = 1;
        sliderInstance = GameObject.Find("Choice").GetComponent<Slider>();
    }

    public void onValueChanged(float value)
    {
        Debug.Log("new value " + value);

        if (value == 0)
        {
            GameManager2.GetInstane().changeGameMode2(GameMode2.mode1);
        }
        else if (value == 1)
        {
            GameManager2.GetInstane().changeGameMode2(GameMode2.mode2);
        }

    }

}
