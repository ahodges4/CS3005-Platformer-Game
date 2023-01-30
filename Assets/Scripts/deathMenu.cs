using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class deathMenu : MonoBehaviour
{
    GameObject player;
    GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        canvas = GameObject.FindGameObjectWithTag("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartLevel(){
        player.GetComponent<playerHealth>().makeAlive();
    }

    public void backToMainMenu(){
        player.GetComponent<playerHealth>().Destroyed = true;
        Destroy(player);
        Destroy(canvas);
        SceneManager.LoadScene(0);
    }
}
