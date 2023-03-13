using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        //CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
    //private Vector3 dest; // 目标位置
    //private Rigidbody rb;

    //public float speed = 1f;
    //public float angleSpeed = 0.5f;

    //void Start()
    //{
    //    rb = GetComponent<Rigidbody>();
    //    dest = transform.position; // 初始位置
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    Vector3 nextPos = Vector3.MoveTowards(transform.position, dest, speed); // 从transform.position最大距离不超过speed为移动步频移向dest
    //    rb.MovePosition(nextPos);
    //    if (transform.position == dest)
    //    {
    //        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && IsValidDirection(Vector3.forward))
    //        {
    //            Debug.Log("前");

    //            //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(Vector3.forward), angleSpeed);
    //            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), angleSpeed);
    //            dest = transform.position + Vector3.forward * Time.deltaTime; // (0,0,1)
    //                                                                          //dest = transform.position + Vector3.forward; // (0,0,1)
    //        }
    //        if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && IsValidDirection(Vector3.right))
    //        {
    //            Debug.Log("右");
    //            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 90, 0), angleSpeed);
    //            //dest = transform.position + Vector3.right * Time.deltaTime; // (0,0,1)
    //            dest = transform.position + Vector3.right; // (0,0,1)
    //        }
    //        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && IsValidDirection(Vector3.left))
    //        {
    //            Debug.Log("左");
    //            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, -90, 0), angleSpeed);
    //            //dest = transform.position + Vector3.left * Time.deltaTime; // (0,0,1)
    //            dest = transform.position + Vector3.left; // (0,0,1)
    //        }
    //        if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && IsValidDirection(Vector3.back))
    //        {
    //            Debug.Log("后");
    //            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 180, 0), angleSpeed);
    //            //dest = transform.position + Vector3.back; // (0,0,1)
    //            dest = transform.position + Vector3.back * Time.deltaTime; // (0,0,1)
    //        }
    //}


}

    //private bool IsValidDirection(Vector3 direction)
    //{
    //    Debug.Log("方向：" + direction);
    //    Ray ray = new Ray(transform.position, direction);
    //    RaycastHit raycastHit;
    //    bool isHit = Physics.Raycast(ray, out raycastHit, 0.5f);
    //    Debug.Log("是否检测到物体：" + isHit);
    //    if (isHit) Debug.Log("检测到的物体是： " + raycastHit.transform.name + "射线射到物体的点：" + raycastHit.point);
    //    return !isHit;
    //}
//}
