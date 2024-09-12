using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollision : MonoBehaviour
{
    public QuestionManager questionManager;
    void OnCollisionEnter2D(Collision2D collision){
        // Debug.Log(collision.gameObject.tag + " starts colliding");

        if(collision.gameObject.tag == "Ground" && gameObject.tag == "LastOption"){
            Debug.Log("Last Option has been hit the ground");
            questionManager.OnPlayerAnswer("wrong");
        }

        if(collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Player"){
            gameObject.SetActive(false);
        }
    }
}
