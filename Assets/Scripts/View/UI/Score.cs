using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI _bestScoreText;
    private TextMeshProUGUI _curScoreText;
    private void Awake()
    {
        _bestScoreText = transform.Find("bestScore/value").GetComponent<TextMeshProUGUI>();
        _curScoreText = transform.Find("curScore/value").GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        InitOrReset();
        GameEvent.scoreChange.Register(OnScoreChange); // 注册事件
        GameEvent.gameAgain.Register(InitOrReset);
    }

    private void OnDestroy()
    {
        GameEvent.scoreChange.UnRegister(OnScoreChange); // 注销事件
        GameEvent.gameAgain.UnRegister(InitOrReset);
    }

    private void OnScoreChange()
    {
        ScoreModel.GetInstance().UpdateScore(); // 更新分数
        _curScoreText.text = "CURRENT SCORE: " + ScoreModel.GetInstance().CurScore; // 更新页面
        _bestScoreText.text = "BEST SCORE: " + ScoreModel.GetInstance().BestScore;
    }

    public void InitOrReset()
    {
        _curScoreText.text = "CURRENT SCORE: 0";
        _bestScoreText.text = "BEST SCORE: " + PlayerPrefs.GetInt("BestScore");
        ScoreModel.GetInstance().BestScore = PlayerPrefs.GetInt("BestScore");
    }

}
