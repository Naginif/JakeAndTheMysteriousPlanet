using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    private Rigidbody rb;
	// Use this for initialization
	void Start ()
    {
        Instantiate(Resources.Load("FloorPiece"), 
                    new Vector3(-7, -4, 0),
                    Quaternion.Euler(90, 0, 0));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
