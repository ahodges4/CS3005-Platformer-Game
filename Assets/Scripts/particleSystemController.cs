using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class particleSystemController : MonoBehaviour
{
    public int activeLevel;
    ParticleSystem myPS;
    int scene;
    // Start is called before the first frame update
    void Start()
    {
        myPS = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        scene = SceneManager.GetActiveScene().buildIndex;
        if(scene == activeLevel){//Particle System only plays on select level
            myPS.Play();
        }else{
            myPS.Stop();
        }
    }
}
