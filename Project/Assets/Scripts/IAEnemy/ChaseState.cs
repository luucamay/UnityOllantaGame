using UnityEngine;
using System.Collections;

public class ChaseState : IEnemyState
{

	private readonly StatePatternEnemy enemy;

	public ChaseState (StatePatternEnemy statePatternEnemy)
	{
		enemy = statePatternEnemy;
	}

	public void UpdateState ()
	{
		Look ();
		Chase ();
	}

	public void OnTriggerEnter (Collider other)
	{
	}

	public void ToPatrolState ()
	{
	}

	public void ToAlertState ()
	{
		enemy.currentState = enemy.alertState;
	}

	public void ToChaseState ()
	{
		Debug.Log ("Can't transition to same state");
	}

	public void ToAtackState ()
	{
		enemy.currentState = enemy.atackState;
	}

	public void ToLookState ()
	{
	}

	private void Look ()
	{
		RaycastHit hit;
		//no puedo ver al enemigo?
		if (!enemy.controladorVision.PuedeVerAlJugador (out hit, true)) {
			ToAlertState ();
		}
	}

	private void Chase ()
	{
		enemy.meshRendererFlag.material.color = Color.red;
		enemy.controladorAnimator.Correr ();
		EstoyCerca ();
		enemy.controladorNavMesh.CambiarVelocidad (3);
		enemy.controladorNavMesh.ActualizarPuntoDestinoNavMeshAgent ();  
	}

	private void EstoyCerca ()
	{
		RaycastHit hit;
		//no puedo ver al enemigo?
		if (enemy.controladorVision.PuedeVerAlJugador (out hit,true,16)) {
			ToAtackState ();
		}
	}

}