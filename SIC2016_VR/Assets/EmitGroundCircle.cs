using UnityEngine;
using System.Collections;

public class EmitGroundCircle : MonoBehaviour {

    public Transform circle;
    public Animator swordAnim;

    public AudioClip audiclip;
    AudioSource audiosource;

    // Use this for initialization
    void Start () {
        audiosource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void MagicEnd()
    {
        audiosource.PlayOneShot(audiclip);
        audiosource.volume = 0.5f;
        Destroy(circle.gameObject);
        swordAnim.enabled = true;
    }
}
