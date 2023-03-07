using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacMan : MonoBehaviour
{
    public float speed = 0.1f;

    private Vector3 dest = Vector3.zero;
    private float angleSpeed = 100; // ��ת�Ľ��ٶ�


    private void Start()
    {
        dest = transform.position; // ��ʼ���Զ��˵�Ŀ��λ�ã���Ϸ��ʼ��֤�Զ��˲����ƶ���
    }

    private void FixedUpdate()
    {
        Vector3 temp = Vector3.MoveTowards(transform.position, dest, speed); // ��ȡ��һ���ƶ�������

        GetComponent<Rigidbody>().MovePosition(temp); // ���ø��彫�����ƶ�����һ�ε�����λ��

        if (transform.position == dest) // �������Ѿ�������һ��Ŀ������󣬲ſ��Լ����ƶ�
        {
            if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && ValidDirection(Vector3.forward))
            {
                Debug.Log("ǰ");
                dest = transform.position + Vector3.forward; // (0,0,1)
                //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(Vector3.forward), angleSpeed*Time.deltaTime);
            }
            if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && ValidDirection(Vector3.forward))
            {
                Debug.Log("��");
                dest = transform.position + Vector3.back;
                //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(Vector3.back), angleSpeed * Time.deltaTime);
            }
            if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && ValidDirection(Vector3.forward))
            {
                Debug.Log("��");
                dest = transform.position + Vector3.left;
                //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(Vector3.left), angleSpeed * Time.deltaTime);
            }
            if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && ValidDirection(Vector3.forward))
            {
                Debug.Log("��");
                dest = transform.position + Vector3.right;
                //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(Vector3.right), angleSpeed * Time.deltaTime);

            }
        }
    }

    /// <summary>
    /// ��֤ǰ�������Ƿ���Ч
    /// </summary>
    /// <param name="direction"></param>
    /// <returns></returns>
    private bool ValidDirection(Vector3 direction)
    {
        Vector2 dir = new Vector2(direction.x, direction.z); // Ŀ�귽��
        Vector2 pos = new Vector2(transform.position.x, transform.position.z); // ��ǰλ��
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos); // ��Ŀ��λ����ǰλ�÷���һ�����ߣ��洢������Ϣ
        return hit.collider == GetComponent<Collider>(); // ���ص������Ƿ���Դ򵽳Զ����������ײ��
    }
}
