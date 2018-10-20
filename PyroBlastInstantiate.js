#pragma strict
var ball : GameObject;
var power : int;
var player : GameObject;
var lockedSpell : GameObject;
var gamestate : GameObject;
var pl : PlayerInfo;
private var isCasting;
var spellSlider: UnityEngine.UI.Slider;
var spellSliderObject : GameObject;
function Start () {
    gamestate = GameObject.Find ("GameState");
    pl = gamestate.GetComponent.<PlayerInfo>();
    lockedSpell = GameObject.Find("greyed (2)");
}

function Update () {
    var sp : GameObject;	
    var body : Rigidbody;	
    var cam : Camera;		
    cam = Camera.main;

    


    if (Input.GetKeyDown ("3") && lockedSpell.activeSelf == false) {
         if (pl.queryMana() < 40) {
         	Debug.Log ("not enough mana");
            return;
        }
        else if(pl.queryMana()>= 40 && isCasting!= true){
        	castPyroblast();
        }
    } 

}

 function castPyroblast(){
  var sp : GameObject;	
    var body : Rigidbody;	
    var cam : Camera;		
    cam = Camera.main;
         if(isCasting == true){
         }
         else{
         	var temp : GameObject;
        	temp = GameObject.Find("3rdPersonController");
         	var temp2 : GameObject;
        	temp2 = GameObject.Find("3rdPersonController(Clone)");
            isCasting = true;
         	if(temp == null){
         	temp2.GetComponent (Animator).SetTrigger("Pyroblast");
         	}
         	if(temp != null){
         	temp.GetComponent (Animator).SetTrigger("Pyroblast");
         	}
         	if(player == null){
         		player = GameObject.Find("ShootFireballPoint");
         	}
			pl.adjustMana (-40);
         	for(var i=0;i<=100;i+=20){
         		spellSliderObject.SetActive(true);
         		spellSlider.value = i;
         			if(spellSlider.value >= 98){
        				sp = Instantiate (ball,player.transform.position,Quaternion.identity);
        				body = sp.GetComponent (Rigidbody);
       				    body.AddRelativeForce (player.transform.forward.normalized * power);
        					if(sp!= null && ball!=null){
            				Destroy(sp,1);
            				isCasting = false;
        					}  
         			}
         		yield WaitForSeconds(0.15f);
         	}
         	spellSliderObject.SetActive(false);
         }
     }
