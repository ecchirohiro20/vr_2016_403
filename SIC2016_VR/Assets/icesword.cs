using UnityEngine;
using System.Collections;

public class icesword : MonoBehaviour {

    public bool death;
    public GameObject parent;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(death)
        {
            Destroy(parent);
        }
	}

    public void End()
    {
    }
}
