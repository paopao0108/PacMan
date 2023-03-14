using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour
{
    public Button againBtn;
    public Button rankBtn;
    public Button exitBtn;
    void Start()
    {
        againBtn = transform.Find("AgainBtn").GetComponent<Button>();
        rankBtn = transform.Find("RankBtn").GetComponent<Button>();
        exitBtn = transform.Find("ExitBtn").GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.GetInstance().IsGameOver) gameObject.SetActive(true);
    }

    public void OnAgainBtnClick()
    {
        // 1. 隐藏当前页面
        gameObject.SetActive(false);
        // 2. 重置摄像头

        // 3. 重置分数、计时器

        // 4. 重置物体位置

    }
}
