using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{

    public float maxSpeed;
    Rigidbody2D myRB;

    Animator myAnim;

    public bool facingRight;
    
    int newScene; //Current Scene
    int currentScene = 0;
    float previousFireRate;
    

    //Shooting
    public Transform gunTip;
    public Transform gunChamber;
    public GameObject bullet;
    public GameObject bulletCasing;
    public float fireRate;
    float nextFire = 0f;

    
    playerVerticalController myVC;


    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        myVC = GetComponent<playerVerticalController>();

        facingRight = true;
    }

    
    void OnEnable(){
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        newScene = scene.buildIndex;  
    }

    

    // Update is called once per frame
    void Update()
    {
        //Shoot
        if(Input.GetAxisRaw("Fire1")>0) fireGun();

        
    }

    void FixedUpdate() {
        float move = Input.GetAxis("Horizontal");
        if(!myVC.crouched){
            if(facingRight) myAnim.SetFloat("hVelocity", move);
            if(!facingRight) myAnim.SetFloat("hVelocity", -1*move);

            myRB.velocity = new Vector2(move * maxSpeed, myRB.velocity.y);
        }
        //Debug.Log(myRB.velocity.y);
        var mousePos = Input.mousePosition;
        mousePos.z = 18;
        float mouseX = Camera.main.ScreenToWorldPoint(mousePos).x;
        
        

        if (mouseX>transform.position.x && !facingRight){
            flip();
        } else if(mouseX<transform.position.x && facingRight){
            flip();
        }

        if(currentScene<newScene){
            currentScene = newScene;
            previousFireRate = fireRate;
        }


    }

    void flip(){//Change facing direction
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void fireGun(){//shoot bullet
        if(Time.time > nextFire){
            var mousePos = Input.mousePosition;
            mousePos.z = 18;
            Vector3 difference = Camera.main.ScreenToWorldPoint(mousePos) - gunTip.position;
            difference.Normalize();
            float angle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;//Find angle between guntip and mouse position
            nextFire = Time.time + fireRate;
            //Spawn in bullet and bullet Casing
            if(facingRight){
                angle = Mathf.Clamp(angle, -40f, 15f);
                angle = Random.Range(-2,2) + angle;
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3 (0,0,angle)));
                Instantiate(bulletCasing, gunChamber.position, Quaternion.Euler(new Vector3 (0,0,angle)));
            } else if(!facingRight){
                if(angle > 0){
                    angle = Mathf.Clamp(angle, 165f, 180f);
                    angle = Random.Range(-2,2) + angle;
                    Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3 (0,0,angle)));
                    Instantiate(bulletCasing, gunChamber.position, Quaternion.Euler(new Vector3 (0,0,angle)));
                }
                if(angle < 0){
                    angle = Mathf.Clamp(angle, -180, -140);
                    angle = Random.Range(-2,2) + angle;
                    Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3 (0,0,angle)));
                    Instantiate(bulletCasing, gunChamber.position, Quaternion.Euler(new Vector3 (0,0,angle)));
                }
            }
        }
    }

    public void AddFireRate(float newfireRate){
        if(fireRate - newfireRate < 0.05) return;
        else fireRate -= newfireRate;
    }

    public void resetFireRate(){
        fireRate = previousFireRate;
    }

    

    
}
