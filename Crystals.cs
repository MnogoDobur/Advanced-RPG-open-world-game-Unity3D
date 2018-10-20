using UnityEngine;
using System.Collections;

public class Crystals : MonoBehaviour {
	public PlayerHandler playerScript;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			playerScript.crystalNum++;
			this.gameObject.SetActive (false);
		}
	}
}
