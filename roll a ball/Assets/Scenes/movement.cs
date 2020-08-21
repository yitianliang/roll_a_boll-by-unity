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
    public float c = 4.1f;
    public float speed = 1;

    public float margin = 0.1f;

    private bool movecondition = true;
    private float score;
    private float check;
    private bool grounded = true; // 检测地面

    public Text text;
    public GameObject success;

    // 控制摄像头
    public float cameraspeed; // 控制鼠标灵敏度
    public GameObject player; // 选择跟随得胶囊体
    Vector3 rot = new Vector3(0, 0, 0); // 初始化变量 rot

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false; // 使鼠标消失
        rd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // 固定摄像机移动
        //if (movecondition)
        //{
        //    if (float.Parse(string.Format("{0:F1}", transform.position.y)) > 0.5f) return;

        //    // 得到一个-1到1的值 返回-1代表按下A键，返回1代表按下D键
        //    float h = Input.GetAxis("Horizontal") * a;

        //    // 与上面一样，返回-1代表按下S键，返回1代表按下W键
        //    float v = Input.GetAxis("Vertical") * b;

        //    // 使用getkeydown获取到键盘按键
        //    bool jump = Input.GetKeyDown(KeyCode.Space); // keycode.xxx 能够获取指定位置的按键


        //    rd.velocity = new Vector3(h,0,v);
        //}

        if (movecondition)
        {
            // 首先判断物体是否在地面上

            // 第一人称视角移动
            float moveX = Input.GetAxis("Horizontal");
            float moveY = Input.GetAxis("Vertical");
            //        向正方向移动（移动的速度V3,Space.self/world）
            transform.Translate(new Vector3(moveX,0,moveY) * Time.deltaTime * speed);

            // 然后在按空格键控制跳跃，检测在地面的时候才能跳跃
            if (Input.GetButtonDown("Jump") && grounded == true)
            {
                rd.AddForce(new Vector3(0, c, 0), ForceMode.Impulse);
            }
        }

    }

    private void LateUpdate()
    {

        float mouseX = Input.GetAxis("Mouse X") * cameraspeed;
        float mouseY = Input.GetAxis("Mouse Y") * cameraspeed;
        rot.x = rot.x - mouseY;
        rot.y = rot.y + mouseX;

        rot.z = 0; // 锁定摄像头移动的角度Z轴，防止左右倾斜；
        transform.eulerAngles = rot; // 所有方向设定好后，摄像头的角度 = rot

        player.transform.eulerAngles = new Vector3(0, rot.y, 0);  //角色角度只能通过MouseX改变大小，也就是锁定rot.y


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

    // 检测控制体是否接触地面，也就是控制体的碰撞体是否接触到地面的碰撞体
    private void OnCollisionEnter(Collision collision)
    {
        // 在地面时候，保持 grounded 为 true 即可。
        if (collision.gameObject.tag == "ground")
        {
            grounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // 在离开地面时，使 grounded 为 false 即可。
        if (collision.gameObject.tag == "ground")
        {
            grounded = false;
        }
    }

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
