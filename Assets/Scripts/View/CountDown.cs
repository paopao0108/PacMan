using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    private TextMeshProUGUI number;
    public int countDown = 3;
    public float timeInterval = 1;

    // ��Ϸ��ʼ����ʱ����������ʾ Ready GO

    void Start()
    {
        number = transform.Find("number").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (countDown < 0) EndCountDown();
        if (!GameController.GetInstance().IsReadying || countDown < 0) return;
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

    private void ChangeFontSize()
    {
        //if (countDown > 0) number.fontSize += 0.2f;
        number.fontSize += 0.2f;
    }

    public virtual void ChangeText()
    {
        --countDown;
        number.text = countDown == 0 ? "Ready GO!" : countDown.ToString();
        number.fontSize = countDown == 0 ? 10 : 40;
        //number.fontSize = 40;

    }

    // ��ʱ����
    public virtual void EndCountDown()
    {
        gameObject.SetActive(false);
        GameController.GetInstance().IsGameStart = true;
    }
}
