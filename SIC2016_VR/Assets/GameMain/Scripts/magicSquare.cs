using UnityEngine;
using System.Collections;

public class magicSquare : MonoBehaviour
{

    public GameObject emit;
    bool init = false;
    public GameObject eff;

    public AudioClip audiclip;
    AudioSource audiosource;
    // Use this for initialization
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!init)
        {
            init = true;
            GameObject obj = (GameObject)Instantiate(eff, transform.position, transform.rotation);
            obj.transform.localScale *= 3.0f * transform.lossyScale.x;
        }

    }
    void OnTriggerEnter(Collider col)
    {
        ringPassing r;
        r = col.gameObject.GetComponent<ringPassing>();

        //ringPassingが存在するかどうか
        if (r == null) return;

        if (r.isActive == false) return;

        //魔方陣の上ベクトル
        Vector3 front = transform.forward;

        //触れたものが魔方陣の奥方向へ移動しているか
        Vector3 moveV = r.moveVector.normalized;
        if (Vector3.Dot(front, moveV) > 0.5f)
        {
            Debug.Log("通過した");
            if (emit != null)
            {

                GameObject obj = (GameObject)Instantiate(emit, transform.position, Quaternion.LookRotation(transform.forward));
                obj.transform.localScale *= 3.0f * transform.lossyScale.x;

                obj = (GameObject)Instantiate(eff, transform.position, transform.rotation);
                obj.transform.localScale *= 3.0f * transform.lossyScale.x;
            }
            audiosource.PlayOneShot(audiclip);
            Destroy(transform.gameObject);

        }
    }


}
