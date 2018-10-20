using UnityEngine;
using System.Collections;

public class FlameWalkAncientSword : MonoBehaviour {
	public GameObject flame;
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
			flame.SetActive (true);
		}
		if (other.gameObject.tag == "Terrain") {
			flame.SetActive (false);
		}
	}
}
