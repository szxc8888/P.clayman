using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject Rhand;
    public GameObject Lhand;

    private float maxAngle = 90;
    private float minAngle = -90;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float Rotate = Input.GetAxis("Horizontal");

        //現在の角度を0～360から-180～180に変換
        float rotateY = (Rhand.transform.eulerAngles.y > 180) ? Rhand.transform.eulerAngles.y - 360 : Rhand.transform.eulerAngles.y;

        //現在の回転角度に入力を加味した回転角度をMathf.Clampで制限
        float angleY = Mathf.Clamp(rotateY + Rotate, minAngle, maxAngle);

        //回転角度を-180～180から0～360に変換
        angleY = (angleY < 0) ? angleY + 360 : angleY;

        //回転角度をオブジェクトに適用
        Rhand.transform.rotation = Quaternion.Euler(0, angleY, 0);

    }
}