using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Invector;

public class PlayerHandler : MonoBehaviour {

	    public GameObject spellMenu;
		public GameObject zoneSelect;
	    public GameObject gameHUD;
		public GameObject worldMap;
		public GameObject gameMenu;
		public GameObject mount;
		public GameObject fireSteps;
		public UnityEngine.UI.Slider mana;
		//public Transform player;
		public GameObject playerObject;
		public Transform mountTransform;
		public GameObject miniMap;
		private bool mounted = false;
		public UnityEngine.UI.Slider castMountSlider;
		public GameObject slider;
//		private bool mountReady = false;
		public GameObject text; 
		public GameObject slamParticle;
	    public int crystalNum ;

	    public bool learnedSpell2 = false;
	    public bool learnedSpell3 = false;
	    public bool learnedSpell4 = false;
	    public bool learnedSpell5 = false;
	    public bool learnedSpell6 = false;
		

	    // Use this for initialization
	    void Start () {
	        DontDestroyOnLoad(transform);
	    }
		
		// Update is called once per frame
		void Update () {
		/*Vector3 fdw = transform.forward;
		if(Physics.Raycast(transform.position,fdw, 10)){
			text.SetActive (true);
		}
		*/
		if (playerObject == null) {
			playerObject = GameObject.Find("3rdPersonController(Clone)");
			worldMap = GameObject.Find ("3rdPersonController(Clone)/WorldMapCamera");
		}
		if (playerObject.transform.GetComponent<vCharacter> ().currentHealth <= 0) {
			if (learnedSpell2 == true) {
				learnedSpell2 = false;
			}
			if (learnedSpell3 == true) {
				learnedSpell3 = false;
			}
			if (learnedSpell4 == true) {
				learnedSpell4 = false;
			}
			if (learnedSpell5 == true) {
				learnedSpell5 = false;
			}
			if (learnedSpell6 == true) {
				learnedSpell6 = false;
			}
		}


			if (mounted == true) {
				//player.transform.position = new Vector3 (mountTransform.position.x, mountTransform.position.y, mountTransform.position.z);
			}
			if (Input.GetKeyDown ("p")) {
			if (spellMenu.activeSelf == true) {
					spellMenu.SetActive (false);
					Cursor.visible = false;
				} else {
						if (gameMenu.activeSelf == true) {
						gameMenu.SetActive (false);
						}
					Cursor.visible = true;
					spellMenu.SetActive (true);
				}
			}
		if (spellMenu.activeSelf != true && gameMenu.activeSelf != true && zoneSelect.activeSelf != true) {
				Cursor.visible = false;
			}
			if (Input.GetKeyDown ("m")) {
			if (worldMap.activeSelf == true) {
					worldMap.SetActive (false);
				} else {
					worldMap.SetActive (true);
				worldMap.transform.position = new Vector3 (playerObject.transform.position.x, (playerObject.transform.position.y + 90), playerObject.transform.position.z);
				}
			}
			if (Input.GetKeyDown ("v")) {
				if (mounted == false) {
					slider.SetActive (true);
					playerObject.transform.GetComponent<Animator>().SetTrigger("MountCast");
					StartSLider ();
					mounted = true;
				} else {
				if (mount.activeSelf == true) {
						mount.SetActive (false);
						playerObject.SetActive (true);
						playerObject.transform.position = new Vector3 (mountTransform.position.x, mountTransform.position.y, mountTransform.position.z);
						mounted = false;
						slider.SetActive (false);
					}
				}
				}
				if (Input.GetKeyDown ("escape")) {
					if (gameMenu.activeSelf == false) {
						if (spellMenu.activeSelf == true) {
						spellMenu.SetActive (false);
						}
					gameMenu.SetActive (true);
					} 
					else {
						gameMenu.SetActive (false);
						Cursor.visible = false;
					}
				}
		if (Input.GetKeyDown ("q")) {
			if (mana.value >= 100) {
				playerObject.transform.GetComponent<vCharacter> ().currentHealth += 100;
			}
		}
	}

	    void OnCollisionEnter(Collision col)
	    {
		if(col.gameObject.name == "Shackles")
	        {
	            crystalNum++;
	            Destroy(col.gameObject);
	        }
			if (col.gameObject.name == "AncientSword") {
				fireSteps.SetActive (true);
			}
	    }
		IEnumerator IncreaseSliderValue()
		{
			for(int val = 0; val <= 100; val+=8)
			{
					castMountSlider.value = val;
				if (val >= 95) {
					castMountSlider.value = 0;
					mount.SetActive (true);
					playerObject.SetActive (false);
					mountTransform.transform.position = new Vector3 (playerObject.transform.position.x, playerObject.transform.position.y, playerObject.transform.position.z);
					mounted = true;
					playerObject.transform.position = new Vector3 (mountTransform.position.x, mountTransform.position.y, mountTransform.position.z);
					slider.SetActive (false);
				}
					yield return new WaitForSeconds (0.15f);
			}
	}
		public void StartSLider()
		{
			StartCoroutine(IncreaseSliderValue());
		}
		public void StopSlider(){
			StopCoroutine (IncreaseSliderValue ());	
		}
		public void SetNumOfCrystals( int num){
			crystalNum = num;
		}
	/*	public void exitGame(){
			Application.Quit;
		}
		*/
	public void OpenLevelSelect(){
		gameMenu.SetActive (false);
		zoneSelect.SetActive (true);
	}
	public void PortToStart(){
		playerObject.transform.position = new Vector3 (241.4f, 0.65f, 476.8f);

	}
	}
