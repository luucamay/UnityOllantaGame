using UnityEngine;
using System.Collections;

public class AtackState :IEnemyState
{
	private readonly StatePatternEnemy enemy;

	public AtackState (StatePatternEnemy statePatternEnemy)
	{
		enemy = statePatternEnemy;
	}

	public void UpdateState ()
	{
		Atack ();
	}

	public void OnTriggerEnter (Collider other)
	{
		
	}

	public void ToPatrolState ()
	{
		enemy.currentState = enemy.patrolState;
	}

	public void ToAlertState ()
	{
		enemy.currentState = enemy.alertState;
	}

	public void ToChaseState ()
	{
		enemy.currentState = enemy.chaseState;
	}

	public void ToAtackState ()
	{
		Debug.Log ("Can't transition to same state");
	}

	public void ToLookState ()
	{
	}

	private void Atack ()
	{
		enemy.meshRendererFlag.material.color = Color.magenta;
		enemy.controladorAnimator.Atacar ();
	}
}
