using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileController : MonoBehaviour
{
    public float bulletSpeed;
    Rigidbody2D myRB;
    // Start is called before the first frame update
    void Awake()
    {
        myRB = GetComponent<Rigidbody2D>();
        myRB.velocity = transform.right * bulletSpeed;//Move bullet in direction that it is facing
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void removeForce(){
        myRB.velocity = new Vector2(0,0);
    }
}
