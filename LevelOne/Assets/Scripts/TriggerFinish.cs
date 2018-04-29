using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFinish : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Level finished");
        GameController.instance.LevelFinished();
    }
}
