using System;
using System.Collections;
using UnityEngine;

public class GameController
{
    private static GameController _instance;
    private GameController() { }

    public static GameController GetInstance()
    {
        if (_instance == null) _instance = new GameController();
        return _instance;
    }

    public bool IsSuccess()
    {
        // 胜利
        // 3. 吃完豆子，并且在迷宫中
        //Console.WriteLine("当前分数：" + ScoreModel.GetInstance().CurScore);
        //Console.WriteLine("目标分数：" + GameModel.GetInstance().Score);
        if (ScoreModel.GetInstance().CurScore >= GameModel.GetInstance().Score)
        {
            return true;
        }
        return false;
    }

    public void Fail()
    {
        // 处理失败后的逻辑
        // 1. 碰到敌人
        // 2. 走出迷宫
        // 3. 用时结束
        GameOver();
    }

    public void Success()
    {
        // 处理成功后逻辑
        GameOver();
    }

    // 成功或失败都是GameOver
    private void GameOver()
    {
        GameModel.IsGameOver = true;
        if (ScoreModel.GetInstance().BestScore > PlayerPrefs.GetInt("BestScore")) PlayerPrefs.SetInt("BestScore", ScoreModel.GetInstance().BestScore);
        GameObject.Find("Canvas").transform.Find("EndMenu").gameObject.SetActive(true);
    }
}
