using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform pacMan;
    private Vector3 offset;
    void Start()
    {
        offset = this.transform.position - pacMan.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = offset + pacMan.position;
    }
}
