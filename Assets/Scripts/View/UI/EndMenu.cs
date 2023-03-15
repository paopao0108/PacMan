using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour
{
    public Button againBtn;
    public Button rankBtn;
    public Button exitBtn;
    private void Awake()
    {
        againBtn = transform.Find("AgainBtn").GetComponent<Button>();
        rankBtn = transform.Find("RankBtn").GetComponent<Button>();
        exitBtn = transform.Find("ExitBtn").GetComponent<Button>();
    }
    void Start()
    {
        againBtn.onClick.AddListener(OnAgainBtnClick);
    }

    public void OnAgainBtnClick()
    {
        // 1. 隐藏当前页面
        gameObject.SetActive(false);

        GameModel.Reset();
        GameEvent.gameAgain.Trigger(); // 重置摄像头 重置物体位置; 重置分数、计时器
    }



}
