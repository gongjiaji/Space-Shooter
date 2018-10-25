using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BoldBehaviour : MonoBehaviour
{
	private Rigidbody rb;
    public float speed;
    private Transform head;
    private float time;
    public float maxTime;

	// Use this for initialization
	void Start ()
	{
	    rb = GetComponent<Rigidbody>();
	    head = GameObject.FindGameObjectWithTag("jethead").transform;
	    transform.position = head.position;
	    time = 0;
	}
	
	// Update is called once per frame
	void Update () {
        
	    rb.velocity = Vector3.forward * speed * Time.deltaTime;

        /*
         
        // bullet fly maxtime seconds 
	    time += Time.deltaTime;

	    if (time > maxTime)
	    {
	        Destroy(this.gameObject);
	    }
        */

        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("asteroid"))
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }

    }



}
