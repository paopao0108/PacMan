using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacMan : MonoBehaviour
{
    //private Vector3 dest; // Ŀ��λ��
    private Rigidbody rb;
    private Vector3 move;
    private float forwardAmount;
    private float turnAmount;
    private float forwardSpeed = 0.5f;
    private float turnSpeed = 10f;

    //public float speed = 1f;
    public float angleSpeed = 0.5f;

    public Score score;

    void Start()
    {
        //dest = transform.position; // ��ʼλ��
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 0, 0);
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        move = new Vector3(x, 0, z);
        Vector3 localMove = transform.InverseTransformVector(move);
        forwardAmount = localMove.z;
        turnAmount = Mathf.Atan2(localMove.x, localMove.z);
    }

    private void FixedUpdate()
    {
        rb.AddForce(forwardAmount * transform.forward * forwardSpeed, ForceMode.VelocityChange);
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0, turnAmount * turnSpeed, 0));

        //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, turnAmount * turnSpeed, 0), angleSpeed);

        ////�����յ��������÷�����һֱƮ��
        //GetComponent<Rigidbody>().velocity = Vector3.zero; //�� Vector3.zero = new Vector3(0, 0, 0)��

        //if (transform.position == dest)
        //{
        //    if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)))
        //    {
        //        Debug.Log("ǰ");
        //        //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(Vector3.forward), angleSpeed);
        //        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), angleSpeed);
        //        dest = transform.position + Vector3.forward * Time.deltaTime; // (0,0,1)
        //                                                                      //dest = transform.position + Vector3.forward; // (0,0,1)
        //    }
        //    if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)))
        //    {
        //        Debug.Log("��");
        //        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 90, 0), angleSpeed);
        //        //dest = transform.position + Vector3.right * Time.deltaTime; // (0,0,1)
        //        dest = transform.position + Vector3.right; // (0,0,1)
        //    }
        //    if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)))
        //    {
        //        Debug.Log("��");
        //        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, -90, 0), angleSpeed);
        //        //dest = transform.position + Vector3.left * Time.deltaTime; // (0,0,1)
        //        dest = transform.position + Vector3.left; // (0,0,1)
        //    }
        //    if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)))
        //    {
        //        Debug.Log("��");
        //        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 180, 0), angleSpeed);
        //        //dest = transform.position + Vector3.back; // (0,0,1)
        //        dest = transform.position + Vector3.back * Time.deltaTime; // (0,0,1)
        //    }
        //}

        //Vector3 nextPos = Vector3.MoveTowards(transform.position, dest, speed); // ��transform.position�����벻����speedΪ�ƶ���Ƶ����dest
        //rb.MovePosition(nextPos);
    }

    private void OnTriggerEnter(Collider collision)
    {
        //��ײ������Ϸ��������
        Debug.Log("PacMan�������壺" + collision.gameObject.name);
        if (collision.gameObject.name == "Dot")
        {
            collision.gameObject.GetComponent<Dot>().Dispear(); // �Ե�����
            ScoreChangeEvent.Trigger(); // ����ҳ��
            GameService.GetInstanvce().GameOver();
        }
    }
}
