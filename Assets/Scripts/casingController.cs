using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class casingController : MonoBehaviour
{
    public float ejectionSpeed;
    Rigidbody2D myRB;

    // Start is called before the first frame update
    void Awake()
    {
        myRB = GetComponent<Rigidbody2D>();
        myRB.velocity = transform.right * ejectionSpeed * -0.5f;
        myRB.AddForce(new Vector2(0,1)* ejectionSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
