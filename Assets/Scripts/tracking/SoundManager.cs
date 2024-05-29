using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    
    public AudioClip soundTrack;
    //public AudioClip getObject;
    //public AudioClip dropObject;
    public AudioClip wrongMatch;
    //public AudioClip goodMatch;
    public AudioClip digging;
    public AudioClip shatterGlass;

    private Vector3 camera1Position;
    private Vector3 camera2Position;

    //Awake runs befor start
    void Awake()
    {
        Instance = this;
        camera1Position = Camera.main.transform.position; 
    }

    private void PlaySound(AudioClip clip) 
    {
        AudioSource.PlayClipAtPoint(clip, camera1Position); 
        //AudioSource.PlayClipAtPoint(clip, camera2Position); 
    }

    // Update is called once per frame
    public void PlaySoundTrack()
    {
        PlaySound(soundTrack);
    }

    public void PlayDigging()
    {
        PlaySound(digging);
    }

    public void PlayShatterGlass()
    {
        PlaySound(shatterGlass);
    }

    public void PlayWrongMatch()
    {
        PlaySound(wrongMatch);
    }
}
