using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patroller : MonoBehaviour
{
    public Transform[] Points;//通过数组形式可设置多个监测点
    int currentPoint = 0; 
    public NavMeshAgent _mNavMeshAgent; // 自动追踪agent
    private float stopDistance = 1.0f;

    void Start()
    {
        _mNavMeshAgent = GetComponent<NavMeshAgent>();
        _mNavMeshAgent.stoppingDistance = stopDistance; //设置追踪停止的最近距离，小于等于这个具体，就不会在进行追踪，一旦超过就会继续追踪
        InitOrReset();
        GameEvent.gameStart.Register(StartTrack); // 注册开始追踪事件
        GameEvent.gameOver.Register(InitOrReset); // 
        //GameEvent.gameAgain.Register(InitOrReset);


        // 测试
        _mNavMeshAgent.SetDestination(Points[0].position);
    }

    void Update()
    {
        if (!GameModel.IsGameStart || GameModel.IsGameOver) return;
        if (_mNavMeshAgent.isStopped) return;
        //_mNavMeshAgent.SetDestination(playerTransform.position); //设置目标位置

        // 测试
        if (_mNavMeshAgent.remainingDistance < _mNavMeshAgent.stoppingDistance)//到目标的剩余距离是否小于之前在 Inspector窗口中设置的停止距离
        {
            currentPoint = (currentPoint + 1) % Points.Length;//采用取余的方法实现敌人巡逻轨迹的循环
            _mNavMeshAgent.SetDestination(Points[currentPoint].position);
        }



        Debug.Log("正在追踪！");
    }

    private void OnDestroy()
    {
        GameEvent.gameStart.UnRegister(StartTrack);
        GameEvent.gameOver.UnRegister(InitOrReset);
        //GameEvent.gameAgain.UnRegister(InitOrReset);
    }

    public void InitOrReset()
    {
        _mNavMeshAgent.isStopped = true;
    }

    public void StartTrack()
    {
        _mNavMeshAgent.isStopped = false;
    }
}
