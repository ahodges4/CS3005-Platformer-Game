using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveMe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);//Stop gameObject from being deleted when scene is exited
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
