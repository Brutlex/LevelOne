using System.Collections;
using System.Collections.Generic;
 using UnityEngine;
 using System.Collections;
 
 public class colourController : MonoBehaviour {
     public Color color = Color.black;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 1); //red
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 1, 1); //blue
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(1, 0.92f, 0.016f, 1); //yellow
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(0, 1, 0, 1); //green
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 0, 1); //black
        }
    }
 }