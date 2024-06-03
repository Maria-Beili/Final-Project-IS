using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string nextScene;
    
    public void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player1"  || other.name == "Player2")
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
