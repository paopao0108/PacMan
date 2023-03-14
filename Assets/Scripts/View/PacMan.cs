using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacMan : MonoBehaviour
{
    private int angle = 0;
    private float y; // 对象的y坐标
    private Vector3 startPos = new Vector3(0.12f, 1.69f, 6.93f);

    public float dropRange = 3; // 掉落高度的范围
    public float angleSpeed = 0.5f;
    public float speed = 10.0f;
    public Score score;

    private void Awake()
    {
        transform.position = startPos;
    }

    private void FixedUpdate()
    {
        if (!GameController.GetInstance().IsGameStart || GameController.GetInstance().IsGameOver) return;
        if (IsDrop(transform.position.y)) GameController.GetInstance().Fail();

        float horizontal = Input.GetAxis("Horizontal");
        float vetical = Input.GetAxis("Vertical");
        //transform.Translate(horizontal * speed * Time.deltaTime,  0, vetical * speed * Time.deltaTime);
        if (vetical != 0 || horizontal != 0) transform.Translate(0, 0, speed * Time.deltaTime); // 按物体正方向移动
        //或
        //transform.position += new Vector3(horizontal * speed * Time.deltaTime, vetical * speed * Time.deltaTime, 0);

        Direction(horizontal, vetical);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, angle, 0), angleSpeed);
    }


    public void InitOrReset()
    {
        transform.position = startPos; // 初始化位置
        transform.rotation = Quaternion.Euler(0, 0, 0); // 初始化角度
    }

    public void Direction(float h, float v)
    {
        if (v == 0 && h != 0) angle = h > 0 ? 90 : -90;
        else if (h == 0 && v != 0) angle = v > 0 ? 0 : 180;
    }

    // 是否出界掉落
    public bool IsDrop(float newy)
    {
        return Mathf.Abs(newy - y) > dropRange;
    }

    private void OnTriggerEnter(Collider collision)
    {
        //碰撞到的游戏物体名字
        Debug.Log("PacMan碰到物体：" + collision.gameObject.tag);
        if (collision.gameObject.tag == "Dot")
        {
            Debug.Log("吃掉豆子");
            collision.gameObject.GetComponent<Dot>().Dispear(); // 吃掉豆子
            ScoreChangeEvent.Trigger(); // 更新页面分数
            if (GameController.GetInstance().IsSuccess()) GameController.GetInstance().Success(); // 判断是否取胜
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("碰到敌人"); // 游戏失败
            GameController.GetInstance().Fail();
        }
    }


}
