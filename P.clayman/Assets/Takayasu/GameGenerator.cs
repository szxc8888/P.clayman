using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGenerator : MonoBehaviour {

    public GameObject kabata;
    public GameObject[] enemy;
    private float timespan = 5.0f;
    private float time = 0.0f;

	// Use this for initialization
	void Start ()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > timespan)
        {
            GameObject go = Instantiate(kabata) as GameObject;
            int pos = Random.Range(0, 3);
            go.transform.position = enemy[pos].transform.position;
            time = 0;
            Debug.Log("Create Success");
        }
    }

    void OnCollisionEnter(Collision col)
    {
        
    }
}
