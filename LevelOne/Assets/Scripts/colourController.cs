using System.Collections;
using System.Collections.Generic;
 using UnityEngine;
 using System.Collections;
 
 public class colourController : MonoBehaviour {
     public Color color = Color.black;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 1); //red
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 1, 1); //blue
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(1, 0.92f, 0.016f, 1); //yellow
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(0, 1, 0, 1); //green
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 0, 1); //black
        }
    }
 }