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
        Debug.Log("Fail");
        GameOver(); // 处理失败后的逻辑
        GameObject.Find("EndMenu").transform.Find("NextBtn").gameObject.SetActive(false); // 隐藏下一关按钮

    }

    public void Success()
    {
        Debug.Log("success");
        GameOver(); // 处理成功后逻辑
        GameObject.Find("EndMenu").transform.Find("NextBtn").gameObject.SetActive(true); // 显示下一关按钮

    }

    public void GameOver()
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

        
        GameObject.Find("Time").transform.Find("gameTime").gameObject.SetActive(false); // 隐藏游戏计时
        GameObject.Find("Canvas").transform.Find("Score").gameObject.SetActive(false); // 隐藏得分
        GameObject.Find("Canvas").transform.Find("OptionMenu").gameObject.SetActive(false); // 隐藏选项
        GameObject.Find("Canvas").transform.Find("EndMenu").gameObject.SetActive(true); // 显示结束页面
        EndMenu.Instance.ShowInfo();
        GameEvent.gameOver.Trigger();
    }

    public static void HanadleGameOver() 
    {
        //GameModel.IsGameOver = true;
        GameObject.Find("Time").transform.Find("gameTime").gameObject.SetActive(false); // 隐藏游戏计时
        GameObject.Find("Canvas").transform.Find("Score").gameObject.SetActive(false); // 隐藏得分
        GameObject.Find("Canvas").transform.Find("OptionMenu").gameObject.SetActive(false); // 隐藏选项
        GameEvent.gameOver.Trigger();
    }
}
