using UnityEngine;
using System.Collections;

public class GroundMagicCircleMaker : MonoBehaviour {

    public bool isRendering = false;

    float charge = .0f;
    float CanShoot = 2.0f;

    public MagicCircleMaker circlemaker;

    public EmitGroundCircle circle;

    EmitGroundCircle emit;

    public Collider groundArea;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(isRendering)
        {
            charge += Time.deltaTime;

            float rate = charge / CanShoot;
            emit.transform.localScale = new Vector3(rate, rate, rate);
            if (circlemaker.IsLineRendering())
            {
                RenderEnd();
                return;
            }

        }
	
	}

    public void RenderStart()
    {
        Ray ray = new Ray(transform.position, Vector3.up);
        RaycastHit hit;
        if(groundArea.Raycast(ray, out hit,100.0f))
        {
            isRendering = true;
            Vector3 forward = transform.forward;
            forward.y = .0f;
            forward.Normalize();
            emit = ((GameObject)Instantiate(circle.gameObject,transform.position,Quaternion.LookRotation(forward))).GetComponent<EmitGroundCircle>();
            emit.transform.localScale = Vector3.zero;
        }
    }

    public void RenderEnd()
    {
        isRendering = false;
        charge = .0f;
        if(emit)
        {
            Destroy(emit.gameObject);
        }
    }

    public void TriggerExit()
    {
        if(charge > CanShoot)
        {
            emit.MagicEnd();
            emit.transform.DetachChildren();
        }
        RenderEnd();
    }

}
