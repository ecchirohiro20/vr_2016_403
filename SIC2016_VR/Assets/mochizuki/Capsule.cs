using UnityEngine;
using System.Collections;

public class Capsule : MonoBehaviour {

    public float horizontalSpeed = 0.1f;
    public float verticalSpeed = 0.1f;
    
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        //transform.position += new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

        float h = horizontalSpeed * Input.GetAxis("Horizontal");
        float v = verticalSpeed * Input.GetAxis("Vertical");
        transform.Rotate(v, h, 0);
    }
}
