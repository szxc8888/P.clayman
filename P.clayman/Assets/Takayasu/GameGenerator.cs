using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGenerator : MonoBehaviour {

    public GameObject Enemy;
    public float span = 1.0f;
    float delta = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.delta += Time.deltaTime;
        if(this.delta > this.span) {
            this.delta = 0;
            GameObject enemy = Instantiate(Enemy) as GameObject;
            float x = Random.Range(-300, 300);
            float z = Random.Range(0, 200);
            enemy.transform.position = new Vector3(x, 20, z);
        }
	}
}
