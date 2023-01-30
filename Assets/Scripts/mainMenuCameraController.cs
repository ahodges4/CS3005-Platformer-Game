using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenuCameraController : MonoBehaviour
{
    float startPos;

    float endPos;

    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        endPos = 821.5f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + Speed/100,transform.position.y,transform.position.z);
        if(transform.position.x>endPos){
            transform.position = new Vector3(startPos,transform.position.y,transform.position.z);
        }
    }
}
