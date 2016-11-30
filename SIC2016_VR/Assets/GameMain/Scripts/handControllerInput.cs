using UnityEngine;
using System.Collections;

public class handControllerInput : MonoBehaviour {

    public MagicCircleMaker circlemaker;
    public GroundMagicCircleMaker groundcirclemaker;
    public SteamVR_TrackedObject controller;
    public ringPassing ringpassing;
    public thunderHand thunderhand;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        SteamVR_TrackedObject trackedObject = controller;
        var device = SteamVR_Controller.Input((int)controller.index);


        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
           
            circlemaker.RenderStart();
            groundcirclemaker.RenderStart();
            //if(thunderhand != null)
            //    thunderhand.ReadyAttack(1.0f);
        }

        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            circlemaker.RenderEnd();
            groundcirclemaker.TriggerExit();

        }

        if (!device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
        {
            ringpassing.isActive = true;
        }
        else
        {
            ringpassing.isActive = false;
        }
    }
}
