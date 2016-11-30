using UnityEngine;
using System.Collections;

public class Minotaur : MonoBehaviour
{
	public GameObject landingPos;   //着地地点
	private Vector3 keepJumpPos1;    //飛ぶ場所
	private Vector3 keepJumpPos2;    //飛ぶ場所

	private int hp;
	private int speed;
	private float jumpTime; //飛んでいる時間
	private bool jumpFlag;	//飛ぶ関数を呼ぶ 

	private Animator anim;

	public enum STATE
	{
	IDLE,
	JUMP,
	WALK,
	SHOUT,
	}
	private STATE state;		//ミノタウロスの状態

	// Use this for initialization
	void Start()
	{
		jumpTime = 0;
		anim = GetComponent<Animator>();
		state = STATE.IDLE;

		Vector3 moveDir;
		keepJumpPos1 = transform.position;
		keepJumpPos2 = transform.position + transform.forward * 10.0f;
		moveDir = Camera.main.transform.position - this.transform.position;
	}

	void Mode()
	{
	switch(state) {
			case STATE.IDLE:
				Idle();
				break;
			case STATE.JUMP:
				Jump();
				break;
			case STATE.WALK:
				Walk();
				break;
			case STATE.SHOUT:

				break;
		}
	}
	// Update is called once per frame
	void Update()
	{
		Mode();
	}

	void Idle()
	{
		anim.Play( "Idle" );
	}

	void Walk()
	{
		Vector3 moveDir;
		moveDir = Camera.main.transform.position - this.transform.position;
		this.transform.forward = moveDir;
		this.transform.position += moveDir * speed;
	}

	void Jump()
	{

	}

	void Shout()
	{
		anim.Play( "Shout" );
	}

	//----------------------------------
	//    アニメーションイベント用関数
	//----------------------------------


	public void JumpModeChange()
	{
		state = STATE.JUMP;
	}

	public void JumpFlagFalse()
	{
		state = STATE.IDLE;
	}

}