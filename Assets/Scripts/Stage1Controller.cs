using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stage1Controller : MonoBehaviour {

	public Button startButton;
	public Text descriptionText;
	public Sprite[] odinSprites;
	public Sprite[] leibnizSprites;
	public Sprite[] thothSprites;
	public Sprite[] hermesSprites;
	public Sprite odinUI;
	public Sprite leibnizUI;
	public Sprite thothUI;
	public Sprite HermesUI;

	private GameManager gameManager;
	private string[] godNames = new string[4];
	private string _currGod = null;
//	private string[] _strengths = new string[2];
//	private string _weakness = null;
	private Sprite[] cardFaces;
	private Sprite currUI;
	private int[] dimensions = new int[2];

	void Awake() {
		descriptionText.text = "";
		startButton.interactable = false;
		gameManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager> ();
		godNames [0] = "Odin";
		godNames [1] = "Leibniz";
		godNames [2] = "Hermes";
		godNames [3] = "Thoth";
	}

	public void setOdin() {
		_currGod = "Odin";
		startButton.interactable = true;
		descriptionText.text = "You've Selected: Odin\nDifficulty: Medium";
//		_strengths [0] = "Aether";
//		_strengths [1] = "Earth";
//		_weakness = "Water";
		cardFaces = odinSprites;
		currUI = odinUI;

	}

	public void setLeibniz() {
		_currGod = "Leibniz";
		startButton.interactable = true;
		descriptionText.text = "You've Selected: Leibniz\nDifficulty: Tragically Easy";
//		_strengths [0] = "Fire";
//		_strengths [1] = "Earth";
//		_weakness = "Aether";
		cardFaces = leibnizSprites;
		currUI = leibnizUI;
	}

	public void setHermes() {
		_currGod = "Hermes";
		startButton.interactable = true;
		descriptionText.text = "You've Selected: Hermes\nDifficulty: Hard";
//		_strengths [0] = "Air";
//		_strengths [1] = "Aether";
//		_weakness = "Fire";
		cardFaces = hermesSprites;
		currUI = HermesUI;
	}

	public void setThoth() {
		_currGod = "Thoth";
		startButton.interactable = true;
		descriptionText.text = "You've Selected: Thoth\nDifficulty: Hard";
//		_strengths [0] = "Water";
//		_strengths [1] = "Earth";
//		_weakness = "Air";
		cardFaces = thothSprites;
		currUI = thothUI;
	}

	public void StartGame() {
		gameManager.godName = _currGod;
		dimensions [1] = cardFaces.Length;
		dimensions [0] = 42 / cardFaces.Length;
//		gameManager.strengths = _strengths;
//		gameManager.weakness = _weakness;
		gameManager.cardFaces = cardFaces;
		gameManager.dimensions = dimensions;
		gameManager.backgroundUI = currUI;

		SceneManager.LoadScene ("Concentration Scene");
	}
}
