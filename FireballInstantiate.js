#pragma strict
var ball : GameObject;
var power : int;
var player : GameObject;
var gamestate : GameObject;
var lockedSpell : GameObject;
var pl : PlayerInfo;
  
 function Start () {
  gamestate = GameObject.Find ("GameState");
  pl = gamestate.GetComponent.<PlayerInfo>();
  lockedSpell = GameObject.Find("greyed1");
}

function Update () {
    var sp : GameObject;	
    var body : Rigidbody;	
    if (Input.GetKeyDown("2") && lockedSpell.activeSelf == false){	
   		 if (/*Time.time - lastSpellTime < cooldown &&*/ pl.queryMana() < 30) {
         	Debug.Log ("not enough mana");
            return;
        }
         var temp : GameObject;
         temp = GameObject.Find("3rdPersonController");
         var temp2 : GameObject;
         temp2 = GameObject.Find("3rdPersonController(Clone)");
        if(player == null){
         		player = GameObject.Find("ShootFireballPoint");
         	}
        if(temp == null){
        	temp2.GetComponent (Animator).SetTrigger("Fireball");
        }
        if(temp != null){
        	temp.GetComponent (Animator).SetTrigger("Fireball");
        }
        sp = Instantiate (ball,player.transform.position,Quaternion.identity);
        body = sp.GetComponent (Rigidbody);
        body.AddRelativeForce (player.transform.forward.normalized * power);
        pl.adjustMana (-30);
      	  if(sp!= null && ball!=null){
            Destroy(sp,1);
        	}

    }
}