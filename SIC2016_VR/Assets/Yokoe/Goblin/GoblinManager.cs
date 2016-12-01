using UnityEngine;
using System.Collections;

public class GoblinManager : MonoBehaviour
{
	public GameObject goblin;           //ゴブリン
	private float createTime = 1.0f;    //生成する時間
	private float createCount;          //生成するカウント
	private float createPosX;           //生成する場所X
	private float createPosZ;           //生成する場所Z

	static public int goblinLife;       //今いてるゴブリンの数
	private int goblinLifeMax = 20;     //出てこれるゴブリンの数

    public Transform half;

	enum CREATEPOSITION
	{
		RIGHTFRONT = 0,
		//RIGHTBACK,
		LEFTFRONT,
		//LEFTBACK,
		MAX,
	}

	// Use this for initialization
	void Start()
	{
		createCount = 0;
		goblinLife = 0;
	}

	// Update is called once per frame
	void Update()
	{
		if( goblinLifeMax <= goblinLife ) return;

		createCount += Time.deltaTime;
		if( createCount > createTime ) {
			goblinLife++;
			createCount = 0;
			int random = Random.Range((int)CREATEPOSITION.RIGHTFRONT,(int)CREATEPOSITION.MAX);
            float length = (half.position - transform.position).magnitude;

            switch ( random ) {
				case (int)CREATEPOSITION.RIGHTFRONT:
					createPosX = Random.Range((length / 10.0f), length);
					createPosZ = Random.Range((length / 3.0f), length);
					break;
				//case (int)CREATEPOSITION.RIGHTBACK:
				//	createPosX = Random.Range((length / 2.0f), length);
				//	createPosZ = Random.Range( -(length / 2.0f), -length);
				//	break;
				case (int)CREATEPOSITION.LEFTFRONT:
					createPosX = Random.Range( -(length / 5.0f), -length);
					createPosZ = Random.Range((length / 3.0f), length);
					break;
				//case (int)CREATEPOSITION.LEFTBACK:
				//	createPosX = Random.Range( -(length / 2.0f), -length);
				//	createPosZ = Random.Range( -(length / 2.0f), -length);
				//	break;
			}

			Vector3 createPosition;
			createPosition.x = transform.position.x + createPosX;
			createPosition.y = transform.position.y;
            createPosition.z = transform.position.z + createPosZ;
			Instantiate( goblin , createPosition , Quaternion.identity );
		}
	}
}