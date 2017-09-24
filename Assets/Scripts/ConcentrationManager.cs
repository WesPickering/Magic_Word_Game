using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConcentrationManager: MonoBehaviour {

	public Sprite[] cardFace ;
	public Sprite cardBack;
	public GameObject[] cards;
	public Text matchText;

	private bool init = false;
	private int matches = 13;

	void Update() {
		if (!init)
			initializeCards ();

		if (Input.GetMouseButtonUp(0)) {
			checkCards ();
		}
	}

	void initializeCards (){
		for (int i = 0; i < 2; i++) {
			for (int j = 1; j < 14; j++) {
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
//			matches--;
//			matchText.text = "Number of Matches: " + matches;

			if (matches == 0) {
				SceneManager.LoadScene ("Menu");
			}
		}

		for (int i = 0; i < c.Count; i++) {
			cards [c [i]].GetComponent<Card> ().state = x;
			cards [c [i]].GetComponent<Card> ().falsecheck ();
		}
	}
}
