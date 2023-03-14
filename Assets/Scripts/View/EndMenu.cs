using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour
{
    public Button againBtn;
    public Button rankBtn;
    public Button exitBtn;
    void Start()
    {
        againBtn = transform.Find("AgainBtn").GetComponent<Button>();
        rankBtn = transform.Find("RankBtn").GetComponent<Button>();
        exitBtn = transform.Find("ExitBtn").GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.GetInstance().IsGameOver) gameObject.SetActive(true);
    }

    public void OnAgainBtnClick()
    {
        // 1. ���ص�ǰҳ��
        gameObject.SetActive(false);
        // 2. ��������ͷ

        // 3. ���÷�������ʱ��

        // 4. ��������λ��

    }
}
