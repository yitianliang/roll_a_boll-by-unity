using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class first_persion : MonoBehaviour
{
    public float speed; // 控制鼠标灵敏度
    public GameObject player; // 选择跟随得胶囊体
    Vector3 rot = new Vector3(0, 0, 0); // 初始化变量 rot


    // Start is called before the first frame update
    void Start()
    {

    }

    private void LateUpdate()
    {

        float mouseX = Input.GetAxis("Mouse X") * speed;
        float mouseY = Input.GetAxis("Mouse Y") * speed;
        rot.x = rot.x - mouseY;
        rot.y = rot.y + mouseX;
        rot.z = 0; // 锁定摄像头移动的角度Z轴，防止左右倾斜；
        transform.eulerAngles = rot; // 所有方向设定好后，摄像头的角度 = rot

        player.transform.eulerAngles = new Vector3(0, rot.y, 0); // 角色角度只能通过MouseX改变大小，也就是锁定rot.y

    }

}
