using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTest : MonoBehaviour {

    private bool triggered = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Contact was made!");
        triggered = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("Contact!");
        triggered = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("Contact broken!");
        triggered = false;

    }
    void Update()
 {
        if (triggered == true)
            {
            Color color = gameObject.GetComponent<Renderer>().material.color;
            if (color.a < 0.1)
            {
                Debug.Log("Game over!");
                GameController.instance.GameOver();
            }

           // gameObject.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 1); //red


        }
        else
        {
            //gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 0, 1); //black

        }
    }
 }

