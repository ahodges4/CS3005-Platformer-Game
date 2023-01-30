using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class darkKnightController : MonoBehaviour
{
    public float maxSpeed;
    Rigidbody2D myRB;
    Animator myAnim;
    public bool facingRight;
    public bool isAggressive;


    public playerDetection playerClose;
    GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        
        isAggressive = false;

        player = GameObject.FindGameObjectWithTag("Player");
          
    }

    // Update is called once per frame
    void Update()
    {
           
    }

    void FixedUpdate() {
        myAnim.SetFloat("hVelocity", Mathf.Abs(myRB.velocity.x));   
        

        if(playerClose.nearby) isAggressive = true;
        if(isAggressive) aggresive();
           
    }

    void flip(){//Change Facing Direction
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void walk(float direction){
        myRB.velocity = new Vector2(direction * maxSpeed, myRB.velocity.y);
    }
    

    void aggresive(){//If player is nearby be aggresive
        if(player.transform.position.x-1.5>transform.position.x) walk(1);
        if(player.transform.position.x+1.5<transform.position.x) walk(-1);

        //face the player
        if(player.transform.position.x > transform.position.x && !facingRight) flip();
        else if(player.transform.position.x < transform.position.x && facingRight) flip();
    }
}
