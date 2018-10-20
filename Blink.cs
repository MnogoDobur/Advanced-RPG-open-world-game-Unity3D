using UnityEngine;

using System.Collections;


public class Blink : MonoBehaviour {

	public GameObject point;
	void Start () {
	
	}


     
 	
		
void Update () {
		/*
		Vector3 blinkDirection = transform.TransformDirection(Vector3.forward);
		RaycastHit hit = new RaycastHit();
		GameObject objectHit;
		float blinkLength = 5;
		float maxBlinkLength = 5;
		if (Physics.Raycast (transform.position, blinkDirection, out hit, maxBlinkLength)) {
			objectHit = hit.transform.gameObject;
			Debug.Log(objectHit.name);
		}
*/




	if(Input.GetKeyDown("f")){
		//	transform.position += (transform.forward * 10) + (transform.up*1);
			Vector3 blinkDirection = transform.TransformDirection(Vector3.forward);
			RaycastHit hit = new RaycastHit();
			GameObject objectHit;
			float blinkLength = 9;
			float maxBlinkLength = 5;
			if (Physics.Raycast (transform.position, blinkDirection, out hit, maxBlinkLength)) {
				

				objectHit = hit.transform.gameObject;
				if (objectHit != null) {
					transform.position = transform.position + (blinkDirection * blinkLength);

				}
				//Debug.Log(objectHit.name);
			}






			/*if (!Physics.Raycast (transform.position, blinkDirection,out hit,maxBlinkLength)) {
				//blinkLength = hit.distance;
				/*objectHit = hit.gameObject;
				if (objectHit.tag != "Terrain") {
					
				}

				transform.position = transform.position + (blinkDirection * blinkLength);
			}*/
}
 
     
 


		//transform.position += (transform.forward * 10) + (transform.up*1);

}
}
