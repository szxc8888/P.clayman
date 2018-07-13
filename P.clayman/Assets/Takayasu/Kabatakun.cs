using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kabatakun : MonoBehaviour
{
    private float speed = 50.0f;
    private Transform enemy;

    private void Start()
    {
        // 城の位置取得
        enemy = GameObject.FindWithTag("Player").transform;
        GetComponent<ParticleSystem>().Stop();
    }

    private void Update()
    {
        // 城の位置を向く
        Quaternion targetRotation = Quaternion.LookRotation(enemy.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);

        // 前方に進む
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    // 衝突
    void OnCollisionEnter(Collision col)
    {
        GetComponent<ParticleSystem>().Play();
        // 消える
        Destroy(gameObject);

       
    }
}
