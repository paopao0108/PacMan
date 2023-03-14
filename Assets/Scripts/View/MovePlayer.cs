using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private int angle = 0;
    public float angleSpeed = 0.5f;
    public float speed = 10.0f;

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vetical = Input.GetAxis("Vertical");
        Debug.Log("h: " + horizontal + " v: " + vetical);
        //transform.Translate(horizontal * speed * Time.deltaTime,  0, vetical * speed * Time.deltaTime);
        if (vetical != 0 || horizontal != 0) transform.Translate(0,  0, speed * Time.deltaTime); // 按物体正方向移动
        //或
        //transform.position += new Vector3(horizontal * speed * Time.deltaTime, vetical * speed * Time.deltaTime, 0);

        Direction(horizontal, vetical);
        Debug.Log("旋转角度：" + angle);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, angle, 0), angleSpeed);
    }

    public void Direction(float h, float v)
    {
        if (v == 0 && h != 0) angle = h > 0 ? 90 : -90;
        else if (h == 0 && v != 0) angle = v > 0 ? 0 : 180;
    }
}