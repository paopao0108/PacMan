using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    public Button closeBtn;

    private void Awake()
    {
        closeBtn = transform.Find("closeBtn").GetComponent<Button>();
    }

    void Start()
    {
        closeBtn.onClick.AddListener(OnCloseBtnClick);
    }

    // Update is called once per frame
    void Update() { }

    private void OnCloseBtnClick()
    {
        gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("StartMenu").gameObject.SetActive(true);
    }
}