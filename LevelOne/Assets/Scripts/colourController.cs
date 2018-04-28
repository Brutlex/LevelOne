using System.Collections;
using System.Collections.Generic;
 using UnityEngine;
 using System.Collections;
 
 public class colourController : MonoBehaviour {
     public Color color = Color.black;
    private bool fadeIn = false;
    private bool fadeOut = false;
    private bool shake = false;
    private int shakeCount = 0;

    private float startTime;
    private float minimum = 0.0f;
    private float maximum = 1.0f;
    public float duration = 1.0f;



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
        if (Input.GetKeyDown(KeyCode.P))
        {
            fadeOut = false;
            fadeIn = true;
            startTime = Time.time;
        }
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            fadeIn = false;
            fadeOut = true;
            startTime = Time.time;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            shake = true;
            shakeCount = 0;
            startTime = Time.time;
        }

        if (shake)
        {
            Shake();
        }
        Fade();
    }

    private void Shake()
    {
        float t = Time.time - startTime;
        if (t > 1)
        {
            shake = false;
            fadeIn = false;
            fadeOut = true;
            startTime = Time.time;
        }

        if(shakeCount%8 == 0)
        {
            transform.Translate(Vector2.right * 0.2f);
            transform.Translate(Vector2.up * 0.1f);
        } else if (shakeCount%4 == 0)
        {
            transform.Translate(Vector2.left * 0.2f);
            transform.Translate(Vector2.down * 0.1f);
        }
        shakeCount++;

    }

    private void Fade()
    {
        if (fadeIn || fadeOut)
        {
            float t = (Time.time - startTime) / duration;
            if (t > 1)
            {
                fadeIn = false;
                fadeOut = false;
            }
            else
            {
                float min, max;
                if (fadeIn)
                {
                    min = minimum;
                    max = maximum;
                }
                else
                {
                    min = maximum;
                    max = minimum;
                }
                Color currentColor = gameObject.GetComponent<Renderer>().material.color;
                gameObject.GetComponent<Renderer>().material.color = new Color(currentColor.r, currentColor.g, currentColor.b, Mathf.SmoothStep(min, max, t));
            }

        }
    }
 }