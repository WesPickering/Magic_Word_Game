
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour {

	public static bool STOP_MECH = false;

	[SerializeField] private int _state;
	[SerializeField] private int _cardValue;
	[SerializeField] private bool _initialized = false;

	private Sprite cardBack;
	private Sprite cardFace;
	private GameObject gameManager;

	void Start(){
		_state = 1;
		gameManager = GameObject.FindGameObjectWithTag ("Manager");
	}

	public void setUpCards() {
		cardBack = gameManager.GetComponent<ConcentrationManager> ().getCardBack ();
		cardFace = gameManager.GetComponent<ConcentrationManager> ().getCardFace (_cardValue);

		StartCoroutine (showCards ());
	}

	IEnumerator showCards() {
		_state = 1;
		yield return new WaitForSeconds (10);
		flipCard ();
	}

	public void flipCard(){
		if (_state == 0) {
			_state = 1;
		} else if (_state == 1) {
			_state = 0;
		}

		if (_state == 0 && !STOP_MECH) {
			GetComponent<Image> ().sprite = cardBack;
		} else if (_state == 1 && !STOP_MECH) {
			GetComponent<Image> ().sprite = cardFace;
		}
	}

	public int cardValue {
		get { return _cardValue; }
		set { _cardValue = value; }
	}

	public int state{
		get { return _state; }
		set { _state = value; }
	}
		
	public bool initialized {
		get { return _initialized; }
		set { _initialized = value; }
	}

	public void falsecheck(){
		StartCoroutine (pause ());
	}

	IEnumerator pause() {
		yield return new WaitForSeconds(1);
		if (_state == 0) {
			GetComponent<Image> ().sprite = cardBack;
		} else if (state == 1) {
			GetComponent<Image> ().sprite = cardFace;
		}
		STOP_MECH = false;
	}
}
