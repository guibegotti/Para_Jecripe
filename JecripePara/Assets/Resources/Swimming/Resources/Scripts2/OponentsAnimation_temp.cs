using UnityEngine;
using System.Collections;

public class OponentsAnimation_temp : MonoBehaviour {

	public GameObject op1;
	public GameObject op1parent;
	
	public GameObject op2;
	public GameObject op2parent;
	
	
	void Update(){
	
		if(Input.GetKeyDown(KeyCode.U)){
			setJumpTrigger(op1);
			setJumpTrigger(op1parent);
			setJumpTrigger(op2);
			setJumpTrigger(op2parent);
		}
	}
	
	void setJumpTrigger(GameObject go){
		go.GetComponent<Animator>().SetTrigger("JumpOp1");
	}
}
