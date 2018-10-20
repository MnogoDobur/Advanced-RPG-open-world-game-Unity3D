#pragma strict
var ball : GameObject;
var power : int;
var player : GameObject;
var gamestate : GameObject;
var pl : PlayerInfo;
 var cooldown : float = 5;
 private var lastSpellTime : float = 0;

  
 function Start () {
  gamestate = GameObject.Find ("GameState");
    pl = gamestate.GetComponent.<PlayerInfo>();
}

function Update () {
    var sp : GameObject;	
    var body : Rigidbody;	
    var cam : Camera;		
    cam = Camera.main;
    if (Input.GetKeyDown ("1")) {	
    if (/*Time.time - lastSpellTime < cooldown &&*/ pl.queryMana() < 25) {
         	Debug.Log ("not enough mana");
            return;
        }
        var temp : GameObject;
         temp = GameObject.Find("3rdPersonController");
         var temp2 : GameObject;
         temp2 = GameObject.Find("3rdPersonController(Clone)");
        if(temp == null){
         	temp2.GetComponent (Animator).SetTrigger("FelBlast");
         	}
        if(temp != null){
         	temp.GetComponent (Animator).SetTrigger("FelBlast");
         	}
       	if(player == null){
         		player = GameObject.Find("ShootFireballPoint");
         	}
        sp = Instantiate (ball,player.transform.position,Quaternion.identity);
        body = sp.GetComponent (Rigidbody);
        body.AddRelativeForce (player.transform.forward.normalized * power);
        pl.adjustMana (-25);
        lastSpellTime = Time.time;
      //  if(sp!= null && ball!=null){
            Destroy(sp,1);
        //}

    }
}