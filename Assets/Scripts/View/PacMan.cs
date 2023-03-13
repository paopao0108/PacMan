using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacMan : MonoBehaviour
{
    //private Vector3 dest; // 目标位置
    private Rigidbody rb;
    private Vector3 move;
    private float forwardAmount;
    private float turnAmount;
    private float forwardSpeed = 0.2f;
    private float turnSpeed = 10f;

    //public float speed = 1f;
    public float angleSpeed = 0.5f;

    public Score score;

    void Start()
    {
        //dest = transform.position; // 初始位置
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 0, 0);
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        move = new Vector3(x, 0, z);
        Vector3 localMove = transform.InverseTransformVector(move);
        //forwardAmount = localMove.z;
        forwardAmount = localMove.z;
        turnAmount = Mathf.Atan2(localMove.x, localMove.z);
        Debug.Log("move：" + move + "  localMove：" + localMove);
        Debug.Log("forwardAmount：" + forwardAmount + "  turnAmount：" + turnAmount);
    }

    private void FixedUpdate()
    {
        rb.AddForce(forwardAmount * transform.forward * forwardSpeed, ForceMode.VelocityChange);
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0, turnAmount * turnSpeed, 0));

        //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, turnAmount * turnSpeed, 0), angleSpeed);

        ////避免收到力的作用反弹后一直飘动
        //GetComponent<Rigidbody>().velocity = Vector3.zero; //（ Vector3.zero = new Vector3(0, 0, 0)）

        //if (transform.position == dest)
        //{
        //    if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)))
        //    {
        //        Debug.Log("前");
        //        //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(Vector3.forward), angleSpeed);
        //        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), angleSpeed);
        //        dest = transform.position + Vector3.forward * Time.deltaTime; // (0,0,1)
        //                                                                      //dest = transform.position + Vector3.forward; // (0,0,1)
        //    }
        //    if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)))
        //    {
        //        Debug.Log("右");
        //        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 90, 0), angleSpeed);
        //        //dest = transform.position + Vector3.right * Time.deltaTime; // (0,0,1)
        //        dest = transform.position + Vector3.right; // (0,0,1)
        //    }
        //    if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)))
        //    {
        //        Debug.Log("左");
        //        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, -90, 0), angleSpeed);
        //        //dest = transform.position + Vector3.left * Time.deltaTime; // (0,0,1)
        //        dest = transform.position + Vector3.left; // (0,0,1)
        //    }
        //    if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)))
        //    {
        //        Debug.Log("后");
        //        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 180, 0), angleSpeed);
        //        //dest = transform.position + Vector3.back; // (0,0,1)
        //        dest = transform.position + Vector3.back * Time.deltaTime; // (0,0,1)
        //    }
        //}

        //Vector3 nextPos = Vector3.MoveTowards(transform.position, dest, speed); // 从transform.position最大距离不超过speed为移动步频移向dest
        //rb.MovePosition(nextPos);
    }

    private void OnTriggerEnter(Collider collision)
    {
        //碰撞到的游戏物体名字
        Debug.Log("PacMan碰到物体：" + collision.gameObject.tag);
        if (collision.gameObject.tag == "Dot")
        {
            Debug.Log("吃掉豆子");
            collision.gameObject.GetComponent<Dot>().Dispear(); // 吃掉豆子
            ScoreChangeEvent.Trigger(); // 更新页面
            if (GameService.GetInstance().IsSuccess()) GameService.GetInstance().Success();
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("碰到敌人"); // 游戏失败
            GameService.GetInstance().Fail();
        }
    }
}
