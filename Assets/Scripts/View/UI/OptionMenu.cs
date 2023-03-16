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
        continueBtn.onClick.AddListener(OnRestartBtnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnPauseBtnClick()
    {
        AudioController.isPaused = true;
        AudioController.currentAudio.Pause();
        //Debug.Log("音频" + AudioController.currentAudio);
        Time.timeScale = 0;
    }
    
    private void OnContinueBtnClick()
    {
        AudioController.isPaused = false;
        AudioController.currentAudio.UnPause();
        Time.timeScale = 1;
    }

    private void OnRestartBtnClick()
    {
        AudioController.isPaused = true;
        Debug.Log("当前音乐：" + AudioController.currentAudio);
        AudioController.currentAudio.Stop();
        
        GameModel.Reset(); // 重置数据
        GameController.HanadleGameOver();
    }
}
