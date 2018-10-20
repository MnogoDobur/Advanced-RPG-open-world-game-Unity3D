using UnityEngine;
using System.Collections;
using Invector;
using UnityEngine.SceneManagement;

public class PlayerPrefferences : MonoBehaviour {
	public GameObject player;
	public PlayerHandler playerHandlerScript;
	public UnityEngine.SceneManagement.Scene mountain;
	public UnityEngine.SceneManagement.Scene spacescene;
	public UnityEngine.SceneManagement.Scene world;
	public UnityEngine.SceneManagement.Scene world2;
	//public vCharacter iChar;
	//public GameObject ogre1;

	void Start () {
		mountain = SceneManager.GetSceneByName ("Mountain");
		spacescene = SceneManager.GetSceneByName ("SpaceScene");
		world = SceneManager.GetSceneByName ("world");
		world2 = SceneManager.GetSceneByName ("world2");
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void SavePlayer(){
		if (player == null) {
			player = GameObject.Find("3rdPersonController(Clone)");
		}
		PlayerPrefs.SetFloat ("positionX", player.transform.position.x);
		PlayerPrefs.SetFloat ("positionY", player.transform.position.y);
		PlayerPrefs.SetFloat ("positionZ", player.transform.position.z);
		PlayerPrefs.SetInt ("numOfCrystals", playerHandlerScript.crystalNum);
		Debug.Log ("aaaaaaaa: " + SceneManager.GetActiveScene ().name);
		if (SceneManager.GetActiveScene ().name == "Mountain") {
			PlayerPrefs.SetInt ("SavedAtScene", 2);
			Debug.Log ("TUka sum2");
		}
		if (SceneManager.GetActiveScene().name == "SpaceScene") {
			PlayerPrefs.SetInt ("SavedAtScene", 3);
			Debug.Log ("TUka sum3");
		}
		if (SceneManager.GetActiveScene().name == "world") {
			PlayerPrefs.SetInt ("SavedAtScene", 0);
			Debug.Log ("TUka sum1");
		}

		/**
	 *I'm using Array of GameObjects which tag is Crystal and on every of them I check if they are collected,
	 *If they are collected I set the PlayerPreff for the crystal to have value 1 and have the name of the GameObject as a KEY
	 *Note: this requires unique names
	 *Note: GameObject.FindGameObjectsWithTag only returns active GameObjects that's why I'm saving the one active so later on I can work
	 *arround this issue when I load (when player loads game everything will be spawned at first so the functions will return all of the crystals
	 **/

		GameObject[] crystals = GameObject.FindGameObjectsWithTag ("Crystal");
		for (int i = 0; i < crystals.Length; i++) {
			if (crystals [i].gameObject.activeSelf == true) {
				PlayerPrefs.SetInt (crystals [i].gameObject.name, 1);
				Debug.Log (crystals [i].gameObject.name);
			} else {
				PlayerPrefs.SetInt(crystals[i].gameObject.name,0);
			}
		}

		/**
	 *I'm using Array of GameObjects which tag is Enemy and on every of them I check if they are alive,
	 *If they aren't alive when saved I set the PlayerPreff for this enemy to have value 1 and have the name of the GameObject as a KEY
	 **/
		GameObject[] enemys = GameObject.FindGameObjectsWithTag ("Enemy");
		for (int i = 0; i < enemys.Length; i++) {
			if (enemys [i].name !=  "OgreEnemy(Clone)") {
				//Debug.Log (enemys [i]);
				if (enemys [i].transform.GetComponent<vCharacter> () == null) {
					PlayerPrefs.SetInt (enemys [i].gameObject.name, 1);
				} else {
					PlayerPrefs.SetInt (enemys [i].gameObject.name, 0);
				}
			}
		}
		/*
		 * Saving learned spells
		 */
		if (playerHandlerScript.learnedSpell2 == true) {
			PlayerPrefs.SetInt ("learnedSpell2", 1);
		} else {
			PlayerPrefs.SetInt ("learnedSpell2", 0);
		}
		if (playerHandlerScript.learnedSpell3 == true) {
			PlayerPrefs.SetInt ("learnedSpell3", 1);
		}
		else {
			PlayerPrefs.SetInt ("learnedSpell3", 0);
		}
		if (playerHandlerScript.learnedSpell4 == true) {
			PlayerPrefs.SetInt ("learnedSpell4", 1);
		}
		else {
			PlayerPrefs.SetInt ("learnedSpell4", 0);
		}
		if (playerHandlerScript.learnedSpell5 == true) {
			PlayerPrefs.SetInt ("learnedSpell5", 1);
		}
		else {
			PlayerPrefs.SetInt ("learnedSpell5", 0);
		}
		if (playerHandlerScript.learnedSpell6 == true) {
			PlayerPrefs.SetInt ("learnedSpell6", 1);
		}
		else {
			PlayerPrefs.SetInt ("learnedSpell6", 0);
		}
	}
	public void LoadPlayer(){
		float x= PlayerPrefs.GetFloat ("positionX");
		float y= PlayerPrefs.GetFloat ("positionY");
		float z= PlayerPrefs.GetFloat ("positionZ");

		if (PlayerPrefs.GetInt ("SavedAtScene") == 2) {
			SceneManager.LoadScene(1);
		}
		if (PlayerPrefs.GetInt ("SavedAtScene") == 3) {
			SceneManager.LoadScene(2);
		}

		player.transform.position = new Vector3 (x, y, z);
		int crystalNumber = PlayerPrefs.GetInt ("numOfCrystals");
		playerHandlerScript.SetNumOfCrystals (crystalNumber); // Setting the number of crystals after load
	/**
	 *For every object in the Array I check it's name( which is the KEY of the playerpreff) and if the player preff's int is set to 1
	 *then the crystal has been collected. In the else are the ones collected and when scene is loaded those crystals will be disabled.
	 **/
		GameObject[] crystals = GameObject.FindGameObjectsWithTag ("Crystal");
		for (int i = 0; i < crystals.Length; i++) {
			if (PlayerPrefs.GetInt (crystals [i].gameObject.name) != 1) {
				crystals [i].gameObject.SetActive (false);
			}
			//else {
			//	crystals [i].gameObject.SetActive (false);
			//	Debug.Log (crystals [i].gameObject.name);
			//}
		}

	/**
	 *Again for every object in the Array I check it's name( which is the KEY of the playerpreff) and if the player preff's int is set to 1
	 *then the enemy is dead and when scene is loaded those enemys will die.
	 **/
		GameObject[] enemys = GameObject.FindGameObjectsWithTag ("Enemy");
		for (int i = 0; i < enemys.Length; i++) {
				Debug.Log (enemys [i]);
			if (enemys [i].name != "OgreEnemy(Clone)") {
			//	Debug.Log (enemys [i]);
				if (PlayerPrefs.GetInt (enemys [i].gameObject.name) == 1) {
					//Debug.Log (enemys [i]);
					enemys [i].transform.GetComponent<vCharacter> ().currentHealth = 0;
				}
			}
		}
		/*
		 *Loading learned spells
		 */
		if (PlayerPrefs.GetInt ("learnedSpell2") == 1) {
			playerHandlerScript.learnedSpell2 = true;
		}
		if (PlayerPrefs.GetInt ("learnedSpell3") == 1) {
			playerHandlerScript.learnedSpell3 = true;
		}
		if (PlayerPrefs.GetInt ("learnedSpell4") == 1) {
			playerHandlerScript.learnedSpell4 = true;
		}
		if (PlayerPrefs.GetInt ("learnedSpell5") == 1) {
			playerHandlerScript.learnedSpell5 = true;
		}
		if (PlayerPrefs.GetInt ("learnedSpell6") == 1) {
			playerHandlerScript.learnedSpell6 = true;
		}
	}
}
