using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TrackPlayer : MonoBehaviour
{
    public NavMeshAgent _mNavMeshAgent; // 自动追踪agent
    public Transform playerTransform; // 要追踪的物体
    private float stopDistance = 0f;

    void Start()
    {
        _mNavMeshAgent = GetComponent<NavMeshAgent>();
        _mNavMeshAgent.stoppingDistance = stopDistance; //设置追踪停止的最近距离，小于等于这个具体，就不会在进行追踪，一旦超过就会继续追踪
        InitOrReset();
        GameEvent.gameStart.Register(StartTrack); // 注册开始追踪事件
        GameEvent.gameOver.Register(InitOrReset); // 
        //GameEvent.gameAgain.Register(InitOrReset);
    }

    void Update()
    {
        if (!GameModel.IsGameStart || GameModel.IsGameOver) return;
        if (_mNavMeshAgent.isStopped) return;
        _mNavMeshAgent.SetDestination(playerTransform.position); //设置目标位置
        //Debug.Log("正在追踪！");
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
