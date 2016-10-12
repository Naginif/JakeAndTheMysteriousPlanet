using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ViewInGame : MonoBehaviour {

    public Text coinLabel;
    public Text scoreLabel;
    public Text highScoreLabel;

	void Start () {
	
	}
	
	void Update () {
        if (GameManager.instance.currentGameState == GameState.inGame)
        {
            coinLabel.text = GameManager.instance.collectedCoins.ToString();
            scoreLabel.text = Player.instance.GetDistance().ToString("f0");
            highScoreLabel.text = PlayerPrefs.GetFloat("highscore", 0).ToString("f0");
        }
	}
}
