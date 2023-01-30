using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platDetectionController : MonoBehaviour
{
    public bool right;
    platformController myPC;
    // Start is called before the first frame update
    void Start()
    {
        myPC = GetComponentInParent<platformController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.layer == LayerMask.NameToLayer("Ground")){
            myPC.changeDirection(right);
        }
    }
}
