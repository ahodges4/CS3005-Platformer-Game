using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraYUpdateController : MonoBehaviour
{
    public GameObject camera;
    public float yOffset;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player"){
            float hVelocity = other.gameObject.GetComponent<Rigidbody2D>().velocity.x;

            if(hVelocity>0) camera.GetComponent<cameraController>().addYOffset(yOffset);
            else if(hVelocity<0) camera.GetComponent<cameraController>().addYOffset(-1*yOffset);
        }
    }
}
