using UnityEngine;
using System.Collections;

public class thunderHand : MonoBehaviour {

	bool isCanAttack = false;

	public ParticleSystem cloud;

	public Thunder thunder;

	Vector3 before;

	float scale;

    float defscale;

	// Use this for initialization
	void Start () {
        defscale = transform.localScale.x;

    }
	
	// Update is called once per frame
	void Update () {
		if(isCanAttack)
		{

			float downSpeed = (before - transform.position).y;

			if (downSpeed > Time.deltaTime * 0.1f)
			{
				ThunderAttack();

			}
			before = transform.position;

		}
		else
		{

		}

	}

	public void ReadyAttack(float scale)
	{
		isCanAttack = true;
		this.scale = scale;
		before = transform.position;
		float thunderScale = defscale * (1.0f + scale * 0.3f);
		transform.localScale = new Vector3(thunderScale, thunderScale, thunderScale);
        cloud.Play();

    }

	public void ThunderAttack()
	{
		isCanAttack = false;
        cloud.Stop();
		Vector3 front = transform.forward;
		front.y = 0;
		front.Normalize();
		Vector3 emitpos = transform.position + (front * (0.4f + scale * 0.2f));

        GameObject obj = (GameObject)Instantiate(thunder.gameObject, emitpos, Quaternion.Euler(-90,0,0));

        Thunder emit = obj.GetComponent<Thunder>();

		emit.Init(scale);

	}
}
