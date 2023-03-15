using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotManager : MonoBehaviour
{
    public Dot[] dots;
    public static int dotsCount;

    private void Awake()
    {
        dots = GetComponentsInChildren<Dot>();
        dotsCount = dots.Length;
        //Debug.Log("����������" + dotsCount);
    }

    private void Start()
    {
        InitOrReset();
        GameEvent.gameAgain.Register(InitOrReset);
    }

    private void OnDestroy()
    {
        GameEvent.gameAgain.UnRegister(InitOrReset);
    }

    public void InitOrReset()
    {
        //Debug.Log("����������" + dotsCount);
        foreach( Dot dot in dots)
        {
            //Debug.Log("���ӣ�" + dot);
            dot.Appear();
        }
    }
}
