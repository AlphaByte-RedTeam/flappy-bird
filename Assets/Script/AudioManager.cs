using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager singleton;
    public AudioClip[] clips;
    AudioSource audioSource;
    
    private void Awake() {
        singleton = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(int clipIndex) {
        audioSource.PlayOneShot(clips[clipIndex]);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
