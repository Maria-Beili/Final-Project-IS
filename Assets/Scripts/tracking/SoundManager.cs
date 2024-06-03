using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    
    public AudioClip wrongMatch;
    public AudioClip goodMatch;
    public AudioClip digging;
    public AudioClip shatterGlass;
    public AudioClip triceratops;
    public AudioClip trex;
    public AudioClip shell;
    public AudioClip claw;
    public AudioClip fossil;
    public AudioClip femur;

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
    }

    public void PlayWrongMatch()
    {
        PlaySound(wrongMatch);
    }

    public void PlayGoodMatch()
    {
        PlaySound(goodMatch);
    }
    
    public void PlayDigging()
    {
        PlaySound(digging);
    }

    public void PlayShatterGlass()
    {
        PlaySound(shatterGlass);
    }

    public void PlayTriceratops()
    {
        PlaySound(triceratops);
    }

    public void PlayTrex()
    {
        PlaySound(trex);
    }

    public void PlayShell()
    {
        PlaySound(shell);
    }

    public void PlayClaw()
    {
        PlaySound(claw);
    }

    public void PlayFossil()
    {
        PlaySound(fossil);
    }

    public void PlayFemur()
    {
        PlaySound(femur);
    }
    

}
