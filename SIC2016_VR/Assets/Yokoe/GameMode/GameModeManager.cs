using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameModeManager : MonoBehaviour
{
	public GameObject[] scene = new GameObject[3];
	public GameObject gameFont;
	public SteamVR_TrackedObject right;
	public SteamVR_TrackedObject left;

	public enum GAMEMODE
	{
		START,
		MAIN,
		FINISH,
		ROAD
	}
	private static GAMEMODE mode;

	// Use this for initialization
	void Start()
	{
		mode = GAMEMODE.START;
	}

	// Update is called once per frame
	void Update()
	{

		switch( mode ) {
			case GAMEMODE.START:
				scene[(int)GAMEMODE.START].SetActive( true );
				scene[(int)GAMEMODE.MAIN].SetActive( false );
				scene[(int)GAMEMODE.FINISH].SetActive( false );
				gameFont.SetActive( false );
        break;
			case GAMEMODE.MAIN:
				scene[(int)GAMEMODE.START].SetActive( false );
				scene[(int)GAMEMODE.MAIN].SetActive( true );
				scene[(int)GAMEMODE.FINISH].SetActive( false );
				gameFont.SetActive( true );
				break;
			case GAMEMODE.FINISH:
				scene[(int)GAMEMODE.START].SetActive( false );
				scene[(int)GAMEMODE.MAIN].SetActive( false );
				scene[(int)GAMEMODE.FINISH].SetActive( true );
				gameFont.SetActive( true );
				//終了時にロードする
				SceneLoad();
				break;
			case GAMEMODE.ROAD:
				int sceneIndex = SceneManager.GetActiveScene().buildIndex;
				SceneManager.LoadScene( sceneIndex );
				break;
		}
	}

	void SceneLoad()
	{
		//レバーを深く握るとロード
		//right = GetComponent<SteamVR_TrackedObject>();	
		//left = GetComponent<SteamVR_TrackedObject>();
		var device = SteamVR_Controller.Input((int) right.index);
		var device1 = SteamVR_Controller.Input((int) left.index);

		if( device.GetPressDown( SteamVR_Controller.ButtonMask.Touchpad) || device1.GetPressDown( SteamVR_Controller.ButtonMask.Touchpad) ) {
			int sceneIndex = SceneManager.GetActiveScene().buildIndex;
			SceneManager.LoadScene( sceneIndex );
		}
	}

	static public void SetSceneMode( GAMEMODE setMode )
	{
		mode = setMode;
	}
    static public GAMEMODE GetMode()
    {
        return mode;
    }
}
