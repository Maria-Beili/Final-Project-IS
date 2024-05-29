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

    void Update()
    {
        if (istrigger1){ //player 1 gets object

            transform.position = player1.transform.position; //object follows player 1

            if(touch_plane){ //if object touches above collider
                transform.position = originalPos; //object returns to original pos
                touch_plane = false;
                istrigger1 = false;
                player1.GetComponent<PlayerMovement>().is_free = true;
            } 
        }
        
        if (istrigger2){  //player 2 gets object

            transform.position = player2.transform.position; //object follows player 2

             if(touch_plane){ //if object touches above collider
                transform.position = originalPos; //object returns to original pos
                touch_plane = false;
                istrigger2 = false;
                player2.GetComponent<PlayerMovement>().is_free = true;
            }
    
        }
    }

    private void OnTriggerEnter(Collider other) 
    {

        if(other.CompareTag(tagplane)){ //if object touches above collider
            touch_plane = true; //bool to return object to init position
        }

        if (other.CompareTag(tagbox1)) //if object enters box1
        {
            
            //box1.GetComponent<CompareBoxObject>().is_empty = false; //box 1 is no longer empty

            if(box2.GetComponent<CompareBoxObject>().is_empty == false){ //if box 2 is also not empty

                collidertag2 = box2.GetComponent<CompareBoxObject>().Tag; 
                if(gameObject.tag == collidertag2){ //see if objects are the same

                    transform.position = box1.transform.position;
                    Destroy(gameObject, DestroyDelay);  //if they are then delete them
                    Destroy(box2.GetComponent<CompareBoxObject>().colliderObject, DestroyDelay);
                    playAudio(collidertag2);

                    message.enabled = true;
                    reset_parameters();
                    disableText();

                }else{
                    message.enabled = true;
                    message.text = "Try again! They are not the same fossil.";
                    SoundManager.Instance.PlayWrongMatch();
                    disableText();
                }
            }
        }

        if (other.CompareTag(tagbox2))  //if object enters box2
        {
            //box2.GetComponent<CompareBoxObject>().is_empty = false;
          
            if(box1.GetComponent<CompareBoxObject>().is_empty == false){ //if box 1 is also not emptyy

                collidertag1 = box1.GetComponent<CompareBoxObject>().Tag;
                if(gameObject.tag == collidertag1){ //see if objects are the same
 
                    transform.position = box2.transform.position;
                    Destroy(gameObject, DestroyDelay); //if they are then delete them
                    Destroy(box1.GetComponent<CompareBoxObject>().colliderObject, DestroyDelay);
                    playAudio(collidertag1);

                    message.enabled = true;
                    reset_parameters();
                    disableText();
                
                }else{
                    message.enabled = true;
                    message.text =  "Try again! They are not the same fossil.";
                    SoundManager.Instance.PlayWrongMatch();
                    disableText();
                }
            }
        }

    }  

    private void reset_parameters() 
    {
 
        istrigger1 = false; 
        istrigger2 = false; 

        player1.GetComponent<PlayerMovement>().is_free = true;
        player2.GetComponent<PlayerMovement>().is_free = true;

        message.text = "Great!";
    }

    private void disableText()
    {
        timeDisappear = Time.time + DestroyDelay*Time.deltaTime;
        if(Time.time >= timeDisappear){
            message.enabled = false; 
        }
    } 

    private void playAudio(string tag)
    {
        if (tag == "Vase")
        {
            SoundManager.Instance.PlayShatterGlass();
        }
    }


}
