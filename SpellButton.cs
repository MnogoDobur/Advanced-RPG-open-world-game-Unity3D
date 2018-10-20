using UnityEngine;
using System.Collections;

public class SpellButton : MonoBehaviour {

    public GameObject player;
	public PlayerHandler playerHandlerScript;
	public SpellInventory spellInventory;
	public GameObject learnedSpellEffect;


	// Use this for initialization
	void Start () {
        //playerHandlerScript = (PlayerHandler)player.GetComponent("PlayerHandler");
		learnedSpellEffect = GameObject.Find("LearnedSpell");
    }
	
	// Update is called once per frame
	void Update () {

	}

    public void BuySpell()
    {
		if (gameObject.name == "SpellButton2" && playerHandlerScript.crystalNum > 4 && playerHandlerScript.learnedSpell2 == false)
        {
			if(learnedSpellEffect == null){
				playerHandlerScript.learnedSpell2 = true;
				playerHandlerScript.crystalNum -= 5;
				}
				else{
			learnedSpellEffect.SetActive (false);
            playerHandlerScript.learnedSpell2 = true;
            playerHandlerScript.crystalNum -= 5;
			learnedSpellEffect.SetActive (true);
				}
        }
		if (gameObject.name == "SpellButton3" && playerHandlerScript.crystalNum > 5 && playerHandlerScript.learnedSpell3 == false)
        {
			if(learnedSpellEffect == null){
				playerHandlerScript.learnedSpell3 = true;
				playerHandlerScript.crystalNum -= 6;
			}
			else{
				learnedSpellEffect.SetActive (false);
				playerHandlerScript.learnedSpell3 = true;
				playerHandlerScript.crystalNum -= 6;
				learnedSpellEffect.SetActive (true);
			}
        }
		if (gameObject.name == "SpellButton4" && playerHandlerScript.crystalNum > 6 && playerHandlerScript.learnedSpell4 == false)
        {
			if(learnedSpellEffect == null){
				playerHandlerScript.learnedSpell4 = true;
				playerHandlerScript.crystalNum -= 7;
			}
			else{
				learnedSpellEffect.SetActive (false);
				playerHandlerScript.learnedSpell4 = true;
				playerHandlerScript.crystalNum -= 7;
				learnedSpellEffect.SetActive (true);
			}
        }
		if (gameObject.name == "SpellButton5" && playerHandlerScript.crystalNum > 7 && playerHandlerScript.learnedSpell5 == false)
        {
			if(learnedSpellEffect == null){
				playerHandlerScript.learnedSpell5 = true;
				playerHandlerScript.crystalNum -= 8;
			}
			else{
				learnedSpellEffect.SetActive (false);
				playerHandlerScript.learnedSpell5 = true;
				playerHandlerScript.crystalNum -= 8;
				learnedSpellEffect.SetActive (true);
			}
        }
		if (gameObject.name == "SpellButton6" && playerHandlerScript.crystalNum > 8 && playerHandlerScript.learnedSpell6 == false)
        {
			if(learnedSpellEffect == null){
				playerHandlerScript.learnedSpell6 = true;
				playerHandlerScript.crystalNum -= 9;
			}
			else{
				learnedSpellEffect.SetActive (false);
				playerHandlerScript.learnedSpell6 = true;
				playerHandlerScript.crystalNum -= 9;
				learnedSpellEffect.SetActive (true);
			}
        }
    }
  }

