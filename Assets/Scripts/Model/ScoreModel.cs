using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreModel 
{
    //private static ScoreModel _instance;
    private static ScoreModel _instance;
    private int _bestScore = 0; // 最高分数
    private int _curScore = 0; // 当前分数
    

    public int BestScore { get => _bestScore; set => _bestScore = value; }
    public int CurScore { get => _curScore; set => _curScore = value; }

    private ScoreModel(){ }

    public static ScoreModel GetInstance()
    {
        if (_instance == null) _instance = new ScoreModel();
        return _instance;
    }

    public void UpdateScore()
    {
        AddScore();
        UpdateBestScore();
    }

    public void AddScore()
    {
        CurScore += 1;
    }

    public void UpdateBestScore()
    {
        //Debug.Log("更新最高分: " + PlayerPrefs.GetInt("BestScore"));
        //if (CurScore > PlayerPrefs.GetInt("BestScore")) PlayerPrefs.SetInt("BestScore", CurScore);  // BestScore = CurScore;
        if (CurScore > BestScore) BestScore = CurScore;
    }
}
