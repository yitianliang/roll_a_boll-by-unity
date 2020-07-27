using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canmer_rotate : MonoBehaviour
{
    public GameObject camera;
    public Rigidbody rd;
    public float sportspeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 speed = new Vector3(h, 0, v);
        rd.velocity = speed * sportspeed;
    }
}
