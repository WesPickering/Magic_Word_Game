using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConcentrationManager: MonoBehaviour {

	public Sprite[] cardFace;
	public Sprite cardBack;
	public GameObject[] cards;
	public Text ScoreText;
	public Text TimerText;
	public Image background;

	private bool init = false;
	private int score = 0;
	private GameManager gameManager;
	private int dimX;
	private int dimY;
	private float time;


	void Awake() {
		gameManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager> ();
		cardFace = gameManager.cardFaces;
		dimX = gameManager.dimensions[0];
		dimY = gameManager.dimensions[1];
		background.sprite = gameManager.backgroundUI;

		time = 60f;
		TimerText.text = "Time Left: " + (int) time;


		initializeCards ();


	}
	void Update() {
		if (Input.GetMouseButtonUp(0)) {
			checkCards ();
		}
		time -= Time.deltaTime;
		TimerText.text = "Time Left: " + (int) time;
//		if (time <= 0) {
//			GameManager.ResetGame ();
//		}


	}

	void initializeCards (){
		
		for (int i = 0; i < dimX; i++) {
			for (int j = 1; j <= dimY; j++) {
				bool test = false;
				int choice = 0;
				while (!test) {
					choice = Random.Range (0, cards.Length);
					test = !(cards [choice].GetComponent<Card> ().initialized);
				}
				cards [choice].GetComponent<Card> ().cardValue = j;
				cards [choice].GetComponent<Card> ().initialized = true;
			}
		}
		foreach (GameObject c in cards) {
			c.GetComponent<Card> ().setUpCards ();
		}

		if (!init) {
			init = true;
		}
	}

	public Sprite getCardBack() {
		return cardBack;
	}

	public Sprite getCardFace(int i) {
		return cardFace [i-1];
	}

	void checkCards() {
		List<int> c = new List<int> ();
		for (int i = 0; i < cards.Length; i++) {
			if (cards[i].GetComponent<Card>().state == 1) {
				c.Add (i);
			}
		}
		if (c.Count == 2) {
			cardComparison (c);
		}
	}

	void cardComparison ( List<int> c) {
		Card.STOP_MECH = true;

		int x = 0;

		if (cards[c[0]].GetComponent<Card>().cardValue == cards[c[1]].GetComponent<Card>().cardValue) {
			x = 2;
			score += 20;
			ScoreText.text = "Score: " + score;
		}

		for (int i = 0; i < c.Count; i++) {
			cards [c [i]].GetComponent<Card> ().state = x;
			cards [c [i]].GetComponent<Card> ().falsecheck ();
		}
	}
}
