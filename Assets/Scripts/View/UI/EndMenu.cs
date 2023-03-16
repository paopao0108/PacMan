using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour
{
    private static EndMenu _instance;

    public static EndMenu Instance => _instance;
    public Button againBtn;
    public Button rankBtn;
    public Button exitBtn;
    private void Awake()
    {
        _instance = this;
        againBtn = transform.Find("AgainBtn").GetComponent<Button>();
        rankBtn = transform.Find("RankBtn").GetComponent<Button>();
        exitBtn = transform.Find("ExitBtn").GetComponent<Button>();
    }
    void Start()
    {
        againBtn.onClick.AddListener(OnAgainBtnClick);
        exitBtn.onClick.AddListener(OnExitBtnClick);
    }

    public void OnAgainBtnClick()
    {
        // 1. 隐藏当前页面
        gameObject.SetActive(false);
        //AudioController.Instance.endAudio.Stop();
        GameModel.Reset(); // 重置数据
        GameEvent.gameAgain.Trigger(); // 重置摄像头 重置物体位置; 重置分数、计时器
    }

    public void OnExitBtnClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }

    // 显示本关得分和用时
    public void ShowInfo()
    {
        //Debug.Log("得分：" + GameObject.Find("Score").GetComponent<TextMeshProUGUI>());
        GameObject.Find("Score").GetComponent<TextMeshProUGUI>().text = "score: " + ScoreModel.GetInstance().CurScore;
        int spendTime = GameModel.gameTime - GameModel.leftTime;
        GameObject.Find("SpendTime").GetComponent<TextMeshProUGUI>().text = spendTime > 60 ? "Time Out!" : "time: " + spendTime + "s";
    }

}
