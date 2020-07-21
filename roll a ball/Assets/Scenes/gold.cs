using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gold : MonoBehaviour
{
    public float rote_of_rotate= 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 1s调用60次
        transform.Rotate(new Vector3(0, rote_of_rotate, 0));
    }
}
