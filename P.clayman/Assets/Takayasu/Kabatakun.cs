using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kabatakun : MonoBehaviour
{
    public float speed = 50.0f;
    private Transform enemy;
    private Animator animator;

    float time = 2;

    private void Start()
    {
        // 城の位置取得
        enemy = GameObject.FindWithTag("Castle").transform;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // 城の位置を向く
        //Quaternion targetRotation = Quaternion.LookRotation(enemy.position - transform.position);
        //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);

        // 前方に進む
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    // 衝突
    void OnCollisionEnter(Collision col)
    {
            // 消える
            Destroy(gameObject);
    }
}
