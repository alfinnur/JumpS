using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviours : MonoBehaviour {

    // Use this for initialization
    GameObject MainCamera;
    bool isOutofbound= true;
	void Start () {
        MainCamera = GameObject.Find("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bottom")
        {
            MainCamera.GetComponent<RandomSpawner>().Regenerate();
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        if (isOutofbound)
        {

        }
        
    }
}
