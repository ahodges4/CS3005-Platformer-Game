using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VcameraYUpdate : MonoBehaviour
{
    cameraController worldCamera;
    public float yOffset;
    Transform player;
    public bool above;
    public float xSpan;
    
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        worldCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<cameraController>();
    }

    // Update is called once per frame
    void FixedUpdate()//Changes Y position of camera based on player Y position between two x positions
    {
        if(Mathf.Abs(transform.position.x - player.position.x)< xSpan){
            if(player.position.y > transform.position.y && !above) {
                worldCamera.addYOffset(yOffset);
                above = true;
            }
            else if(player.position.y < transform.position.y && above){
                worldCamera.addYOffset(-1*yOffset);
                above = false;
            }
        }
    }

    // void OnTriggerExit2D(Collider2D other) {
    //     Debug.Log(other.tag);
    //     if(other.tag == "Hat"){
            
    //         float vVelocity = playerRB.velocity.y;
    //         Debug.Log(vVelocity);
    //         Debug.Log(playerRB.velocity.y);
    //         if(vVelocity>0){
    //             worldCamera.GetComponent<cameraController>().addYOffset(yOffset);
    //             Debug.Log("Up");
    //         }
    //         else if(vVelocity<0){
    //             worldCamera.GetComponent<cameraController>().addYOffset(-1*yOffset);
    //             Debug.Log("Down");
    //         }
            
            
    //     }
    // }

    // IEnumerator cooldown(){
    //     yield return new WaitForSeconds(0.5f);
    //     collision = false;
    // }
}
