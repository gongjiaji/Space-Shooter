using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject asteroid;
    public int amount;
    public 	    float time = 0;


	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    while(amount>0)
	        time += Time.deltaTime;
	        if (time > 1.5)
	        {
                NewAsteroid();
	            time = 0;
	            amount--;
	        }
	        
	    
    }

    private void NewAsteroid()
    {
        Instantiate(asteroid, new Vector3(Random.Range(-4.5f, 4.5f), 1, Random.Range(12f, 14f)), new Quaternion());
    }
}
