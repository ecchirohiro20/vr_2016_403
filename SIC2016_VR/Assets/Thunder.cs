using UnityEngine;
using System.Collections;

public class Thunder : MonoBehaviour {

	public float EmitSpeed = 0.1f;
	float cnttime = 0;
    int Count = 0;
	public ParticleSystem thunder;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		cnttime += Time.deltaTime;
		if (cnttime > EmitSpeed)
		{
			if(Count > 0)
			{
				Count--;
				cnttime -= EmitSpeed;
				thunder.Emit(1);
            }
			if(cnttime > 3.0f)
			{
				Destroy(this.gameObject);
			}
		}
    }

	public void Init(float scale)
	{
		transform.localScale = new Vector3(scale, scale, scale);
		Count = 5 + (int)(scale * 3.0f);
	}
}
