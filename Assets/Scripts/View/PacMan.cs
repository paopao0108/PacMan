using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacMan : MonoBehaviour
{
    private int angle = 0;
    private float y; // 对象的y坐标
    private Vector3 startPos = new Vector3(0.12f, 1.69f, 6.93f);

    public float dropRange = 3; // 允许掉落高度的范围
    public float angleSpeed = 0.5f;
    public float speed = 10.0f;
    public Score score;

    private void Awake()
    {
        //transform.position = startPos;
        //Debug.Log("吃豆人世界坐标：" + transform.position);
        //Debug.Log("吃豆人自身坐标：" + transform.localPosition);
        InitOrReset();
    }

    private void Start()
    {
        GameEvent.gameAgain.Register(InitOrReset);
    }

    private void FixedUpdate()
    {
        if (!GameModel.IsGameStart || GameModel.IsGameOver) return;
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

    private void OnDestroy()
    {
        GameEvent.gameAgain.UnRegister(InitOrReset);
    }

    public void InitOrReset()
    {
        transform.localPosition = startPos; // 初始化位置
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
            GameEvent.scoreChange.Trigger(); // 更新页面分数
            if (GameController.GetInstance().IsSuccess()) GameController.GetInstance().Success(); // 判断是否取胜
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("碰到敌人"); // 游戏失败
            GameController.GetInstance().Fail();
        }
    }


}
