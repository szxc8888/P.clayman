using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hawkcontroller : MonoBehaviour {

    public float speed = 5.0f;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        //移動
        if (Input.GetKey("up"))
        {
            transform.positionx += transform.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey("down"))
        {

            transform.position -= transform.forward * speed * Time.deltaTime; 
        }

        if (Input.GetKey("right"))
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }

        if (Input.GetKey("left"))
        {
            transform.position -= transform.right * speed * Time.deltaTime;
        }
	}
}
