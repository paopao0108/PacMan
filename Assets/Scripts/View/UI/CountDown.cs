using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    private TextMeshProUGUI number;

    public bool IsShow = false;
    public float timeInterval = 1;

    void Start()
    {
        number = transform.Find("number").GetComponent<TextMeshProUGUI>();
        gameObject.SetActive(false);
        GameEvt.gameAgain.Register(InitOrReset); // 注册重置倒计时事件
    }

    void Update()
    {
        //Debug.Log("开始倒计时：" + GameModel.startCountDown);
        if (!GameModel.IsReadying) return;
        if (GameModel.startCountDown < 0)
        {
            EndCountDown();
            return;
        }
        if (timeInterval > 0) { 
            timeInterval -= Time.deltaTime;
            ChangeFontSize();
        }
        else
        {
            ChangeText();
            timeInterval = 1;
        }
    }

    private void OnDestroy()
    {
        GameEvt.gameAgain.UnRegister(InitOrReset); // 注销重置倒计时事件
    }

    public void InitOrReset()
    {
        gameObject.SetActive(false);
        number.text = GameModel.startCountDown.ToString();
    }

    private void ChangeFontSize()
    {
        //if (GameModel._startCountDown > 0) number.fontSize += 0.2f;
        number.fontSize += 0.2f;
    }

    public virtual void ChangeText()
    {
        --GameModel.startCountDown;
        number.text = GameModel.startCountDown == 0 ? "Ready GO!" : GameModel.startCountDown.ToString();
        number.fontSize = GameModel.startCountDown == 0 ? 5 : 40;
    }

    // 计时结束，游戏开始
    public virtual void EndCountDown()
    {
        gameObject.SetActive(false);
        GameModel.IsGameStart = true;

        GameObject.Find("Time").transform.Find("gameTime").gameObject.SetActive(true); // 显示游戏计时
        GameObject.Find("Canvas").transform.Find("Score").gameObject.SetActive(true); // 显示得分
        GameObject.Find("Canvas").transform.Find("OptionMenu").gameObject.SetActive(true); // 显示得分
        GameEvt.gameStart.Trigger();
    }
}
