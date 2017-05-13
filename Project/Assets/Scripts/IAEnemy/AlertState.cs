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

	public void UpdateState ()
	{
		Look ();
		Search ();
	}

	public void OnTriggerEnter (Collider other)
	{

	}

	public void ToPatrolState ()
	{
		enemy.currentState = enemy.patrolState;
		searchTimer = 0f;
	}

	public void ToAlertState ()
	{
		Debug.Log ("Can't transition to same state");
	}

	public void ToChaseState ()
	{
		enemy.currentState = enemy.chaseState;
		searchTimer = 0f;
	}

	public void ToAtackState ()
	{
	}

	public void ToLookState ()
	{
	}

	private void Look ()
	{
		RaycastHit hit;
		//si puedo ver al jugador, entonces ir al estado de chase
		if (enemy.controladorVision.PuedeVerAlJugador (out hit)) {
			//dar la posicion al navmesh para perseguir al jugador
			enemy.controladorNavMesh.perseguirObjectivo = hit.transform;
			//enemy.chaseTarget = hit.transform;
			ToChaseState ();
		}
	}

	private void Search ()
	{
		enemy.meshRendererFlag.material.color = Color.yellow;
		enemy.controladorAnimator.Caminar ();
		//detenerAgente
		enemy.controladorNavMesh.DetenerNavMeshAgent ();
		//rotar en su propio eje
		enemy.transform.Rotate (0, enemy.searchingTurnSpeed * Time.deltaTime, 0);
		//controlar el tiempo de rotacion
		searchTimer += Time.deltaTime;
		if (searchTimer >= enemy.searchingDuration)
			ToPatrolState ();
	}
}
