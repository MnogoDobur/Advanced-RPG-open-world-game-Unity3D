using UnityEngine;
using System.Collections;
using Invector;
public class CompanionOpeningDoor : MonoBehaviour {
	public GameObject door1;
	public GameObject door2;
	public GameObject door3;
	public GameObject companion;
	public Animator anim;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other)
	{


		if (other.gameObject.tag == "Door")
		{
			Destroy (this.door1);
			Destroy (this.door2);
			Destroy (this.door3);
			Destroy (this.companion);
			anim.SetTrigger("Fireball");
		}
		if (other.gameObject.tag == "Player") {
				this.gameObject.transform.GetComponent<v_AIMotor> ().currentState = v_AIMotor.AIStates.PatrolWaypoints;
			this.gameObject.transform.GetComponent<v_AIMotor> ().patrolSpeed = 0.9f;
		}
	}
}
