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
    public AudioSource startAudio;

    private void Awake()
    {
        InitOrReset();
    }

    void Start()
    {
        GameEvt.gameAgain.Register(InitOrReset);
        //Debug.Log("倒计时：" + GameObject.Find("Time").transform.Find("countDown"));
    }

    private void Update()
    {
        if (!GameModel.IsSwitchCamera) return;
        if (transform.position.y > endPos.y) transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (transform.position.z < endPos.z) transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (Mathf.Abs(transform.position.y - endPos.y) < 0.1 &&
            Mathf.Abs(transform.position.z - endPos.z) < 0.1 &&
            transform.rotation.x > _endRot.x)
            transform.rotation = Quaternion.Lerp(transform.rotation, _endRot, angleSpeed * Time.deltaTime);
        if (IsReady())
        {
            if (!GameModel.IsReadying) GameObject.Find("Time").transform.Find("countDown").gameObject.SetActive(true);// 显示开始倒计时
            GameModel.IsSwitchCamera = false; 
            GameModel.IsReadying = true;
            gameObject.GetComponent<FollowPlayer>().enabled = true; // 启用相机跟随
        }
    }


    private void OnDestroy()
    {
        GameEvt.gameAgain.UnRegister(InitOrReset);
    }

    public void InitOrReset()
    {
        Debug.Log("重置相机位置");
        gameObject.GetComponent<FollowPlayer>().enabled = false; // 禁用相机跟随
        transform.position = _startPos;
        transform.rotation = _startRot;
    }

    // 相机是否准备就绪
    public bool IsReady()
    {
        return (Mathf.Abs(transform.position.y - endPos.y) < 0.1 && Mathf.Abs(transform.position.z - endPos.z) < 0.1 && Mathf.Abs(transform.rotation.x - _endRot.x) < 0.1f);
    }
}
