using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    public Button pauseBtn;
    public Button continueBtn;

    private void Awake()
    {
        pauseBtn = transform.Find("PauseBtn").GetComponent<Button>();
        continueBtn = transform.Find("ContinueBtn").GetComponent<Button>();
    }

    void Start()
    {
        pauseBtn.onClick.AddListener(OnPauseBtnClick);
        continueBtn.onClick.AddListener(OnContinueBtnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnPauseBtnClick()
    {
        AudioController.currentAudio.Pause();
        Debug.Log("音频" + AudioController.currentAudio);
        Time.timeScale = 0;
    }
    
    private void OnContinueBtnClick()
    {
        AudioController.currentAudio.UnPause();

        Time.timeScale = 1;
    }
}
