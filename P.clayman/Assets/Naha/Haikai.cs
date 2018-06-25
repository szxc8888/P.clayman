using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Haikai : MonoBehaviour
{


    // プレイヤーの速度
    public float speed = 1.0f;
    public float rotationSmooth = 2f;
    public Vector3 targetPosition;
    public float changeTargetSqrDistance = 40f;

    public float pause_timer;
    public float pause_timer_2;

    void Start()
    {
        targetPosition = GetRandomPositionOnLevel();
    }

    void Update()
    {
        if (pause_timer < 0.7f)
        {
            pause_timer += Time.deltaTime;
            //待ち時間がまだ経過してないので何もしないで抜ける
            return;
        }
        else
        {
            //目的地設定、移動処理
            pause_timer_2 += Time.deltaTime;
            if (pause_timer_2 > 10f)
            {
                pause_timer = 0;
                pause_timer_2 = 0;
            }
        }
        // 現在地から目標地点までの距離を取得、短かったならもう一度目標地点を設定しなおす
        float sqrDistanceToTarget = Vector3.SqrMagnitude(transform.position - targetPosition);
        if (sqrDistanceToTarget < changeTargetSqrDistance)
        {
            targetPosition = GetRandomPositionOnLevel();

        }
        // 目標地点の方向を向く
        Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSmooth);

        // 前方に進む
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public Vector3 GetRandomPositionOnLevel()
    {
        // 動き回る範囲
        float levelSize = 8f;

        // この関数を開始する直前の位置へ戻る
        return new Vector3(Random.Range(-levelSize, levelSize), 0, Random.Range(-levelSize, levelSize));
    }
}