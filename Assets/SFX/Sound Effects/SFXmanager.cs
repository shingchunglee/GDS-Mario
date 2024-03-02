using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXmanager : MonoBehaviour
{

    public AudioSource src;
    public AudioClip sfx1;

    public void coinCollection()
    {
        src.clip = sfx1;
        src.Play();


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
