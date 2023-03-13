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
        ScoreChangeEvent.Register(OnScoreChange); // ע���¼�
    }

    private void OnDestroy()
    {
        ScoreChangeEvent.UnRegister(OnScoreChange); // ע���¼�
    }

    private void OnScoreChange()
    {
        // �������ݺ�ҳ�棨���ֲ㣩
        ScoreModel.GetInstance().UpdateScore(); // ���·���
        _curScoreText.text = "CURRENT SCORE: " + ScoreModel.GetInstance().CurScore; // ����ҳ��
        _bestScoreText.text = "BEST SCORE: " + ScoreModel.GetInstance().BestScore;
    }
    
}
