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
    lockedSpell = GameObject.Find("greyed (5)");
}

function Update () {
 var sp : GameObject;	
    var body : Rigidbody;	
    var cam : Camera;		
    cam = Camera.main;
    if (Input.GetKeyDown ("e") && lockedSpell.activeSelf == false) {	
    if (pl.queryMana() < 60) {
         	Debug.Log ("not enough mana");
            return;
        }
        var temp : GameObject;
         temp = GameObject.Find("3rdPersonController");
         var temp2 : GameObject;
         temp2 = GameObject.Find("3rdPersonController(Clone)");
         if(temp == null){
         	temp2.GetComponent (Animator).SetTrigger("FelCircle");
         	}
         	if(temp != null){
         	temp.GetComponent (Animator).SetTrigger("FelCircle");
         	}
         	if(player == null){
         		player = GameObject.Find("ShootFireballPoint");
         	}
        sp = Instantiate (ball,player.transform.position,Quaternion.identity);
        body = sp.GetComponent (Rigidbody);
        sp.transform.position += (transform.forward * 15) + (transform.up*1);
        pl.adjustMana (-60);
        if(sp!= null && ball!=null){
            Destroy(sp,4);
        }

    }
}