using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoulderPivot : MonoBehaviour
{

    playerController myPC;
    playerVerticalController myVC;

    // Start is called before the first frame update
    void Start()
    {
        myPC = GetComponentInParent<playerController>();
        myVC = GetComponentInParent<playerVerticalController>();
    }

    // Update is called once per frame
    void FixedUpdate()//Controls the players arm rotation
    {
        var mousePos = Input.mousePosition;
        mousePos.z = 18;
        Vector3 difference = Camera.main.ScreenToWorldPoint(mousePos) - transform.position;

        difference.Normalize();

        float angle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;//Find angle between mouse position and the pivot

        //transform.rotation = Quaternion.Euler(0f,0f,angle);

        if(myPC.facingRight){
            transform.rotation = Quaternion.Euler(0,0, Mathf.Clamp(angle, -40, 15));
        }else if(!myPC.facingRight){
            if(angle > 0) transform.rotation = Quaternion.Euler(0,0, Mathf.Clamp(angle, 165, 180)+180);
            if(angle < 0) transform.rotation = Quaternion.Euler(0,0, Mathf.Clamp(angle, -180, -140)+180);
        }
    }
}
