using UnityEngine;
using System.Collections;

public class DestroyTimer : MonoBehaviour {

	public float time =2.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;

		if (time < 0) {
			Destroy (this.gameObject);
		}
	}
}
