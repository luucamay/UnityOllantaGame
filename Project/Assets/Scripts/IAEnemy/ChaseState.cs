using UnityEngine;
using System.Collections;

public class ChaseState : IEnemyState 

{

	private readonly StatePatternEnemy enemy;

	public ChaseState (StatePatternEnemy statePatternEnemy)
	{
		enemy = statePatternEnemy;
	}

	public void UpdateState()
	{
		Look ();
		Chase ();
	}

	public void OnTriggerEnter (Collider other)
	{
	}

	public void ToPatrolState()
	{
	}

	public void ToAlertState()
	{
		enemy.currentState = enemy.alertState;
	}

	public void ToChaseState()
	{
		Debug.Log ("Can't transition to same state");
	}

	private void Look()
	{
		RaycastHit hit;
		//no puedo ver al enemigo?
		if (!enemy.controladorVision.PuedeVerAlJugador (out hit, true)) {
			ToAlertState ();
		}
	}

	private void Chase()
	{
		enemy.meshRendererFlag.material.color = Color.red;

		enemy.controladorNavMesh.ActualizarPuntoDestinoNavMeshAgent();    
	}
}