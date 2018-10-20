#pragma strict
var ball : GameObject;
var player : GameObject;
var lockedSpell : GameObject;
var gamestate : GameObject;
var pl : PlayerInfo;

function Start () {
  gamestate = GameObject.Find ("GameState");
    pl = gamestate.GetComponent.<PlayerInfo>();
    lockedSpell = GameObject.Find("greyed (3)");
}

function Update () {
var sp : GameObject;	
    var body : Rigidbody;	
    var cam : Camera;		
    cam = Camera.main;
		 var temp : GameObject;
         temp = GameObject.Find("3rdPersonController");
         var temp2 : GameObject;
         temp2 = GameObject.Find("3rdPersonController(Clone)");
    if (Input.GetKeyDown ("4") && lockedSpell.activeSelf == false) {	
    if (pl.queryMana() < 45) {
         	Debug.Log ("not enough mana");
            return;
        }
        	if(temp == null){
         	temp2.GetComponent (Animator).SetTrigger("ArcaneExplosion");
         	}
         	if(temp != null){
         	temp.GetComponent (Animator).SetTrigger("ArcaneExplosion");
         	}
         	if(player == null){
         		player = GameObject.Find("ShootFireballPoint");
         	}
        sp = Instantiate (ball,player.transform.position,Quaternion.identity);
        pl.adjustMana (-45);
        if(sp!= null && ball!=null){
            Destroy(sp,1.2);
        }
    }
}