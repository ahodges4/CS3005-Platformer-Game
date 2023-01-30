using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour
{
    public float maxHealth;
    public GameObject deathFX;
    public float currentHealth;
    bool newCharacter;
    public bool dead;
    GameObject camera;
    GameObject canvas;
    Vector3 startPos;
    int newScene;

    public bool Destroyed;
    
    public int currentScene = 0;
    
    //HUD Variables
    public Slider healthSlider;
    Image damageScreen;

    bool damaged = false;
    Color damagedColour = new Color(0f,0f,0f,0.5f);
    float smoothColour = 5f;

    // Start is called before the first frame update
    void Start()
    {   
        damageScreen = GameObject.FindGameObjectWithTag("DamageImage").GetComponent<Image>();
        Destroyed = false;
        newCharacter = false;;
        
        startPos = new Vector3(0f,0f,0f);
        currentHealth = maxHealth;
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        dead = false;
        //HUD init
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
        
    }
    void OnEnable(){
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        newScene = scene.buildIndex;  
    }


    void FixedUpdate() {
        if(currentScene < newScene){//If a new level was loaded
            currentScene = newScene;
            transform.position = startPos;//Reset player position
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = currentHealth;
        if(damageScreen!=null){
            if(damaged){
                damageScreen.color = damagedColour;
            }else{
            damageScreen.color = Color.Lerp(damageScreen.color, Color.clear, smoothColour * Time.deltaTime);
            }
            damaged = false;
        }else{
            Debug.Log("Damage Screen is Null");
        }

        
    }

    public void addDamage(float damage){//add Damage to player
        if(damage<=0) return;
        currentHealth -= damage;
        healthSlider.value = currentHealth;
        damaged=true;
        if(currentHealth<=0){
            healthSlider.value = 0;
            makeDead();
        }
    }

    public void makeDead(){//kill Player
        if(!dead){

            GetComponent<playerController>().resetFireRate();
            dead = true;
            Instantiate(deathFX, transform.position, transform.rotation);

            foreach (Renderer r in GetComponentsInChildren<Renderer>()){
                r.enabled = false;
            }
            GetComponent<Renderer>().enabled = false;
            Invoke("EndScreen",2);
            
        }
    }

    public void makeAlive(){//Respawn Player
        if(dead){
            dead = false;
            GetComponent<Renderer>().enabled = true;
            foreach (Renderer r in GetComponentsInChildren<Renderer>()){
                r.enabled = true;
            }
            currentHealth = maxHealth;
            camera.transform.position = new Vector3(transform.position.x, 7.13f,-18f);
            camera.GetComponent<cameraController>().yOffset=0f;
            if(currentScene == 2){
                newCharacter = true;
                Destroyed = true;
                Destroy(camera);
                Destroy(canvas);
                Destroy(gameObject);
            }else{
                transform.position = startPos;
            }
            SceneManager.LoadScene(currentScene);
            
        }
    }

    public void addHealth(float newHealth){
        if(currentHealth + newHealth > maxHealth) currentHealth = maxHealth;
        else currentHealth += newHealth;

    }

    void EndScreen(){
        SceneManager.LoadScene("Death Screen");
    }
}
