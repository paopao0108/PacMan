using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacMan1 : MonoBehaviour
{
    public float speed = 0.05f;

    private Vector3 dest = Vector3.zero;
    private float angleSpeed = 100; // 旋转的角速度


    private void Start()
    {
        dest = transform.position; // 初始化吃豆人的目标位置（游戏开始保证吃豆人不会移动）
    }

    private void FixedUpdate()
    {
        //rigidbody.MovePosition(Vector2.Lerp(transform.position, targetPos, smoothing * Time.deltaTime));

        Vector3 temp = Vector3.MoveTowards(transform.position, dest, speed); // 获取下一次移动的坐标

        GetComponent<Rigidbody>().MovePosition(temp); // 利用刚体将物体移动到下一次的坐标位置

        if (transform.position == dest) // 当物体已经到达上一个目标坐标后，才可以继续移动
        {
            if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && ValidDirection(Vector3.forward))
            {
                Debug.Log("前");
                dest = transform.position + Vector3.forward; // (0,0,1)
                //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(Vector3.forward), angleSpeed*Time.deltaTime);
            }
            if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && ValidDirection(Vector3.forward))
            {
                Debug.Log("后");
                dest = transform.position + Vector3.back;
                //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(Vector3.back), angleSpeed * Time.deltaTime);
            }
            if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && ValidDirection(Vector3.forward))
            {
                Debug.Log("左");
                dest = transform.position + Vector3.left;
                //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(Vector3.left), angleSpeed * Time.deltaTime);
            }
            if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && ValidDirection(Vector3.forward))
            {
                Debug.Log("右");
                dest = transform.position + Vector3.right;
                //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(Vector3.right), angleSpeed * Time.deltaTime);

            }
        }
    }

    /// <summary>
    /// 验证前进方向是否有效
    /// </summary>
    /// <param name="direction"></param>
    /// <returns></returns>
    private bool ValidDirection(Vector3 direction)
    {
        //Vector2 dir = new Vector2(direction.x, direction.z); // 目标方向
        //Vector2 pos = new Vector2(transform.position.x, transform.position.z); // 当前位置
        //RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos); // 从目标位置向当前位置发射一条射线，存储射线信息
        //return hit.collider == GetComponent<Collider>(); // 返回的射线是否可以打到吃豆人自身的碰撞器


        Vector3 dir = new Vector2(direction.x, direction.z); // 目标方向
        Vector3 pos = new Vector2(transform.position.x, transform.position.z); // 当前位置
        bool Ishit = Physics.Linecast(pos + dir, pos); // 从目标位置向当前位置发射一条射线，存储射线信息
        return Ishit; // 返回的射线是否可以打到吃豆人自身的碰撞器
    }
}
