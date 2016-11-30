using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

    public SteamVR_TrackedObject controller;
    public GameObject emit;
    public ParticleSystem fire;

    // Use this for initialization
    void Start () {
	    
	}

    // Update is called once per frame
    void Update()
    {
        SteamVR_TrackedObject trackedObject = controller;
        var device = SteamVR_Controller.Input((int)controller.index);


        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            GameObject trans = (GameObject)Instantiate(emit, transform.position, transform.rotation);
            fire.Emit(30);

            trans.transform.position = trans.transform.position + trans.transform.forward * 0.5f;

            trans.GetComponent<Rigidbody>().velocity = trans.transform.forward * 10.0f;
        }
    }
}
