using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject asteroid;
    public int amount;
    private float timer;
    [SerializeField]
    private int aliveAsteroids;
    private AudioSource source;
    public AudioClip clip;
    public int score;
    public Text text;
    public Text gotext;
    public Text restarttext;

    public static bool isDead;


    // Use this for initialization
    void Start () {
        Screen.SetResolution(600, 900, false);
        timer = 0;
        source = GetComponent<AudioSource>();
        source.PlayOneShot(clip);
        isDead = false;
    }

    // Update is called once per frame
    void Update ()
	{
        aliveAsteroids  = GameObject.FindGameObjectsWithTag("asteroid").Length;
        
        timer += Time.deltaTime;
        if(timer >2 && amount > 0) {
            amount--;
            NewAsteroid();
            timer = 0;
        }

        if(aliveAsteroids == 0) {
            StartCoroutine(SpawnWaves());
        }

        text.text = "score: "+score;

        if(isDead) {
            gotext.text = "GAME OVER";
            restarttext.text = "Press 'S' to restart";
            if(Input.GetKeyDown(KeyCode.S)) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    private void NewAsteroid()
    {
        Instantiate(asteroid, new Vector3(Random.Range(-4.5f, 4.5f), 1, Random.Range(12f, 14f)), new Quaternion());
    }

    private IEnumerator SpawnWaves() {
        yield return new WaitForSeconds(5);
        amount = 3;
    }

    public void AddScore() {
        score++;
    }

}
