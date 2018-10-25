using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBytime : MonoBehaviour {
    public AudioClip clip;
    private AudioSource source;

    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();
        StartCoroutine(RemoveParitcal());
        source.PlayOneShot(clip);
    }

    private IEnumerator RemoveParitcal() {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
