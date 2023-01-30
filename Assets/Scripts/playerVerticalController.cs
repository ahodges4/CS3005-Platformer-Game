using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerVerticalController : MonoBehaviour
{

    Rigidbody2D myRB;

    Animator myAnim;

    public Transform body;

    public SpriteRenderer chest;

    public Animator jumpChargeBar;//UI Element

    float startTime;
    public LayerMask groundLayer;
    public Transform groundCheck;
    float groundCheckRadius = 0.4f;
    public bool grounded = false;
    public bool crouched = false;
    bool bodyCrouched = false;

    public float maxLow;//Lowest Player can go before killed

    playerHealth health;
    

    // Start is called before the first frame update
    void Start()
    {
        float startTime = Time.time;
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        health = GetComponent<playerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if(grounded && Input.GetAxis("Jump")>0 && !crouched) jump(1);
        
        float holdTime; 

        //Charged Jump
        if(grounded && Input.GetAxis("Crouch")>0){
            crouched = true;
            myAnim.SetBool("isCrouched", crouched);
            float currentTime = Time.time;
            holdTime = currentTime - startTime;
            float chargePercent = (holdTime*5/15);
            jumpChargeBar.SetFloat("jumpLevel", chargePercent);
            if(Input.GetAxis("Jump")>0) jump(Mathf.Clamp(holdTime*5,1,15));
        }else{
            startTime = Time.time;
            crouched = false;
            myAnim.SetBool("isCrouched", crouched);
            holdTime = 0;
            jumpChargeBar.SetFloat("jumpLevel", 0);
        }

        if(crouched && !bodyCrouched){
            body.position = new Vector3(body.position.x, body.position.y - 0.3f, body.position.z);
            chest.sortingOrder = 2;
            bodyCrouched = true;
        } else if(!crouched && bodyCrouched){
            body.position = new Vector3(body.position.x, body.position.y + 0.3f, body.position.z);
            chest.sortingOrder = -1;
            bodyCrouched = false;
        }

        

        
        

    }

    void FixedUpdate() {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        myAnim.SetBool("isGrounded", grounded);

        myAnim.SetFloat("vVelocity", myRB.velocity.y);

        checkY(maxLow);
    }

    void jump(float jumpForce){
        grounded = false;
        crouched = false;
        myAnim.SetBool("isGrounded", grounded);
        myRB.AddForce(new Vector2(0,jumpForce * 50));
    }

    void checkY(float maxLow){
        if(transform.position.y < maxLow) health.makeDead();
    }

    
}
