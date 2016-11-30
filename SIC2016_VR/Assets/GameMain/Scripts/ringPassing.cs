using UnityEngine;
using System.Collections;

public class ringPassing : MonoBehaviour {
    Vector3 pos;        //移動元
    public Vector3 moveVector; //移動量ベクトル
    public bool isActive;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        moveVector = transform.position - pos;
        pos = transform.position;

	}
}
