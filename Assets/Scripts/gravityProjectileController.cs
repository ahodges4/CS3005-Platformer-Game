using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityProjectileController : MonoBehaviour
{
    Rigidbody2D myRB;
    GameObject player;
    public float force;
    public float vforce;
    // Start is called before the first frame update
    void Awake()
    {
        myRB = GetComponent<Rigidbody2D>();
        
        myRB.velocity = transform.right * force;
        myRB.AddForce(new Vector2(0,vforce));

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void removeForce(){
        myRB.velocity = new Vector2(0,0);
    }
}

