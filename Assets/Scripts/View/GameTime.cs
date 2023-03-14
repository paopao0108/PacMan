using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTime : MonoBehaviour
{
    public static int countDown = 60;
    private TextMeshProUGUI number;
    public float timeInterval = 1;


    void Start()
    {
        number = transform.Find("number").GetComponent<TextMeshProUGUI>();
        InitOrReset();
    }
     
    void Update()
    {
        if (countDown < 0) EndCountDown();
        if (!GameController.GetInstance().IsGameStart || countDown < 0) return;
        if (timeInterval > 0)
        {
            timeInterval -= Time.deltaTime;
        }
        else
        {
            ChangeText();
            timeInterval = 1;
        }
    }

    public void InitOrReset()
    {
        countDown = 60;
        number.text = "LeftTime: " + countDown + "s";
    }

    public void ChangeText()
    {
        --countDown;
        number.text = "LeftTime: " + countDown + "s";
    }

    // 计时结束
    public void EndCountDown()
    {
        Debug.Log("游戏时间用完！");
        GameController.GetInstance().Fail(); // 用时结束，游戏结束
    }
}
