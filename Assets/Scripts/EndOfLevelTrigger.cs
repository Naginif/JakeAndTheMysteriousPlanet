using UnityEngine;
using System.Collections;

public class EndOfLevelTrigger : MonoBehaviour
{ 
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            GameManager.instance.LevelComplete();
    }
}
