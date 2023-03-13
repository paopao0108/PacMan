using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI _bestScoreText;
    private TextMeshProUGUI _curScoreText;
    private void Start()
    {
        _bestScoreText = transform.Find("bestScore/value").GetComponent<TextMeshProUGUI>();
        _curScoreText = transform.Find("curScore/value").GetComponent<TextMeshProUGUI>();
        ScoreChangeEvent.Register(OnScoreChange); // 注册事件
    }

    private void OnDestroy()
    {
        ScoreChangeEvent.UnRegister(OnScoreChange); // 注销事件
    }

    private void OnScoreChange()
    {
        // 更新数据和页面（表现层）
        ScoreModel.GetInstance().UpdateScore(); // 更新分数
        _curScoreText.text = "CURRENT SCORE: " + ScoreModel.GetInstance().CurScore; // 更新页面
        _bestScoreText.text = "BEST SCORE: " + ScoreModel.GetInstance().BestScore;
    }
    
}
