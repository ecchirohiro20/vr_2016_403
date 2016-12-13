using UnityEngine;
using System.Collections;

public class moon : MonoBehaviour {

    private float timer;

	// Use this for initialization
	void Start () {
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if(GameModeManager.instance.scene[(int)GameModeManager.GAMEMODE.START].activeInHierarchy == false)
        {
           timer += 0.001f;
           transform.position += new Vector3(-0.008f, -0.005f, 0.0f) * timer;

        }

    }
}
