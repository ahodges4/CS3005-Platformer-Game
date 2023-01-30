using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hipPivotController : MonoBehaviour
{

    public GameObject myPlayer;
    playerController myPC;

    // Start is called before the first frame update
    void Start()
    {
        myPC = GetComponentInParent<playerController>();
    }

    // Update is called once per frame
    //Control the upper body rotation of the player
    void FixedUpdate()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = 18;
        Vector3 difference = Camera.main.ScreenToWorldPoint(mousePos) - transform.position;
        
        difference.Normalize();

        float angle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        //transform.rotation = Quaternion.Euler(0f,0f,angle);

        if(myPC.facingRight){
            transform.rotation = Quaternion.Euler(0,0, Mathf.Clamp(angle-10f, 0f, 15f));
        }else if(!myPC.facingRight){
            if(angle > 0) transform.rotation = Quaternion.Euler(0,0, Mathf.Clamp(angle+20f, 165f, 180f)-180f);
            if(angle < 0) transform.rotation = Quaternion.Euler(0,0, 0);
        }
    }
}
