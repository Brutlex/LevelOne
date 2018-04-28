using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitBoard : MonoBehaviour {

    public Sprite initialCellSprite;

	// Use this for initialization
	void Start () {
        Camera mainCam = gameObject.GetComponent("Main Camera") as Camera;

        BoardGrid boardGrid = new BoardGrid(10, initialCellSprite);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
