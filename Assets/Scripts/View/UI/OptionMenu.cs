using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    public Button pauseBtn;
    public Button continueBtn;
    public Button restartBtn;

    private void Awake()
    {
        pauseBtn = transform.Find("PauseBtn").GetComponent<Button>();
        continueBtn = transform.Find("ContinueBtn").GetComponent<Button>();
        restartBtn = transform.Find("RestartBtn").GetComponent<Button>();
    }

    void Start()
    {
        pauseBtn.onClick.AddListener(OnPauseBtnClick);
        continueBtn.onClick.AddListener(OnContinueBtnClick);
        restartBtn.onClick.AddListener(OnRestartBtnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnPauseBtnClick()
    {
        AudioCtrl.isPaused = true;
        AudioCtrl.currentAudio.Pause();
        //Debug.Log("音频" + AudioCtrl.currentAudio);
        Time.timeScale = 0;
    }
    
    private void OnContinueBtnClick()
    {
        AudioCtrl.isPaused = false;
        AudioCtrl.currentAudio.UnPause();
        Time.timeScale = 1;
    }

    private void OnRestartBtnClick()
    {
        AudioCtrl.isPaused = true;
        //Debug.Log("当前音乐：" + AudioCtrl.currentAudio);
        AudioCtrl.currentAudio.Stop();

        GameModel.Reset(); // 重置数据
        GameController.HanadleGameOver();
    }
}
