using UnityEngine;
using System.Collections;
using Invector;
using UnityEngine.SceneManagement;
public class ExplosionDamageCustom : MonoBehaviour {
	 public GameObject explosion;
	 public UnityEngine.SceneManagement.Scene world;
	public UnityEngine.SceneManagement.Scene mountain;
	public UnityEngine.SceneManagement.Scene Eternalvalley;
	// Use this for initialization
	void Start () {
		world = SceneManager.GetSceneByName ("world");
		mountain = SceneManager.GetSceneByName ("Mountain");
		Eternalvalley = SceneManager.GetSceneByName ("Eternal valley");
	}
	void OnCollisionEnter(Collision otherObj) {
		GameObject obj = this.gameObject;
		if (otherObj.gameObject.tag != "Player" && otherObj.gameObject.tag != "Terrain" && otherObj.gameObject.tag == "magic" && SceneManager.GetActiveScene().name.Equals(world.name)) {
			Instantiate (explosion, transform.position, transform.rotation);

			Destroy (obj);
		}
		if (otherObj.gameObject.tag == "Player" && SceneManager.GetActiveScene().name.Equals(mountain.name) && SceneManager.GetActiveScene().name.Equals(Eternalvalley.name)) {
			otherObj.transform.GetComponent<vCharacter> ().currentHealth -=  20;
		}
		if (otherObj.gameObject.tag == "Player" && this.gameObject.tag == "magic") {
			otherObj.transform.GetComponent<vCharacter> ().currentHealth -=  30;
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
