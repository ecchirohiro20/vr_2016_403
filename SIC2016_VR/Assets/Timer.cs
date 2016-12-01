using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
    public TextMesh hand;
    public TextMesh UI;
    float timer;
	float timeMax = 60.0f;
	// Use this for initialization
	void Start () {
        timer = 0;
        GetComponent<TextMesh>().text = "残り時間:" + (60 - (int)timer).ToString();
    }

    // Update is called once per frame
    void Update () {
		if( timer < timeMax ) {
			timer += Time.deltaTime;
			GetComponent<TextMesh>().text = "残り時間:" + ( 60 - (int)timer ).ToString();
            hand.text = "残り時間:" + (60 - (int)timer).ToString();
            UI.text = "残り時間:" + (60 - (int)timer).ToString();

        }
		else GameModeManager.SetSceneMode( GameModeManager.GAMEMODE.FINISH );
	}
}
