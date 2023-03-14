using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Vector3 _startPos = new Vector3(0, 12, 0);
    private Quaternion _startRot = Quaternion.Euler(90, 0, 0);
    private Quaternion _endRot = Quaternion.Euler(55, 0, 0);

    private float speed = 10;
    private float angleSpeed = 5f;


    public Vector3 endPos = new Vector3(0, 3, 1.5f);

    private void Awake()
    {
        InitOrReset();
    }
    void Start()
    {
        
    }

    private void Update()
    {
        if (!GameController.GetInstance().IsSwitchCamera) return;
        if (transform.position.y > endPos.y) transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (transform.position.z < endPos.z) transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (Mathf.Abs(transform.position.y - endPos.y) < 0.1 &&
            Mathf.Abs(transform.position.z - endPos.z) < 0.1 &&
            transform.rotation.x > _endRot.x) 
            transform.rotation = Quaternion.Lerp(transform.rotation, _endRot, angleSpeed*Time.deltaTime);
        if (IsReady()) GameController.GetInstance().IsReadying = true;
    }

    public void InitOrReset()
    {
        transform.position = _startPos;
        transform.rotation = _startRot;
    }


    public bool IsReady()
    {
        return (Mathf.Abs(transform.position.y - endPos.y) < 0.1 && Mathf.Abs(transform.position.z - endPos.z) < 0.1 && Mathf.Abs(transform.rotation.x - _endRot.x) < 0.1f);
    }
}