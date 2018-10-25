using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AsteroidSelfRotate : MonoBehaviour
{
    public float xmin, xmax, ymin, ymax, zmin, zmax;
    public float speed;
    private GameObject player;
    public GameObject destoryPartical;

    // Use this for initialization
    void Start()
    {
        transform.rotation = Random.rotation;
        player = GameObject.FindGameObjectWithTag("Player");
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
        
            Destroy(this.gameObject);
        }
    }
}
