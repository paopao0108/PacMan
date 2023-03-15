using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTime : MonoBehaviour
{
    //public static int GameModel.gameCountDown = 60;
    private TextMeshProUGUI number;
    public float timeInterval = 1;


    void Start()
    {
        number = transform.Find("number").GetComponent<TextMeshProUGUI>();
        InitOrReset();
    }
     
    void Update()
    {
        if (GameModel.gameCountDown < 0) EndCountDown();
        if (!GameModel.IsGameStart || GameModel.gameCountDown < 0) return;
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
        GameModel.gameCountDown = 60;
        number.text = "LeftTime: " + GameModel.gameCountDown + "s";
    }

    public void ChangeText()
    {
        --GameModel.gameCountDown;
        number.text = "LeftTime: " + GameModel.gameCountDown + "s";
    }

    // 计时结束
    public void EndCountDown()
    {
        Debug.Log("游戏时间用完！");
        GameController.GetInstance().Fail(); // 用时结束，游戏结束
    }
}
