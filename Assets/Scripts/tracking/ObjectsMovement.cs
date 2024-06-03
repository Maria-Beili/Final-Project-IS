using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectsMovement : MonoBehaviour
{
    public GameObject player1; 
    public GameObject player2; 
    public GameObject box1; 
    public GameObject box2; 

    public string tagbox1;
    public string tagbox2;

    public bool istrigger1;
    public bool istrigger2;  

    public float DestroyDelay; 
    public float timeDisappear;

    public string collidertag1;
    public string collidertag2;

    public string tagplane;
    Vector3 originalPos;
    public bool touch_plane;

    public Text message;

    void Start()
    {
        originalPos = gameObject.transform.position;
    }

    IEnumerator PlayMusics(string tag) {
        SoundManager.Instance.PlayGoodMatch();
        yield return new WaitForSeconds(2);
        playAudio(tag);
    }

    IEnumerator PrintWrongText() {
        message.text =  "Try again! They are not the same fossil.";
        yield return new WaitForSeconds(4);
        message.text = "";
    }

    IEnumerator PrintGoodText(string tag) {
        message.text =  "Great! This is a " + tag.ToString();
        yield return new WaitForSeconds(4);
        message.text = "";
    }

    void Update()
    {
        //player 1 gets object
        if (istrigger1){ 

            //object follows player 1
            transform.position = player1.transform.position;
            
            //if object touches above collider, then returns to its original position
            if(touch_plane){ 
                transform.position = originalPos; 
                touch_plane = false;
                istrigger1 = false;
                player1.GetComponent<PlayerMovement>().is_free = true;
            } 
        }
        
        //player 2 gets object
        if (istrigger2){  
            
            //object follows player 2
            transform.position = player2.transform.position;
                     
            //if object touches above collider, then returns to its original position
            if(touch_plane){ 
                transform.position = originalPos; 
                touch_plane = false;
                istrigger2 = false;
                player2.GetComponent<PlayerMovement>().is_free = true;
            }
        }

    }

    private void OnTriggerEnter(Collider other) 
    {

        //1. if object touches above collider
        if(other.CompareTag(tagplane)){ 
            touch_plane = true; //bool to return object to init position
            SoundManager.Instance.PlayDigging();
        }

        //2. if object enters box1
        if (other.CompareTag(tagbox1)) 
        {
            //if box 2 is also not empty
            if(box2.GetComponent<CompareBoxObject>().is_empty == false){ 
                
                collidertag2 = box2.GetComponent<CompareBoxObject>().Tag; 
                //see if objects are the same
                if(gameObject.tag == collidertag2){ 
                    //leave object
                    transform.position = box1.transform.position;

                    //destroy objects
                    Destroy(gameObject, DestroyDelay);  
                    Destroy(box2.GetComponent<CompareBoxObject>().colliderObject, DestroyDelay);
                    
                    //play audios
                    StartCoroutine(PlayMusics(collidertag2));
                    
                    //reset some parameters
                    reset_parameters();

                    //display text
                    StartCoroutine(PrintGoodText(collidertag2));

                }else{
                    //play audio
                    SoundManager.Instance.PlayWrongMatch();

                    //display text
                    StartCoroutine(PrintWrongText());
                }
            }
        }

        //3. if object enters box2
        if (other.CompareTag(tagbox2))  
        {
            //if box 1 is also not empty
            if(box1.GetComponent<CompareBoxObject>().is_empty == false){
                collidertag1 = box1.GetComponent<CompareBoxObject>().Tag;
                //see if objects are the same
                if(gameObject.tag == collidertag1){ 
                    //leave object
                    transform.position = box2.transform.position;
                    
                    //destroy objects
                    Destroy(gameObject, DestroyDelay); //if they are then delete them
                    Destroy(box1.GetComponent<CompareBoxObject>().colliderObject, DestroyDelay);
                    
                    //play audios
                    StartCoroutine(PlayMusics(collidertag1));
                    
                    //reset some parameters
                    reset_parameters();

                    //display text
                    StartCoroutine(PrintGoodText(collidertag1));
                
                }else{
                    //play audio
                    SoundManager.Instance.PlayWrongMatch();

                    //display text
                    StartCoroutine(PrintWrongText());
                }
            }
        }

    }  

    private void reset_parameters() 
    {
        FinalScene.Instance.addFossil();

        istrigger1 = false; 
        istrigger2 = false; 

        player1.GetComponent<PlayerMovement>().is_free = true;
        player2.GetComponent<PlayerMovement>().is_free = true;

        box1.GetComponent<CompareBoxObject>().Tag = "";
        box2.GetComponent<CompareBoxObject>().Tag = "";
    }

    private void playAudio(string tag)
    {
        if (tag == "Vase")
        {
            SoundManager.Instance.PlayShatterGlass();
        }

        if (tag == "Triceratops")
        {
            SoundManager.Instance.PlayTriceratops();
        }

        if (tag == "T-Rex")
        {
            SoundManager.Instance.PlayTrex();
        }

        if (tag == "Shell")
        {
            SoundManager.Instance.PlayShell();
        }
        
        if (tag == "Femur")
        {
            SoundManager.Instance.PlayFemur();
        }

        if (tag == "Claw")
        {
            SoundManager.Instance.PlayClaw();
        }

        if (tag == "Fossil")
        {
            SoundManager.Instance.PlayFossil();
        }
    }


}
