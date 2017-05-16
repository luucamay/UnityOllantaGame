using UnityEngine;
using System.Collections;

public class ControladorAnimator : MonoBehaviour
{
	private Animator animator;
	private HashIDs hashIDs;

	void Awake ()
	{
		animator = GetComponent<Animator> ();
		hashIDs = GetComponent<HashIDs> ();
	}

	public void Caminar ()
	{
		animator.SetBool (hashIDs.isWalkingHashBool, true);
		animator.SetBool (hashIDs.isRunningBool, false);
		animator.SetBool (hashIDs.lookingSidesBool, false);
		animator.SetBool (hashIDs.isAtackingTrigger,false);
	}

	public void Mirar ()
	{
		animator.SetBool (hashIDs.isWalkingHashBool, false);
		animator.SetBool (hashIDs.isRunningBool, false);
		animator.SetBool (hashIDs.lookingSidesBool, true);
		animator.SetBool (hashIDs.isAtackingTrigger,false);
	}

	public void Correr ()
	{
		animator.SetBool (hashIDs.isWalkingHashBool, false);
		animator.SetBool (hashIDs.isRunningBool, true);
		animator.SetBool (hashIDs.lookingSidesBool, false);
		animator.SetBool (hashIDs.isAtackingTrigger,false);
	}

	public void Atacar ()
	{
		animator.SetBool (hashIDs.isWalkingHashBool, false);
		animator.SetBool (hashIDs.isRunningBool, false);
		animator.SetBool (hashIDs.lookingSidesBool, false);
		animator.SetBool (hashIDs.isAtackingTrigger,true);
	}

	public void Morir ()
	{
		animator.SetBool (hashIDs.isWalkingHashBool, false);
		animator.SetBool (hashIDs.isRunningBool, false);
		animator.SetBool (hashIDs.lookingSidesBool, false);
		animator.SetTrigger (hashIDs.isDeadTrigger);
		animator.SetBool (hashIDs.isAtackingTrigger,false);
	}

	public bool AnimacionTerminada ()
	{
		return animator.GetCurrentAnimatorStateInfo (0).IsName ("Look");
	}
}
