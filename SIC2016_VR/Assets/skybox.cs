using UnityEngine;
using System.Collections;

public class skybox : MonoBehaviour {

    public Material material1;
    public Material material2;
    public Material material3;
    public Material material4;
    public float timer;
    // Use this for initialization
    void Start () {
        RenderSettings.skybox = material1;
        timer = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {
        timer++;
        if (Input.GetKeyDown(KeyCode.Z))
        {
            RenderSettings.skybox = material1;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RenderSettings.skybox = material2;
        }
        if (timer > 120.0f && timer < 240.0f)
        {
            RenderSettings.skybox = material2;
        }
        else if (timer > 240.0f && timer < 360.0f)
        {
            RenderSettings.skybox = material3;
        }
        else if (timer > 360.0f)
        {
            RenderSettings.skybox = material4;
        }
        // material1.color = new Color(0, 0, 0, 0.0f);
    }
}
