using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movement : MonoBehaviour
{

    // Rigidbody 是调用刚体组件
    private Rigidbody rd;
    public float a;
    public float b;
    private bool movecondition=true;

    private float score;
    private float check;

    public Text text;
    public GameObject success;

    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (movecondition)
        {
            // 得到一个-1到1的值 返回-1代表按下A键，返回1代表按下D键
            float h = Input.GetAxis("Horizontal") * a;

            // 与上面一样，返回-1代表按下S键，返回1代表按下W键
            float v = Input.GetAxis("Vertical") * b;

            rd.AddForce(new Vector3(h, 0, v));
        }
    }

    // 触碰检测
    //private void OnCollisionEnter(Collision collision)
    //{
    //    //获取碰撞到的游戏物体身上collider组件
    //    //string name = collision.collider.name; //获取碰撞到游戏物体的名字
    //    //print(name);

    //    if(collision.collider.tag == "gold")
    //    {
    //        print(collision.collider.name);
    //        // 销毁指令，销毁碰撞到的gameObject
    //        Destroy(collision.collider.gameObject) ;
    //    }

    //}

    // 结束
    private void CheckEnd(Collider collider)
    {
        if (check == 9)
        {
            // 使success组件里为真时，使success 的UI显示出来
            success.SetActive(true);
            movecondition = false;

        }
        Destroy(collider.gameObject);
    }

    public float NormalAdd(Collider collider)
    {
        print(collider.name);
        score++;
        return score;
    }

    public float ChageAdd(Collider collider)
    {
        print(collider.name);
        score += 10;
        return score;
    }



    // 碰撞检测体
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "gold")
        {
            if (collider.name == "glod (1)")
            {
                ChageAdd(collider);
            }
            else
            {
                NormalAdd(collider);
            }
            text.text = score.ToString();
            check++;
        }

        CheckEnd(collider);
    }



}
