using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public static int score = 0;
	public static int currentlevel = 1;


	private bool loaded = false;
	private string _godName = null;
	private string[] _strengths = new string[2];
	private string _weakness = null;

	private Sprite[] _cardFaces;
	private int[] _dimensions = new int[2];
	private Sprite _backgroundUI;

	private int powerLevel = 0;
	private float powerScalar = 0;




	void Awake() {
		if (instance == null) {
			instance = this;
		}
		else if (instance != this) {
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject);
	}

	void Update() {
		
	}

	IEnumerator LoadAfterDelay() {
		yield return new WaitForSeconds (2f);
		SceneManager.LoadScene ("LevelCleared");
	}


	public static void ResetGame() {
		score = 0;
		currentlevel = 1;
		SceneManager.LoadScene ("Menu Scene");
	}

	public string godName {
		get{ return _godName; }
		set { _godName = value; }
	}

	public string[] strengths {
		get { return _strengths; }
		set { _strengths = value; }
	}

	public string weakness{
		get { return _weakness; }
		set { _weakness = value; }
	}

	public Sprite[] cardFaces{
		get { return _cardFaces; }
		set { _cardFaces = value; }
	}

	public int[] dimensions{
		get { return _dimensions; }
		set { _dimensions = value; }
	}

	public Sprite backgroundUI {
		get{ return _backgroundUI; }
		set { _backgroundUI = value; }
	}
}
