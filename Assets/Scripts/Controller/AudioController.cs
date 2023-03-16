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
    public static AudioSource currentAudio;
    public static bool isPaused = false; // 是否暂停
    public float volume = 0.7f;

    private void Awake()
    {
        _instance = this;
        startAudio.Play();
    }
    void Start()
    {
        startAudio.volume = volume;
    }

    void Update()
    {

        if (GameModel.IsSwitchCamera && !isPaused)
        {
            endAudio.Stop();
            if (!readyAudio.isPlaying) // ��������ͷ����ʼ����ʱ
            {
                startAudio.Stop();
                readyAudio.Play();
                // currentAudio = readyAudio;
            }
        }
            

        if (GameModel.IsGameStart && !isPaused)
        {
            readyAudio.Stop();
            if (!gameTimeAudio.isPlaying)
            {
                gameTimeAudio.Play();
                currentAudio = gameTimeAudio;
            }
        }

        if (GameModel.IsGameOver)
        {
            gameTimeAudio.Stop();
            if (!endAudio.isPlaying)
            {
                endAudio.Play();
                // currentAudio = endAudio;
            }
        }

    }

    public void ChangeVolume()
    {
        
    }
}
