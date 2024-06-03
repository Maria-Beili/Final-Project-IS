using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalScene : MonoBehaviour
{
    public static FinalScene Instance;

    public int fossilsCollected;
    public string finalScene;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        fossilsCollected = 0; 
    }

    IEnumerator LoadFinalScene() {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(finalScene);
    }

    void Update()
    {
        if(fossilsCollected == 7)
        {
            StartCoroutine(LoadFinalScene());
        }
    }

    public void addFossil(){
        fossilsCollected = fossilsCollected+1;
    }
}
