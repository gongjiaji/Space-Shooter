using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class AsteroidSelfRotate : MonoBehaviour
{
    public float xmin, xmax, ymin, ymax, zmin, zmax;
    public float speed;
    //private GameObject player;
    public GameObject destoryPartical;
    private AudioSource source;
    public AudioClip clip;
    public GameObject gc;

    // Use this for initialization
    void Start()
    {
        transform.rotation = Random.rotation;
        //player = GameObject.FindGameObjectWithTag("Player");
        source = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().angularVelocity += new Vector3(Random.Range(xmin, xmax), Random.Range(ymin, ymax),
            Random.Range(zmin, zmax));

        GetComponent<Rigidbody>().velocity = Vector3.forward * speed * Time.deltaTime;    
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            Instantiate(destoryPartical, transform.position, new Quaternion());

            Destroy(gameObject);
        }

        // astroid collide with player
        if(collision.gameObject.CompareTag("Player")) {
            Instantiate(destoryPartical, transform.position, new Quaternion());
            GameController.isDead = true;
            Destroy(gameObject);
            Destroy(collision.gameObject);
            source.PlayOneShot(clip); 
        }
    }

}
