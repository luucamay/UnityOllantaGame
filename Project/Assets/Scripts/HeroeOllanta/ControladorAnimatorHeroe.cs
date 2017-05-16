using UnityEngine;
using System.Collections;

public class ControladorAnimatorHeroe : MonoBehaviour {
	private Animator animator;
	private HashIDsHeroe hashIDs;

	void Awake () {
		animator = GetComponentInChildren <Animator> ();
		hashIDs = GetComponentInChildren<HashIDsHeroe> ();
	}
	
	public void Atacar (bool ataca)
	{
		animator.SetBool (hashIDs.isAtackingBool,ataca);
	}
}
