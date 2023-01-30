using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class cameraController : MonoBehaviour
{
    public Transform target; //what the camera is following
    public float smoothing; //Dampening effect

    Vector3 desiredPosition;//Position the camera wants to be at

    public float yOffset;//Current offset set by Camera Y Gates in Level

    //Begining camera to player difference
    float calibrationOffset;
    int newScene;
    int currentScene = 0;

    void OnEnable(){
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        newScene = scene.buildIndex;  
    }

    // Start is called before the first frame update
    void Start()
    {
        calibrationOffset = transform.position.y;

    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        if(currentScene < newScene){  //If new scene loaded reset camera postition
            currentScene = newScene;  
            transform.position = new Vector3(transform.position.x, 7.13f,-18f);//reset camera position
            yOffset = 0f; //reset canera offset
            Debug.Log(newScene);
            Debug.Log("CameraReset");
        } 

        if(target != null){
            desiredPosition = target.position;
            desiredPosition.y  = calibrationOffset + yOffset;
            desiredPosition.z = transform.position.z;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothing * Time.deltaTime);


            
        }else if(target == null) Destroy(gameObject);

        
        
    }

    public void addYOffset(float Y){
        yOffset += Y;
    }

    
}
