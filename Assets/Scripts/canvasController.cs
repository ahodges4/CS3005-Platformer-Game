using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class canvasController : MonoBehaviour
{

    int newScene;
    
    void OnEnable(){
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        newScene = scene.buildIndex;  
    }

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(newScene);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(newScene<2){ //If not in a menu 
            gameObject.GetComponent<Canvas>().enabled=false;

        }else{
            gameObject.GetComponent<Canvas>().enabled=true;
        }
    }
}
