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
        if (ScoreModel.GetInstance().CurScore >= DotManager.dotsCount)
        {
            return true;
        }
        return false;
    }

    public void Fail()
    {
        GameOver(); // 处理失败后的逻辑
    }

    public void Success()
    {
        GameOver(); // 处理成功后逻辑
    }

    private void GameOver()
    {
        GameModel.IsGameOver = true;
        if (ScoreModel.GetInstance().BestScore > PlayerPrefs.GetInt("BestScore")) PlayerPrefs.SetInt("BestScore", ScoreModel.GetInstance().BestScore);

        // TODO 添加排行耪
        //ScoreModel.GetInstance().UpdateScoreRank(); // 更新排名
        //ScoreModel.GetInstance().GetRank(); // 获取当前排名
        //foreach (int score in ScoreModel.scoreRank)
        //{
        //    Debug.Log("分数列表：" + score);
        //}
        //Debug.Log("当前排名：" + ScoreModel.GetInstance().GetRank());

        GameObject.Find("Canvas").transform.Find("EndMenu").gameObject.SetActive(true);
    }
}
