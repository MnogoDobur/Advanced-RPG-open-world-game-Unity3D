#pragma strict
var ball : GameObject;
var power : int;
var player : GameObject;
var gamestate : GameObject;
var lockedSpell : GameObject;
var pl : PlayerInfo;
private var isCasting;
var spellSlider: UnityEngine.UI.Slider;
var spellSliderObject : GameObject;

  
 function Start () {
   gamestate = GameObject.Find ("GameState");
    pl = gamestate.GetComponent.<PlayerInfo>();
    lockedSpell = GameObject.Find("greyed (4)");
}

function Update () {
    var sp : GameObject;	
    var body : Rigidbody;	
    var cam : Camera;		
    cam = Camera.main;
    if (Input.GetKeyDown ("5") && lockedSpell.activeSelf == false) {
     if (pl.queryMana() < 50) {
         	Debug.Log ("not enough mana");
            return;
        }
        else if(pl.queryMana()>= 50 && isCasting!= true){
        	castTornado();
        }

    /*    if(GameObject.tag == "Terrain"){
            this.GetComponent.<Rigidbody>().isKinematic = true;
            this.GetComponent.<Rigidbody>().velocity = Vector3.zero;
            this.GetComponent.<Rigidbody>().angularVelocity = Vector3.zero;
        }
        */

    }
}
function castTornado(){
  var sp : GameObject;	
    var body : Rigidbody;	
    var cam : Camera;		
    cam = Camera.main;
         var temp : GameObject;
         temp = GameObject.Find("3rdPersonController");
         var temp2 : GameObject;
         temp2 = GameObject.Find("3rdPersonController(Clone)");
         if(isCasting == true){
         }
         else{
         	if(temp == null){
         	temp2.GetComponent (Animator).SetTrigger("Tornado");
         	}
         	if(temp != null){
         	temp.GetComponent (Animator).SetTrigger("Tornado");
         	}
         	if(player == null){
         		player = GameObject.Find("ShootFireballPoint");
         	}
			pl.adjustMana (-50);
         	for(var i=0;i<=100;i+=33){
         		spellSliderObject.SetActive(true);
         		spellSlider.value = i;
         			if(spellSlider.value >= 98){
        				sp = Instantiate (ball,player.transform.position,Quaternion.identity);
        				body = sp.GetComponent (Rigidbody);
       				    body.AddRelativeForce (player.transform.forward.normalized * power);
        					if(sp!= null && ball!=null){
            				Destroy(sp,2.5);
        					}  
         			}
         		yield WaitForSeconds(0.5f);
         	}
         	spellSliderObject.SetActive(false);
         }
   }