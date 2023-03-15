using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public string type; // ��������

    void Start()
    {
        InitOrReset();
        GameEvent.gameAgain.Register(InitOrReset);
    }

    void Update()
    {
    }

    private void OnDestroy()
    {
        GameEvent.gameAgain.UnRegister(InitOrReset);
    }

    public void InitOrReset()
    {
        // 1. ��ȡ��ǰ�������� type
        // 2. �����������ó�ʼλ��
        Debug.Log("�������ͣ�" + type + " λ�ã�" + Constant.Mapping.GhostPos[type]);
        transform.localPosition = Constant.Mapping.GhostPos[type];
    }

    //private void Sleep(NavMeshAgent g)
    //{
    //    g.updatePosition = false;
    //    g.updateRotation = false;
    //}

    //private void Move(Transform t, NavMeshAgent g, Vector3 destination)
    //{
    //    g.updatePosition = true;
    //    g.updateRotation = true;
    //    g.SetDestination(destination);
    //    t.LookAt(destination);
    //}
}
