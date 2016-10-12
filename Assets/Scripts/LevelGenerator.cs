using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour {
    public static LevelGenerator instance;
    public List<LevelPiece> levelPrefabs = new List<LevelPiece>();
    public List<LevelPiece> pieces = new List<LevelPiece>();
    public LevelPiece finalPiece = new LevelPiece();
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
        }
        else
        {
            spawnPosition = pieces[pieces.Count - 1].exitPoint.position;
        }

        piece.transform.position = spawnPosition;
        pieces.Add(piece);

        piece.SpawnCoins(piece.transform.position.x);
    }

    public void RemoveOldestPiece()
    {
        LevelPiece oldestPiece = pieces[0];

        pieces.Remove(oldestPiece);
        Destroy(oldestPiece.gameObject);
    }

    public void AddFinalPiece()
    {
        LevelPiece final = Instantiate(finalPiece);
        Vector3 spawnPosition = pieces[pieces.Count - 1].exitPoint.position;
        final.transform.position = spawnPosition;
    }

    public void GenerateInitialPieces()
    {
        for(int i = 0; i < 2; i++)
            AddPiece();
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
