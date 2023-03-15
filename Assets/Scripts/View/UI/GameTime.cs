using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTime : MonoBehaviour
{
    //public static int GameModel.leftTime = 60;
    private TextMeshProUGUI number;
    public float timeInterval = 1;

    void Start()
    {
        number = transform.Find("number").GetComponent<TextMeshProUGUI>();
        InitOrReset();
        GameEvent.gameStart.Register(InitOrReset);
    }
     
    void Update()
    {
        if (GameModel.leftTime < 0) EndCountDown();
        if (!GameModel.IsGameStart || GameModel.leftTime < 0) return;
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

    private void OnDestroy()
    {
        GameEvent.gameStart.UnRegister(InitOrReset);
    }

    public void InitOrReset()
    {
        GameModel.leftTime = 60;
        number.text = "LeftTime: " + GameModel.leftTime + "s";
    }

    public void ChangeText()
    {
        --GameModel.leftTime;
        number.text = "LeftTime: " + GameModel.leftTime + "s";
    }

    // 计时结束
    public void EndCountDown()
    {
        Debug.Log("游戏时间用完！");
        GameController.GetInstance().Fail(); // 用时结束，游戏结束
    }
}
