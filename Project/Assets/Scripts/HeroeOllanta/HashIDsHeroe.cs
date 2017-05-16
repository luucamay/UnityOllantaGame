using UnityEngine;
using System.Collections;

public class HashIDsHeroe : MonoBehaviour
{
	[HideInInspector] public int isWalkingBool;
	[HideInInspector] public int isAtackingBool;
	[HideInInspector] public int deadBool;
	[HideInInspector] public int isWalkingTrigger;
	[HideInInspector] public int isAtackingTrigger;
	[HideInInspector] public int isDeadTrigger;
	[HideInInspector] public int speedFloat;
	[HideInInspector] public int idleState;
	[HideInInspector] public int walkState;
	[HideInInspector] public int runState;
	[HideInInspector] public int atackState;
	[HideInInspector] public int dieState;

	void Awake ()
	{
		isWalkingBool = Animator.StringToHash ("IsWalking");
		isAtackingBool = Animator.StringToHash ("IsAtacking");
		deadBool = Animator.StringToHash ("Dead");
		isWalkingTrigger = Animator.StringToHash ("IsWalking 0");
		isAtackingTrigger = Animator.StringToHash ("IsAtacking 0");
		isDeadTrigger = Animator.StringToHash ("IsDead");
		speedFloat = Animator.StringToHash ("Speed");
		idleState = Animator.StringToHash ("BaseLayer.Idle");
		walkState = Animator.StringToHash ("BaseLayer.Walk");
		runState = Animator.StringToHash ("BaseLayer.Run");
		atackState = Animator.StringToHash ("BaseLayer.Atack");
		dieState = Animator.StringToHash ("BaseLayer.Die");
	}
}
