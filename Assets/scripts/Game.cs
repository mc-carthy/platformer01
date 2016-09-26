using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class Game : MonoBehaviour {

	[SerializeField]
	private Text scoreText, gameoverText;
	[SerializeField]
	private Camera mainCam;
	[SerializeField]
	private Player player;
	private int score;
	private float gameTimer;
	private bool isGameOver;
	private float camSpeed = 1;
	private float yFloor = -10;

	private void Start () {
		//mainCam = Camera.main;
		Time.timeScale = 1;
		player.onHitEnemy += OnHitEnemy;
		player.onHitSpike += OnGameOver;
		player.onHitOrb += OnGameWin;
		scoreText.enabled = true;
		gameoverText.enabled = false;
		scoreText.text = "Time: " + gameTimer.ToString ("0");
	}

	private void Update () {
		MoveCameraToPlayer ();
		ListenForGameRestart ();
		CheckForPlayerFallingOutOfLevel ();

		scoreText.text = "Time: " + gameTimer.ToString ("0");
	}

	private void MoveCameraToPlayer () {
		mainCam.transform.position = new Vector3 (
			Mathf.Lerp(
				mainCam.transform.position.x,
				player.transform.position.x,
				Time.deltaTime * camSpeed
			),
			Mathf.Lerp(
				mainCam.transform.position.y,
				player.transform.position.y,
				Time.deltaTime * camSpeed
			),
			mainCam.transform.position.z
		);
	}

	private void ListenForGameRestart () {
		if (isGameOver) {
			if (Input.GetKeyDown (KeyCode.R)) {
				SceneManager.LoadScene (SceneManager.GetActiveScene ().name, LoadSceneMode.Single);
			}
		}
	}

	private void CheckForPlayerFallingOutOfLevel () {
		if (player.transform.position.y < yFloor) {
			OnGameOver ();
		}
	}

	private void OnHitEnemy () {
		score += 100;
	}

	private void OnGameOver () {
		isGameOver = true;
		scoreText.enabled = false;
		gameoverText.enabled = true;
		gameoverText.text = "Game Over!\nPress R to Restart!";
		Time.timeScale = 0;
	}

	private void OnGameWin () {
		isGameOver = false;
		scoreText.enabled = false;
		gameoverText.enabled = true;
		gameoverText.text = "You Won!\nTime: " + gameTimer.ToString ("0") + "\nPress R to Restart!";
		Time.timeScale = 0;
	}
}