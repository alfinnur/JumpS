using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
    Rigidbody2D rigidbody;
    public float jumpY = 700.0f, jumpX = 700.0f;
    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.AddForce(new Vector2(-jumpX, jumpY));
            Debug.Log(rigidbody.velocity);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.AddForce(new Vector2(jumpX, jumpY));
            Debug.Log(rigidbody.velocity);
        }
    }
}
