using System;
using System.Collections;
using UnityEngine;

public class GameController
{
    private static GameController _instance;

    public bool IsSwitchCamera = false; // 相机拉近
    public bool IsReadying = false; // 倒计时准备
    public bool IsGameStart = false; // 游戏开始
    public bool IsGameOver = false; // 游戏结束

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
        IsGameOver = true;
        if (ScoreModel.GetInstance().BestScore > PlayerPrefs.GetInt("BestScore")) PlayerPrefs.SetInt("BestScore", ScoreModel.GetInstance().BestScore);
    }
}
