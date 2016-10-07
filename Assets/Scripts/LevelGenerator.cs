using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour {
    public static LevelGenerator instance;
    public List<LevelPiece> levelPrefabs = new List<LevelPiece>();
    public LevelPiece Element0;
    public List<LevelPiece> pieces = new List<LevelPiece>();
    public Transform levelStartPoint;

    public void AddPiece()
    {
        int randomIndex = Random.Range(0, levelPrefabs.Count);
        LevelPiece piece = (LevelPiece)Instantiate(levelPrefabs[randomIndex]);
        piece.transform.SetParent(this.transform, false);

        Vector3 spawnPosition = Vector3.zero;

        if (pieces.Count == 0)
        {
            spawnPosition = levelStartPoint.position;
            Debug.Log("Count = 0!");
        }
        else
        {
            spawnPosition = pieces[pieces.Count - 1].exitPoint.position;
        }

        piece.transform.position = spawnPosition;
        Debug.Log("spawnposition = " + spawnPosition.ToString());
        pieces.Add(piece);
    }

    public void RemovePiece()
    {

    }

    public void RemoveAllPieces()
    {

    }
 
    public void GenerateInitialPieces()
    {
        levelPrefabs.Add(Element0);
        for(int i = 0; i < 2; i++)
            AddPiece();
        Debug.Log("levelPrefab count is: " + levelPrefabs.Count);
    }

    void Awake()
    {
        instance = this;
    }
    // Use this for initialization
    void Start () {
        GenerateInitialPieces();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
