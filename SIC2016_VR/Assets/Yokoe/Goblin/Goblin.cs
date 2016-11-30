using UnityEngine;
using System.Collections;

public class Goblin : MonoBehaviour
{
	public GameObject playerPos;
	private int rand;         //速さの調整
	private float speed;      //速さ
	private Animation anim;   //アニメーション
	private bool stopFlag;    //止まるフラグ

	private bool deathFlag;             //死んだとき
	private float deathTime;            //死んだら動く
	private float deathTimeMax = 0.1f;  //消えるまでの最大時間

	private DeleteCount deleteCount;

	public AudioSource soundOutbreak;
	public AudioSource soundOutbreak1;
	public AudioSource soundNear;
	public AudioSource soundNear1;
	public AudioSource soundAttack;
	public AudioSource soundDie;
	private int shoutMax = 2;
	private bool[] soundFlag = new bool[2];

	public GameObject fireEffect;

	// Use this for initialization
	void Start()
	{
		rand = Random.Range( 1 , 10 );
		speed = rand * 0.005f;
		anim = GetComponent<Animation>();
		if( rand < 5 ) {
			anim.Play( "walk" );
			//soundOutbreak.PlayOneShot( soundOutbreak.clip ); //出てきた瞬間にも声出す

		}
		else {
			anim.Play( "run" );
			//soundOutbreak1.PlayOneShot( soundOutbreak1.clip ); //出てきた瞬間にも声出す
		}

		stopFlag = false;
		deathFlag = false;
		deathTime = 0;

		for(int i = 0 ;i < shoutMax ;i++ ) { soundFlag[i] = true; }

		deleteCount = GameObject.Find( "DeleteCount" ).GetComponent<DeleteCount>();
  }

	// Update is called once per frame
	void Update()
	{
        if (GameModeManager.GetMode() == GameModeManager.GAMEMODE.FINISH)
        {
            deathFlag = true;
        }

		DestroyGoblin();  //死ぬ処理

		if( stopFlag == true ) return;

		//transform.forward = -Camera.main.transform.forward;　//カメラのほうむく
		Vector3 moveDir = Camera.main.transform.position - this.transform.position; //ゴブリンからメインカメラへの向き
		moveDir.y = 0;

		//近くにきたら音出す処理　距離によって出すようにする
		if( moveDir.magnitude < 10.0f && soundFlag[0] ) {
			soundFlag[0] = false;
			soundNear.PlayOneShot( soundNear.clip ); 
		}
		if( moveDir.magnitude < 5.0f && soundFlag[1] ) {
			soundFlag[1] = false;
			soundNear1.PlayOneShot( soundNear1.clip );
		}
		//近くにきすぎないようにする
		if( moveDir.magnitude < 0.5f ) return;

		moveDir.Normalize();
		transform.forward = moveDir;
		transform.position += moveDir * speed * transform.lossyScale.x / 1.365387f;
	}

	void OnCollisionEnter( Collision collision )
	{
		switch( collision.transform.tag ) {
			case "Player":
				stopFlag = true;
				anim.Play( "attack1" );
				break;
			case "Magic":
				anim.Play( "death" );
				soundAttack.PlayOneShot( soundDie.clip );
				deathFlag = true;
				stopFlag = true;
				fireEffect.SetActive( true );
        break;
		}
	}

	void OnTriggerEnter( Collider collision )
	{
		switch( collision.transform.tag ) {
			case "Player":
				stopFlag = true;
				anim.Play( "attack1" );
				break;
			case "Magic":
				anim.Play( "death" );
				deathFlag = true;
				stopFlag = true;
				fireEffect.SetActive( true );

				break;
		}
	}

	void OnParticleCollision( GameObject collision )
	{
		switch( collision.transform.tag ) {
			case "Magic":
				anim.Play( "death" );
				deathFlag = true;
				stopFlag = true;
				fireEffect.SetActive( true );
				break;
		}
	}

	public void DestroyGoblin()
	{
		if( deathFlag == true ) {
			deathTime += Time.deltaTime;
			if( deathTimeMax < deathTime ) {
				GoblinManager.goblinLife--;
				deleteCount.CountPlus();
				Destroy( this.gameObject );
			}
		}
	}
}
