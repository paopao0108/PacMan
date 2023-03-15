using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private static AudioController _instance;

    public static AudioController Instance => _instance;

    public AudioSource startAudio;
    public AudioSource eatAudio;
    public AudioSource readyAudio;
    public AudioSource endAudio;
    public AudioSource gameTimeAudio;

    public AudioClip[] audios;

    private void Awake()
    {
        _instance = this;
        startAudio.Play();
    }
    void Start()
    {
        
    }

    void Update()
    {

        if (GameModel.IsSwitchCamera)
        {
            endAudio.Stop();
            if (!readyAudio.isPlaying) // 拉近摄像头，开始倒计时
            {
                startAudio.Stop();
                readyAudio.Play();
            }
        }
            

        if (GameModel.IsGameStart)
        {
            readyAudio.Stop();
            if (!gameTimeAudio.isPlaying)
            {
                gameTimeAudio.Play();
            }
        }

        if (GameModel.IsGameOver)
        {
            gameTimeAudio.Stop();
            if (!endAudio.isPlaying)
            {
                endAudio.Play();
            }
        }

    }
}
