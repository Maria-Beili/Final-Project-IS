using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompareBoxObject : MonoBehaviour
{

    public string Tag;
    public bool is_empty;
    public GameObject colliderObject;

    void Start()
    {
        is_empty = true;
    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.name != "Collider plane" && other.name != "Plane" && other.name != "Player1"  && other.name != "Player2"){
            is_empty = false;
            Tag = other.gameObject.tag;
            colliderObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {    
       Tag = "";
       colliderObject = null;
       is_empty = true;
    }
}
