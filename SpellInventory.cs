using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpellInventory : MonoBehaviour {

    public GameObject player;
    public PlayerHandler playerHandlerScript;
	public GameObject firstSpellLockedImage;
	public GameObject secondSpellLockedImage;
	public GameObject thirdSpellLockedImage;
	public GameObject fourthSpellLockedImage;
	public GameObject fifthSpellLockedImage;
	public GameObject button1;
	public GameObject button2;
	public GameObject button3;
	public GameObject button4;
	public GameObject button5;
	//public GameObject firstSpellUnlockedImage;
    public Text crystalText;
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        ShowRightAmountOfSpells();
        ShowRightAmountOfCrystals();
	}

    void ShowRightAmountOfSpells()
    {
		if (playerHandlerScript.learnedSpell2 == true)
        {
			firstSpellLockedImage.SetActive (false);
        }
        else
        {
			firstSpellLockedImage.SetActive (true);

        }

		if (playerHandlerScript.learnedSpell3 == true)
        {
			secondSpellLockedImage.SetActive(false);
        }
        else
        {
			secondSpellLockedImage.SetActive(true);;

        }

		if (playerHandlerScript.learnedSpell4 == true)
        {
			thirdSpellLockedImage.SetActive(false);
        }
        else
        {
			thirdSpellLockedImage.SetActive(true);

        }

		if (playerHandlerScript.learnedSpell5 == true)
        {
			fourthSpellLockedImage.SetActive(false);
        }
        else
        {
			fourthSpellLockedImage.SetActive(true);

        }

		if (playerHandlerScript.learnedSpell6 == true)
        {
			fifthSpellLockedImage.SetActive(false);
        }
        else
        {
			fifthSpellLockedImage.SetActive(true);

        }
    }

    void ShowRightAmountOfCrystals()
    {
		crystalText.text = "" + playerHandlerScript.crystalNum;
    }

    
}
