using UnityEngine;
using System.Collections;

public class magicSquare : MonoBehaviour
{

    public GameObject emit;
    bool init = false;
    public GameObject eff;

    public AudioClip audiclip;
    AudioSource audiosource;

    private RaycastHit Hit;
    private Vector3 target;
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

        if (Input.GetMouseButton(0))
        {
            Emit();
        }

    }

    void Emit()
    {

        
        if (emit != null)
        {
            if (Physics.BoxCast(transform.position,new Vector3(transform.lossyScale.x,transform.lossyScale.y * 15 + 8,1.0f),transform.forward,out Hit, Quaternion.LookRotation(transform.forward), 10000,1 << LayerMask.NameToLayer("enemy")))
            {
                target = Hit.point - transform.position;
                target.Normalize();
                Debug.Log("通過した");
            }
            else
            {
                target = transform.forward;
            }

            GameObject obj = (GameObject)Instantiate(emit, transform.position, Quaternion.LookRotation(target));
            obj.transform.localScale *= 3.0f * transform.lossyScale.x;

            obj = (GameObject)Instantiate(eff, transform.position, transform.rotation);
            obj.transform.localScale *= 3.0f * transform.lossyScale.x;
        }

        audiosource.PlayOneShot(audiclip);
        Destroy(transform.gameObject);

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
            Emit();
    }
}
