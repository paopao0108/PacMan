using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform pacMan;
    private Vector3 offset;
    void Start()
    {
        pacMan = GameObject.Find("Chomp").transform;
        offset = transform.position - pacMan.position;
    }

    void Update()
    {
        transform.position = offset + pacMan.position;
    }
}
