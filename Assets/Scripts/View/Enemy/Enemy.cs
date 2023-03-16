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
        GameEvt.gameAgain.Register(InitOrReset);
    }

    private void OnDestroy()
    {
        GameEvt.gameAgain.UnRegister(InitOrReset);
    }

    public void InitOrReset()
    {
        // 1. 获取当前对象类型 type
        // 2. 根据类型设置初始位置
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
