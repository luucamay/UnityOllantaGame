using UnityEngine;
using System.Collections;

public class HashIDs : MonoBehaviour
{
	[HideInInspector] public int isWalkingHashBool;
	[HideInInspector] public int isRunningBool;
	[HideInInspector] public int lookingSidesBool;
	[HideInInspector] public int isAtackingTrigger;
	[HideInInspector] public int isDeadTrigger;
	[HideInInspector] public int idleState;
	[HideInInspector] public int walkState;
	[HideInInspector] public int runState;
	[HideInInspector] public int lookState;
	[HideInInspector] public int atackState;
	[HideInInspector] public int dieState;

	void Awake ()
	{
		isWalkingHashBool = Animator.StringToHash ("IsWalking");
		isRunningBool = Animator.StringToHash ("IsRunning");
		lookingSidesBool = Animator.StringToHash ("LookingSides");
		isAtackingTrigger = Animator.StringToHash ("IsAtacking");
		isDeadTrigger = Animator.StringToHash ("IsDead");
		idleState = Animator.StringToHash ("BaseLayer.Idle");
		walkState = Animator.StringToHash ("BaseLayer.Walk");
		runState = Animator.StringToHash ("BaseLayer.Run");
		lookState = Animator.StringToHash ("BaseLayer.Look");
		atackState = Animator.StringToHash ("BaseLayer.Atack");
		dieState = Animator.StringToHash ("BaseLayer.Die");
	}
}
