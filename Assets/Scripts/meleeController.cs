using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeController : MonoBehaviour
{
    public float damage;
    public float knockback;
    Animator myAnim;
    bool stillHere;
    bool dealingAttack;
    // Start is called before the first frame update
    void Start()
    {
        myAnim=GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other){//Start Swing
        if(other.tag == "Player" && dealingAttack == false){
            dealingAttack = true;
            myAnim.SetTrigger("attacking");
            StartCoroutine(attack(other.gameObject));
            
        }
    }

    void OnTriggerStay2D(Collider2D other){//While player is still in the trigger
        if(other.tag == "Player") stillHere = true;

        if(other.tag == "Player" && dealingAttack == false){
            dealingAttack = true;
            myAnim.SetTrigger("attacking");
            StartCoroutine(attack(other.gameObject));
            
        }
    }

    void OnTriggerExit2D(Collider2D other) {//If player leave trigger
        if(other.tag == "Player") stillHere = false;
    }

    IEnumerator attack(GameObject player){//Only Apply Damage if the player is still in the trigger
        yield return new WaitForSeconds(1f);
        if (stillHere) player.GetComponent<playerHealth>().addDamage(damage);
        dealingAttack = false;
    }
}
