using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public enum GameState { menu, inGame, gameOver, levelComplete }

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public GameState currentGameState = GameState.menu;
    public Canvas menuCanvas;
    public Canvas inGameCanvas;
    public Canvas gameOverCanvas;
    public Canvas levelCompleteCanvas;
    public int collectedCoins = 0;
	// Use this for initialization
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

    public void GameOver()
    {
        SetGameState(GameState.gameOver);
    }

    public void BackToMenu()
    {
        SetGameState(GameState.menu);
    }

    public void LevelComplete()
    {
        SetGameState(GameState.levelComplete);
    }

    public void CollectedCoin()
    {
        collectedCoins++;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Level2()
    {
        Debug.Log("Go to level 2");
        SceneManager.LoadScene("Level2");
    }

    void SetGameState(GameState newGameState)
    {
        if (newGameState == GameState.menu)
        {
            menuCanvas.enabled = true;
            inGameCanvas.enabled = false;
            gameOverCanvas.enabled = false;
            levelCompleteCanvas.enabled = false;
        }

        else if (newGameState == GameState.inGame)
        {
            menuCanvas.enabled = false;
            inGameCanvas.enabled = true;
            gameOverCanvas.enabled = false;
            levelCompleteCanvas.enabled = false;
        }

        else if (newGameState == GameState.gameOver)
        {
            menuCanvas.enabled = false;
            inGameCanvas.enabled = false;
            gameOverCanvas.enabled = true;
            levelCompleteCanvas.enabled = false;
        }

        else if (newGameState == GameState.levelComplete)
        {
            menuCanvas.enabled = false;
            inGameCanvas.enabled = false;
            gameOverCanvas.enabled = false;
            levelCompleteCanvas.enabled = true;
        }

        currentGameState = newGameState;
    }
}
