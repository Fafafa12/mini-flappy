using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
	public int score;
	public Text scoreText;
	public GameObject gameOverPanel;

	[ContextMenu("Add Score")]
	public void addScore()
	{
		score++;
		scoreText.text = score.ToString();
	}

	public void restartGame()
	{
		resetScore();
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		gameOverPanel.SetActive(false);
		Time.timeScale = 1;
	}

	public void resetScore()
	{
		score = 0;
		scoreText.text = score.ToString();
	}

	public void gameOver()
	{
		gameOverPanel.SetActive(true);
		// pause the game
		Time.timeScale = 0;
	}
}
