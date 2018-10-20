using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TeleportBackToWorld : MonoBehaviour {
	// Use this for initialization
	//public GameObject world;
	//public Scene world;
	public GameObject respawnHandler;
	public UnityEngine.SceneManagement.Scene world;
	//public Scene world;


	void Start(){
		world = SceneManager.GetSceneByName ("world");
	}
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other)
	{
		/*
		if (other.tag == "Player" && SceneManager.GetActiveScene() == mountain)
		{
			Application.LoadLevel("SpaceScene");

		}
		*/
		if (other.tag == "Player" && SceneManager.GetActiveScene() == world)
		{
			Destroy (respawnHandler);
			SceneManager.LoadScene(1);
		}
	}
}
