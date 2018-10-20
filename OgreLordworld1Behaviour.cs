using UnityEngine;
using System.Collections;
using Invector;
public class OgreLordworld1Behaviour : MonoBehaviour {
	public GameObject phrase;
	public Transform stopPosition;
	public GameObject energyExplosion;
	private GameObject player;
	private bool usedSpell1;
	private bool usedSpell2;
	private int i;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("3rdPersonController");
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.GetComponent<vCharacter> ().currentHealth <= 150 && usedSpell1==false) {
			player.transform.GetComponent<vCharacter> ().currentHealth -=30;
			GameObject temp;
			temp = (GameObject)Instantiate (energyExplosion, this.transform.position, Quaternion.identity);
			this.transform.GetComponent<Animator>() .SetTrigger("Pyroblast");
			usedSpell1 = true;
			Destroy (temp, 10);
		}
		if (this.transform.GetComponent<vCharacter> ().currentHealth <= 80 && usedSpell2==false) {
			phrase.SetActive (true);
			this.transform.GetComponent<v_AIMotor> ().patrolSpeed = 1f;
			this.transform.GetComponent<v_AIMotor> ().currentState = v_AIMotor.AIStates.PatrolWaypoints;
				usedSpell2 = true;
				this.transform.GetComponent<v_AIMotor> ().currentState = v_AIMotor.AIStates.Idle;
			}
		}
	}
