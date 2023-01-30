using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class checkPointController : MonoBehaviour
{
    bool levelComplete;

    // Start is called before the first frame update
    void Start()
    {
        levelComplete = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player" && !levelComplete){
            levelComplete = true;;
            Invoke("completeLevel", 2f);//Change level after 2 seconds
            
        }
    }

    void completeLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
