using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Renderer))]
public class MovieStarter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		((MovieTexture)(GetComponent<Renderer>().material.mainTexture)).Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
