using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelPiece : MonoBehaviour {
    public Transform exitPoint;
    

    public void SpawnCoins(float x)
    {
        int numberOfCoins = Random.Range(1, 7);
        float xPosition = x;
        float yPosition;
        Debug.Log("xPosition = " + xPosition);
        for (int i = 0; i < numberOfCoins; i++)
        {
            xPosition += 4;
            yPosition = Random.Range(0, 5) - .5f;
            Instantiate(Resources.Load("Coin"), new Vector2(xPosition, yPosition), Quaternion.identity);
        }
    }

    public void Despawn()
    {

    }
}
