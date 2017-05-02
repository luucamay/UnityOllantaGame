using UnityEngine;
using System.Collections;

public class AlertState : IEnemyState 

{
	private readonly StatePatternEnemy enemy;
	private float searchTimer;

	public AlertState (StatePatternEnemy statePatternEnemy)
	{
		enemy = statePatternEnemy;
	}

	public void UpdateState()
	{
		Look ();
		Search ();
	}

	public void OnTriggerEnter (Collider other)
	{

	}

	public void ToPatrolState()
	{
		enemy.currentState = enemy.patrolState;
		searchTimer = 0f;
	}

	public void ToAlertState()
	{
		Debug.Log ("Can't transition to same state");
	}

	public void ToChaseState()
	{
		enemy.currentState = enemy.chaseState;
		searchTimer = 0f;
	}

	private void Look()
	{
		RaycastHit hit;
		if (Physics.Raycast (enemy.eyes.transform.position, enemy.eyes.transform.forward, out hit, enemy.sightRange) && hit.collider.CompareTag ("Player")) {
			enemy.chaseTarget = hit.transform;
			ToChaseState();
		}
	}

	private void Search()
	{
		enemy.meshRendererFlag.material.color = Color.yellow;
		enemy.navMeshAgent.Stop ();
		enemy.transform.Rotate (0, enemy.searchingTurnSpeed * Time.deltaTime, 0);
		searchTimer += Time.deltaTime;

		if (searchTimer >= enemy.searchingDuration)
			ToPatrolState ();
	}


}