using UnityEngine;
using System.Collections;

public class MagicCircle : MonoBehaviour {

	public Transform half;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update()
	{

	}
	public float GetSize()
	{
		return (transform.position - half.position).magnitude * 2.0f;
    }
}
