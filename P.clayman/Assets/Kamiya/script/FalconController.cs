using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(FixedJoint))]
public class FalconController : MonoBehaviour {

    public float rotateSpeed = 1.0f;
    public float scrollSpeed = 200.0f;

    public Rigidbody rb;
    bool flg = false;
    public Transform pivot;
    private FixedJoint joint;

    Vector3 ofset = Vector3.zero;   // Vector3.zero == Vector3(0,0,0)

    [System.Serializable]
    public class Coordinate
    {
        public float _azimuth;

        public float radius;

        public float azimuth
        {
            get { return _azimuth;}
            private set
            {
                _azimuth = Mathf.Repeat(value, _maxAzimuth - _minAzimuth);
            }
        }

        public float _minRadius = 0f;
        public float _maxRadius = 20.0f;

        public float minAzimuth = 0.0f;
        private float _minAzimuth;

        public float maxAzimuth = 360.0f;
        private float _maxAzimuth;


        public Coordinate(Vector3 coordinate)
        {
            _minAzimuth = Mathf.Deg2Rad * minAzimuth;
            _maxAzimuth = Mathf.Deg2Rad * maxAzimuth;

            radius = coordinate.magnitude;
            azimuth = Mathf.Atan2(coordinate.z, coordinate.x);
        }

        public Vector3 toCarsian
        {
            get
            {
                float t = radius;
                return new Vector3(t * Mathf.Cos(azimuth), radius * Mathf.Sin(0), t * Mathf.Sin(azimuth));
            }
        }

        public Coordinate Rotate(float newAzimuth, float newElevation)
        {
            azimuth += newAzimuth;
            return this;
        }

        public Coordinate TranslateRadius(float x)
        {
            radius += x;
            return this;
        }
    }

    public Coordinate coordinate;

	// Use this for initialization
	void Start () {

        joint = GetComponent<FixedJoint>();

        coordinate = new Coordinate(transform.position);

        ofset = pivot.position - transform.position;    //2点間の距離をVector3 ofset に代入
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Z))
        {
            flg = true;
        }

        if (flg == false)
        {
            float h = Input.GetAxis("Horizontal");

            if (h * h > Mathf.Epsilon)      //鷹の円周回転移動
            {
                transform.position = coordinate.Rotate(h * rotateSpeed * Time.deltaTime, transform.position.y).toCarsian + pivot.position;
            }
        }
        else if (flg == true)
        {
            transform.Translate(ofset.x * Time.deltaTime, 0, ofset.z * Time.deltaTime, Space.World);
            transform.LookAt(pivot.position);

        }

    }

    private void OnTriggerStay(Collider other)
    {
        other.transform.parent = this.transform;
    }


}
