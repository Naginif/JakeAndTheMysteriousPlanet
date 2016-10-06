using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour {
    public static LevelGenerator instance;
    public List<LevelPiece> levelPrefabs = new List<LevelPiece>();
    public List<LevelPiece> pieces = new List<LevelPiece>();
    public Transform levelStartPoint;

    public void AddPiece()
    {
        int randomIndex = Random.Range(0, levelPrefabs.Count);

        LevelPiece piece = (LevelPiece)Instantiate(levelPrefabs[randomIndex]);
        piece.transform.SetParent(this.transform, false);

        Vector3 spawnPosition = Vector3.zero;

        if (pieces.Count == 0)
            spawnPosition = levelStartPoint.position;
        else
            spawnPosition = pieces[pieces.Count - 1].exitPoint.position;

        piece.transform.position = spawnPosition;
        pieces.Add(piece);
    }

    public void RemovePiece()
    {

    }

    public void RemoveAllPieces()
    {

    }

    void Awake()
    {
        instance = this;
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
