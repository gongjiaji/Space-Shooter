using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	private Rigidbody rb;
    public float speed;
    public float lateral;
    public GameObject ob;
    private float currentTime;
    private GameObject newOb;
    private AudioSource source;
    public AudioClip clip;


    // Use this for initialization
    void Start ()
	{
		rb = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
		// left right
		if (Input.GetAxisRaw("Horizontal") > 0)
		{
			rb.velocity = Vector3.right*speed*Time.deltaTime;
            LateralMovement();
		}else if (Input.GetAxisRaw("Horizontal") < 0)
		{
			rb.velocity = Vector3.left*speed*Time.deltaTime;
            LateralMovement();
		}

		// up down 
		if (Input.GetAxisRaw("Vertical") > 0)
		{
		    rb.velocity = Vector3.forward * speed * Time.deltaTime;
        }
		else if (Input.GetAxisRaw("Vertical") < 0)
		{
		    rb.velocity = Vector3.back * speed * Time.deltaTime;
        }

        // do not go out the screen 
        
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -4.5f,4.5f),
            transform.position.y,
            Mathf.Clamp(transform.position.z,-2 ,12)
            );

        // shoot
	    if (Input.GetKeyDown(KeyCode.K))
	    {
	        newOb = Instantiate(ob);
            source.PlayOneShot(clip); // shoot sound
	    }


    }
    // Lateral movement when move alone x 
    private void LateralMovement()
    {
      
        if (rb.velocity.x != 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, -rb.velocity.x * lateral);
        }

        // todo cant turn it back to initial rotation

    }


}
