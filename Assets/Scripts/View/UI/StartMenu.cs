using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public Button startBtn;
    public Button RankBtn;
    public Button settingBtn;
    private void Awake()
    {
        startBtn = transform.Find("StartBtn").GetComponent<Button>();
        RankBtn = transform.Find("RankBtn").GetComponent<Button>();
        settingBtn = transform.Find("SettingBtn").GetComponent<Button>();
    }
    void Start()
    {
        startBtn.onClick.AddListener(OnStartBtnClick);
        settingBtn.onClick.AddListener(OnSettingBtnClick);

    }

    public void OnStartBtnClick()
    {
        GameModel.IsSwitchCamera = true;
        //AudioCtrl.Instance.startAudio.Stop();
        //AudioCtrl.Instance.readyAudio.Play();
        gameObject.SetActive(false);
    }
    
    public void OnSettingBtnClick()
    {
        gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("SettingMenu").gameObject.SetActive(true);
    }
}
