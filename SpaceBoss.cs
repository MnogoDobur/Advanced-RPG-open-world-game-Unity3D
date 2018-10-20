using UnityEngine;
using System.Collections;
using Invector;

public class SpaceBoss : MonoBehaviour {
	public GameObject plasmaRoad1;
	public GameObject plasmaRoad2;
	private bool foundObj;
	private GameObject gameMenu;
	private GameObject victoryPic;

	void Start () {
	}

	void Update () {
		if (this.transform.GetComponent<vCharacter> ().currentHealth <= 200 && plasmaRoad1.activeSelf == false) {
			this.transform.position = new Vector3 (194.0f, 12.7f, -207.3f);
			plasmaRoad1.SetActive (true);
		}
		if (this.transform.GetComponent<vCharacter> ().currentHealth <= 100 && plasmaRoad2.activeSelf == false) {
			this.transform.position = new Vector3 (438.06f, 9.0f, -206.3491f);
			plasmaRoad2.SetActive (true);
		}
		if (this.transform.GetComponent<vCharacter> ().currentHealth <= 10 || this.transform.GetComponent<vCharacter> () == null) {
			gameMenu = GameObject.Find ("UI/HUD/GameOptionsMenu");
			victoryPic = GameObject.Find ("UI/HUD/GameOptionsMenu/Victory");
			gameMenu.SetActive (true);
			victoryPic.SetActive (true);
		}
	}
}
