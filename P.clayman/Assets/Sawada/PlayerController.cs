using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

     //速さ
    [SerializeField] private float Speed = 10;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey("right"))
        {
            this.transform.Translate(Speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey("left"))
        {
            this.transform.Translate(-Speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey("up"))
        {
            this.transform.Translate(0, 0, Speed * Time.deltaTime);
        }

        if (Input.GetKey("down"))
        {
            this.transform.Translate(0, 0, -Speed * Time.deltaTime);
        }
	}
}
