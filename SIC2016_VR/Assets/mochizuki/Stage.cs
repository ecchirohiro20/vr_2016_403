using UnityEngine;
using System.Collections;

public class Stage : MonoBehaviour {

    public AnimationCurve curve;

    public Material material;

    public float timer;
    public GameObject gameObject;

    // Use this for initialization
    void Start()
    {
        RenderSettings.skybox = material;
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        material.SetFloat("_SkyBlend", curve.Evaluate(timer / 60));
        if (timer > 20 ) Destroy(gameObject);
       // Destroy(gameObject);

    }
   
}
