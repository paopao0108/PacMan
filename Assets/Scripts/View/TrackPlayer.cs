using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TrackPlayer : MonoBehaviour
{
    //public NavMeshAgent agent;
    //public Transform[] Points;//ͨ��������ʽ�����ö������
    //int currentPoint;

    //void Start()
    //{
    //    agent = GetComponent<NavMeshAgent>();
    //    agent.SetDestination(Points[0].position);//ͨ��Nav Mesh Agent�����SetDestination ����������Ϊһ��Vector3Ŀ���
    //}

    //void Update()
    //{
    //    if (agent.remainingDistance < agent.stoppingDistance)//��Ŀ���ʣ������Ƿ�С��֮ǰ�� Inspector���������õ�ֹͣ����
    //    {
    //        currentPoint = (currentPoint + 1) % Points.Length;//����ȡ��ķ���ʵ�ֵ���Ѳ�߹켣��ѭ��
    //        agent.SetDestination(Points[currentPoint].position);
    //    }
    //}

    //�Զ�׷��angent
    private NavMeshAgent _mNavMeshAgent;

    //AIҪ׷�ٵ����壬���ǵ���ҵ�λ��
    public Transform playerTransform;
    // Start is called before the first frame update

    void Start()
    {
        _mNavMeshAgent = GetComponent<NavMeshAgent>();

        //����׷��ֹͣ��������룬С�ڵ���������壬�Ͳ����ڽ���׷�٣�����һ�����ͻ����׷��
        _mNavMeshAgent.stoppingDistance = 2.0f;

    }

    void Update()
    {
        //����Ŀ��λ��
        _mNavMeshAgent.SetDestination(playerTransform.position);
    }
}
