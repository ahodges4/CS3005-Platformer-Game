using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformController : MonoBehaviour
{   
    public float maxSpeed;
    public float ySpeed;
    Rigidbody2D myRB;
    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        myRB.velocity = new Vector2(maxSpeed, ySpeed);
    }

    public void changeDirection(bool right){//If side colliders detect ground change direction
        if(maxSpeed>0 && right){
            maxSpeed *= -1;
            ySpeed *= -1;
        } 
        if(maxSpeed<0 && !right){
            maxSpeed *= -1;
            ySpeed *= -1;
        }
    }
}
