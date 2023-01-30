using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyProjectile : MonoBehaviour
{   
    public float aliveTime;
    // Start is called before the first frame update
    void Awake()
    {
        Destroy(gameObject, aliveTime);//Destroy game object after alive time has past
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
