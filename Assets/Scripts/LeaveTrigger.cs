using UnityEngine;
using System.Collections;

public class LeaveTrigger : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (GameManager.instance.collectedCoins >= 20)
        {
            LevelGenerator.instance.AddFinalPiece();
            LevelGenerator.instance.AddPiece();
            LevelGenerator.instance.RemoveOldestPiece();
        }
        else
        {
            LevelGenerator.instance.AddPiece();
            LevelGenerator.instance.RemoveOldestPiece();
        }

    }
}
