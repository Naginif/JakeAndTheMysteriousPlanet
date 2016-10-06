using UnityEngine;
using System.Collections;

public enum GameState { menu, inGame, gameOver }

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public GameState currentGameState = GameState.inGame;
	// Use this for initialization
	void Start ()
    {
        StartGame();
	}
	
    void Awake()
    {
        instance = this;
    }
	// Update is called once per frame
	void Update () {
	    
	}

    public void StartGame()
    {
        SetGameState(GameState.inGame);
    }

    public void  GameOver()
    {
        SetGameState(GameState.gameOver);
    }

    public void BackToMenu()
    {
        SetGameState(GameState.menu);
    }

    void SetGameState(GameState newGameState)
    {
        if (newGameState == GameState.menu)
        {

        }

        else if (newGameState == GameState.inGame)
        {

        }

        else if (newGameState == GameState.gameOver)
        {

        }


    }
}
