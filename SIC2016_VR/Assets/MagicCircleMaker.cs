using UnityEngine;
using System.Collections;

public class MagicCircleMaker : MonoBehaviour {

	const int MaxVertices = 300;
	int curVertices = 0;

	public Transform head;

	public MagicCircle circle;

	public Vector3[] point = new Vector3[MaxVertices];
	public Vector3[] vec = new Vector3[MaxVertices];

    public TextMesh text;

	Vector3 preCenter = new Vector3();
	Vector3 Front = new Vector3();


	public float MinDistance;

	public float nearDist;

	public float minCircleMakeDist;
	float curDist;

	public bool isRendering = false;

	LineRenderer _lineRender;

	LineRenderer lineRender
	{
		get
		{
			if (_lineRender == null)
			{
				_lineRender = GetComponent<LineRenderer>();
			}
			return _lineRender;
        }


				
    }


	void VerticesUpdate()
	{
		lineRender.SetVertexCount(curVertices);
        if(curVertices >= 2)
		lineRender.SetPositions(point);

	}
	// Use this for initialization
	void Start () {
		RenderEnd();
		//RenderStart();

    }

	public void RenderStart()
	{
		isRendering = true;
		curVertices = 0;
		point[curVertices] = transform.position;
        preCenter = Vector2.zero;
        Front = Vector3.zero; 
        preCenter += point[curVertices];
		curVertices++;

		VerticesUpdate();
    }

    public bool IsLineRendering()
    {
        return curVertices > 1;
    }

	public void RenderEnd()
	{
		isRendering = false;
		lineRender.SetVertexCount(0);
		curDist = 0;
    }



	// Update is called once per frame
	void Update ()
    {
        if (text != null)
        {
            text.text = "pos" + transform.position + "\n" +
                "curdist" + curDist + "\n" +
                "MinDistance" + MinDistance + "\n" +
                "nearDist" + nearDist + "\n" +
                "preCenter" + (preCenter / curVertices) + "\n"+
                "Front" + Front + "\n" ;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            RenderStart();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            RenderEnd();
        }
        if (isRendering == true)
		{
			Vector3 pos = transform.position;

			if((point[curVertices - 1] - pos).magnitude > MinDistance)
			{
                //Debug.Log("魔方陣に必要距離を獲得");
                point[curVertices] = pos;
				preCenter += point[curVertices];
				curVertices++;
				curDist += (point[curVertices - 1] - point[curVertices - 2]).magnitude;
				vec[curVertices - 1] = (point[curVertices] - point[curVertices - 1]).normalized;

				if(curVertices >= 2)
				{
					Front += Vector3.Cross(vec[curVertices - 2], vec[curVertices - 1]).normalized;
				}
                VerticesUpdate();
			}

			if(curDist > minCircleMakeDist)
			{

                //Debug.Log("魔方陣に必要な距離を獲得");
				if((point[0] - pos).magnitude < nearDist)
				{
                    Debug.Log("中央に近づいた");
                    //魔法陣ちゃんとできてんの？

                    //仮の中央

                    preCenter /= curVertices;

					//前方向
					Front.Normalize();



					//判定
					bool makeCircle = true;
                    Vector3 before = Vector3.zero;
                    for (int i = 0; i < curVertices; i++)
                    {
                        Vector3 sub = point[i] - preCenter;
                        if (i != 0)
                        {
                            Front += Vector3.Cross(sub.normalized, before.normalized).normalized;
                        }

                        before = sub;

                    }
                    Front.Normalize();

                    float maxMisscount = 0.6f; //6回連続でずれると作らない
					int curMiss = 0;
					//for (int i = 0; i < curVertices - 3; i++)
					//{
     //                   Vector3 vec1 = (vec[i] - Front * Vector3.Dot(Front, vec[i])).normalized;
     //                   Vector3 vec2 = (vec[i + 4] - Front * Vector3.Dot(Front, vec[i + 4])).normalized;
     //                   Vector3 temp= Vector3.Cross(vec1,vec2).normalized;

					//	if(Vector3.Dot(temp,Front) <  0)
					//	{
					//		curMiss++;

					//	}
					//}
                    //if (curMiss > maxMisscount * curVertices)
                    //    makeCircle = false;

					if(Vector3.Dot((preCenter - head.position).normalized, Front) <.0f)
					{
						Front = -Front;
                    }

                        Vector3 Center = new Vector3();
						Vector3 max = new Vector3(float.MinValue, float.MinValue);
						Vector3 min = new Vector3(float.MaxValue, float.MaxValue);
						Vector3 Right = Vector3.Cross(Vector3.up, Front).normalized;
						Vector3 Up = Vector3.Cross(Front, Right).normalized;


                        for (int i = 0; i < curVertices; i++)
						{
							Vector3 sub = point[i] - preCenter;
							float YAxis = Vector3.Dot(sub, Up);
							float XAxis = Vector3.Dot(sub, Right);
							if (min.y > YAxis)
							{
								min.y = YAxis;
                            }
							if (max.y < YAxis)
							{
								max.y = YAxis;
							}
							if (min.x > XAxis)
							{
								min.x = XAxis;
							}
							if (max.x < XAxis)
							{
								max.x = XAxis;
							}

                        }

                        float length = ((max.x - min.x) + (max.y - min.y)) / 2.0f;
						Center = preCenter;
						Center += (max.y + min.y) * 0.5f * Up;
					    Center += (max.x + min.x) * 0.5f * Right;

                        float avg = .0f;
                        for (int i = 0; i < curVertices; i++)
                        {
                            Vector3 len = Center - point[i];
                            float temp = (len - Front * Vector3.Dot(Front, len)).magnitude;
                            avg += temp;
                            if (Mathf.Abs((length / 2.0f) - temp) > (length / 2.0f) * 0.2f + 0.005f)
                            {
                                makeCircle = false;
                                break;
                            }
                    }
                        avg /= curVertices;

                    if (Mathf.Abs((length / 2.0f) - avg) > (length / 2.0f) * 0.15f + 0.005f)
                        makeCircle = false;

                    if (makeCircle)
					{
                        Quaternion q = Quaternion.LookRotation(Front, Vector3.up);
						GameObject obj = (GameObject)Instantiate(circle.gameObject, Center, q);
						float scale = length / circle.GetSize();
                        obj.transform.localScale = new Vector3(scale, scale, scale);
                    }

					RenderEnd();
                }
                
            }
                
		}

    }
}
