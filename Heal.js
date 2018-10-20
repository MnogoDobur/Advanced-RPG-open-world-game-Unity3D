#pragma strict
var ball : GameObject;
var gamestate : GameObject;
var pl : PlayerInfo;
var player : GameObject;
private var isCasting;
var spellSlider: UnityEngine.UI.Slider;
var spellSliderObject : GameObject;
function Start () {
    gamestate = GameObject.Find ("GameState");
    pl = gamestate.GetComponent.<PlayerInfo>();
}

function Update () {
    if (Input.GetKeyDown ("q")) {
         if (pl.queryMana() < 100) {
         	Debug.Log ("not enough mana");
            return;
        }
        else if(pl.queryMana()>= 100 && isCasting!= true){
        	castHeal();
        }
    } 

}

 function castHeal(){
  	var sp : GameObject;	
         if(isCasting == true){
         }
         else{
         	var temp : GameObject;
        	temp = GameObject.Find("3rdPersonController");
         	var temp2 : GameObject;
        	temp2 = GameObject.Find("3rdPersonController(Clone)");
            isCasting = true;
         	if(temp == null){
         	temp2.GetComponent (Animator).SetTrigger("Heal");
         	}
         	if(temp != null){
         	temp.GetComponent (Animator).SetTrigger("Heal");
         	}
			pl.adjustMana (-100);
         	for(var i=0;i<=100;i+=20){
         		spellSliderObject.SetActive(true);
         		spellSlider.value = i;
         			if(spellSlider.value >= 98){
        				sp = Instantiate (ball,player.transform.position,Quaternion.identity);
        					if(sp!= null && ball!=null){
            				Destroy(sp,5);
            				isCasting = false;
        					}  
         			}
         		yield WaitForSeconds(0.5f);
         	}
         	spellSliderObject.SetActive(false);
         }
     }
