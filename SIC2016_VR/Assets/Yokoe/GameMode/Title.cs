using UnityEngine;
using System.Collections;

public class Title : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnCollisionEnter( Collision collision )
	{
		switch( collision.transform.tag ) {
			case "Magic":
				GameModeManager.SetSceneMode( GameModeManager.GAMEMODE.MAIN );
				break;
		}
	}

	void OnTriggerEnter( Collider collision )
	{
		switch( collision.transform.tag ) {
			case "Magic":
				GameModeManager.SetSceneMode( GameModeManager.GAMEMODE.MAIN );
				break;
		}
	}

	void OnParticleCollision( GameObject collision )
	{
		switch( collision.transform.tag ) {
			case "Magic":
				GameModeManager.SetSceneMode( GameModeManager.GAMEMODE.MAIN );
				break;
		}
	}
}
