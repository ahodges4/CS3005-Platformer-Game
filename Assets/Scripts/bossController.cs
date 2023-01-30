using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class bossController : MonoBehaviour
{
    public float walkingSpeed;
    public float flyingSpeed;
    Rigidbody2D myRB;
    Animator myAnim;

    public bool facingRight;
    public bool isAggressive;

    GameObject player;

    bool magic; //Magic mode


    //pathfinding
    public float nextWaypointDistance = 3f;
    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;
    Seeker seeker;

    //Projectile System
    public Transform swordTip;
    public float fireRate;
    float nextFire = 0f;
    public GameObject projectile;


    //Switch Between Modes
    public float timeToSwitch;
    float nextSwitch=0f;
    


    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponentInChildren<Animator>();

        isAggressive = false;

        player = GameObject.FindGameObjectWithTag("Player");

        seeker = GetComponent<Seeker>();
        InvokeRepeating("updatePath",0f,.5f);
        myAnim.SetBool("Flying", true);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //Animation
        myAnim.SetFloat("hVelocity", Mathf.Abs(myRB.velocity.x));

        myAnim.SetFloat("vVelocity", Mathf.Abs(myRB.velocity.y));

        //if player has been detected
        if(isAggressive){
            if(myRB.velocity.x > 0.5f){
                if(myRB.velocity.x >= 0.01f && !facingRight) flip();
                else if(myRB.velocity.x <= -0.01f && facingRight) flip();
            }else{
                if(player.transform.position.x > transform.position.x && !facingRight) flip();
                else if(player.transform.position.x < transform.position.x && facingRight) flip();
            }
            //Timer to switch between modes

            if(Time.time > nextSwitch && !magic){
                nextSwitch = Time.time + timeToSwitch;
                flyingSpeed -= 5000;
                magic = true;
            }else if(Time.time > nextSwitch && magic){
                nextSwitch = Time.time + timeToSwitch;
                flyingSpeed += 5000;
                magic = false;   
            }

            if(magic) magicMode();
            if(!magic) meleeMode();
        }
    }

    void meleeMode(){//Mode with Melee sword attacks
        
        if(path == null) return;

        if(currentWaypoint >= path.vectorPath.Count){
            reachedEndOfPath = true;
            return;
        }else{
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - myRB.position).normalized;
        Vector2 force = direction * flyingSpeed * Time.deltaTime;

        myRB.AddForce(force);

        float distance = Vector2.Distance(myRB.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWaypointDistance){
            currentWaypoint++;
        }
        //walk towards player
        
    }

    void magicMode(){//Mode with Majic Projectile Attacks
        if(path == null) return;

        if(currentWaypoint >= path.vectorPath.Count){
            reachedEndOfPath = true;
            return;
        }else{
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - myRB.position).normalized;
        Vector2 force = direction * flyingSpeed * Time.deltaTime;

        myRB.AddForce(force);

        float distance = Vector2.Distance(myRB.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWaypointDistance){
            currentWaypoint++;
        }


        //Magic Attack
        if(Mathf.Abs(player.transform.position.x - transform.position.x)< 15 && Time.time > nextFire){
            nextFire = Time.time + fireRate;

            Vector3 dir = player.transform.position - swordTip.transform.position;
            dir = player.transform.InverseTransformDirection(dir);
            float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;

            Instantiate(projectile, swordTip.position, Quaternion.Euler(new Vector3 (0,0,angle)));
        }
    }

    void flip(){//Change facing direction
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void walk(float direction){
        myRB.velocity = new Vector2(direction * walkingSpeed, myRB.velocity.y);
    }

    //Pathfinding
    void OnPathComplete(Path p){
        if (!p.error){
            path = p;
            currentWaypoint = 0;
        }
    }

    void updatePath(){//Get new Path
        if(seeker.IsDone()){
            Vector3 desiredPos = player.transform.position;
            if(magic){
                Vector3 offset = new Vector3(10f,5f,0f);

                if(transform.position.x < player.transform.position.x){
                    offset = new Vector3(-10f,5f,0f);
                }
                desiredPos = new Vector3(player.transform.position.x+offset.x, player.transform.position.y+offset.y, 0f);
            }
            
            
            Debug.DrawLine(myRB.position,desiredPos);
            seeker.StartPath(myRB.position, desiredPos, OnPathComplete);
        }
    }

    public void makeDead(){//When Dead stop player from dying
        player.GetComponent<playerHealth>().dead = true;
    }
}
