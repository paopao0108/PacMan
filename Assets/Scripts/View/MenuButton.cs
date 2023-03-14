using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    public Button startBtn;
    public Button RankBtn;
    public Button settingBtn;
    void Start()
    {
        startBtn = transform.Find("StartBtn").GetComponent<Button>();
        RankBtn = transform.Find("RankBtn").GetComponent<Button>();
        settingBtn = transform.Find("SettingBtn").GetComponent<Button>();
    }

    public void OnStartBtnClick()
    {
        GameController.GetInstance().IsSwitchCamera = true;
        gameObject.SetActive(false);
    }
}
