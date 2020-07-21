using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowTaget : MonoBehaviour
{
    // 获取指定组件的位置
    public Transform playerTransform;

    // 存储位置
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {

        //获取到相对位置，当前位置减去控制组件位置得到相对位置
        //transform.position使获取自身位置
        offset=transform.position - playerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // 加上相对位置
        transform.position = playerTransform.position + offset;    
    } 
}
