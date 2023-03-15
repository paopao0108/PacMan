using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public string type; // 敌人类型

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
        // 1. 获取当前对象类型 type
        // 2. 根据类型设置初始位置
        Debug.Log("敌人类型：" + type + " 位置：" + Constant.Mapping.GhostPos[type]);
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
