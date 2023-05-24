using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody ball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.acceleration.x;
        float y = Input.acceleration.y;
        float z = Input.acceleration.z;
        //Debug.Log("(" + x + " , " + y + " , " + z + ")");
        Vector3 force = new Vector3(x * 10.0F, 0.0F, y * 10.0F);
        ball.AddForce(force);
    }
}
