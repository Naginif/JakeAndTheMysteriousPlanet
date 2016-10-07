using UnityEngine;
using System.Collections;

public enum GameState { menu, inGame, gameOver }

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public GameState currentGameState = GameState.menu;
    public Canvas menuCanvas;
    public Canvas inGameCanvas;
    public Canvas gameOverCanvas;
    public int collectedCoins = 0;
	// Use this for initialization
	void Start ()
    {
	}
	
    void Awake()
    {
        instance = this;
    }
	// Update is called once per frame

    public void StartGame()
    {
        SetGameState(GameState.inGame);
        Player.instance.StartGame();
    }

    public void  GameOver()
    {
        SetGameState(GameState.gameOver);
    }

    public void BackToMenu()
    {
        SetGameState(GameState.menu);
    }

    public void CollectedCoin()
    {
        collectedCoins++;
    }

    void SetGameState(GameState newGameState)
    {
        if (newGameState == GameState.menu)
        {
            menuCanvas.enabled = true;
            inGameCanvas.enabled = false;
            gameOverCanvas.enabled = false;
        }

        else if (newGameState == GameState.inGame)
        {
            menuCanvas.enabled = false;
            inGameCanvas.enabled = true;
            gameOverCanvas.enabled = false;
        }

        else if (newGameState == GameState.gameOver)
        {
            menuCanvas.enabled = false;
            inGameCanvas.enabled = false;
            gameOverCanvas.enabled = true;
        }

        currentGameState = newGameState;
    }
}
