using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform pacMan;
    private Vector3 offset;
    private Camera camera;
    void Start()
    {
        pacMan = GameObject.Find("Chomp").transform;
        camera = GetComponent<Camera>();
        offset = camera.endPos - pacMan.position;
    }

    void Update()
    {
        if (!GameController.GetInstance().IsGameStart) return;
        transform.position = offset + pacMan.position;
    }
}
