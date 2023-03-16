using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacMan : MonoBehaviour
{
    private int angle = 0;
    private Vector3 startPos = Constant.Position.PacManStartPos;

    public float dropRange = 3; // 允许掉落高度的范围
    public float angleSpeed = 10f;
    public float speed = 10.0f;
    public Score score;
    public AudioSource eatAudio;

    private void Awake()
    {
        InitOrReset();
    }

    private void Start()
    {
        GameEvt.gameAgain.Register(InitOrReset);
    }

    private void FixedUpdate()
    {
        if (!GameModel.IsGameStart || GameModel.IsGameOver) return;
        if (IsDrop(transform.position.y)) GameController.GetInstance().Fail();
        float horizontal = Input.GetAxis("Horizontal");
        float vetical = Input.GetAxis("Vertical");
        if (vetical != 0 || horizontal != 0) transform.Translate(0, 0, speed * Time.deltaTime); // 按物体正方向移动
        Direction(horizontal, vetical);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, angle, 0), angleSpeed * Time.deltaTime);
    }

    private void OnDestroy()
    {
        GameEvt.gameAgain.UnRegister(InitOrReset);
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
        return Mathf.Abs(newy - startPos.y) > dropRange;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Dot")) // 碰撞到的游戏物体名字
        {
            eatAudio.Play();
            collision.gameObject.GetComponent<Dot>().Dispear(); // 吃掉豆子
            GameEvt.scoreChange.Trigger(); // 更新页面分数
            if (GameController.GetInstance().IsSuccess()) GameController.GetInstance().Success(); // 判断是否取胜
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            if (!GameModel.IsGameOver) GameController.GetInstance().Fail(); // 游戏失败
        }
    }


}
