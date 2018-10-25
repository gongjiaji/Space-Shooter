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
    public GameObject destoryPartical;
    public GameObject pc;

    // Use this for initialization
    void Start ()
	{
	    rb = GetComponent<Rigidbody>();
	    head = GameObject.FindGameObjectWithTag("jethead").transform;
	    transform.position = head.position;
	    time = 0;
        pc = GameObject.FindGameObjectWithTag("GameController");

    }
	
	// Update is called once per frame
	void Update () {     
	    rb.velocity = Vector3.forward * speed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("asteroid"))
        {
            pc.GetComponent<GameController>().AddScore();
            Instantiate(destoryPartical, transform.position, new Quaternion());
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }

    }



}
