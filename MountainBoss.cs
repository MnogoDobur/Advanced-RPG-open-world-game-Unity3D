using UnityEngine;
using System.Collections;
using Invector;
using UnityEngine.SceneManagement;
public class MountainBoss : MonoBehaviour {
	public GameObject enemy1;
	public GameObject enemy2;
	public GameObject projectile;
	public GameObject aoe;
	public Animator anim;
	private Rigidbody rig;
	public GameObject phrase1;
	public GameObject phrase2;
	public GameObject phrase3;
	public GameObject phrase4;
	private bool castedSpell;
	private bool calledGuards;
	private bool startedSpeach;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (this.transform.GetComponent<vCharacter> ().currentHealth);
		if (this.transform.GetComponent<vCharacter> ().currentHealth <= 280 && this.transform.GetComponent<vCharacter> ().currentHealth >=250 && castedSpell == false) {
			phrase1.SetActive (true);
			anim.SetTrigger ("ArcaneExplosion");
			for (int i=0; i < 15; i++) {
				GameObject temp;
				temp = (GameObject)Instantiate (projectile, this.transform.position, Quaternion.identity);
				Debug.Log ("boom");
				rig = temp.GetComponent<Rigidbody> ();
				rig.AddRelativeForce (this.transform.forward.normalized * 1500);
				Destroy (temp, 2);
			}
			castedSpell= true;
		}
		if (this.transform.GetComponent<vCharacter> ().currentHealth <= 240 && castedSpell == true) {
				GameObject temp;
			phrase2.SetActive (true);
			temp = (GameObject)Instantiate (aoe, this.transform.position, Quaternion.identity);
			anim.SetTrigger ("Pyroblast");
				Debug.Log ("boom");
				Destroy (temp, 3);
				castedSpell= false;
		}
		if (this.transform.GetComponent<vCharacter> ().currentHealth <= 200 && calledGuards == false) {
			phrase3.SetActive (true);
			enemy1.transform.GetComponent<v_AIMotor> ().currentState = v_AIMotor.AIStates.PatrolWaypoints;
			enemy2.transform.GetComponent<v_AIMotor> ().currentState = v_AIMotor.AIStates.PatrolWaypoints;
			calledGuards = true;
		}
		if (this.transform.GetComponent<vCharacter> ().currentHealth <= 80 && startedSpeach == false) {
			phrase4.SetActive (true);
			anim.SetTrigger ("AIteleport");
			startedSpeach = true;
			startSpeach ();
		}
	}
	IEnumerator speach(){
		for (int i = 0; i < 4; i++) {
			if (i == 3) {
				SceneManager.LoadScene(2);
			}
			yield return new WaitForSeconds (1);
		}
	}
	public void startSpeach()
	{
		StartCoroutine(speach());
	}
}
