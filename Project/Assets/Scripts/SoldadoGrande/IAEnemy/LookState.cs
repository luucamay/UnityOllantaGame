using UnityEngine;
using System.Collections;

public class LookState :IEnemyState
{
	private readonly StatePatternEnemy enemy;
	private float lookTimer;

	public LookState (StatePatternEnemy statePatternEnemy)
	{
		enemy = statePatternEnemy;
	}

	public void UpdateState ()
	{
		Look ();
		ObservarLados ();
	}

	public void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag ("Player"))
			ToAlertState ();
	}

	public void ToPatrolState ()
	{
		enemy.currentState = enemy.patrolState;
		lookTimer = 0f;
	}

	public void ToAlertState ()
	{
		enemy.currentState = enemy.alertState;
		lookTimer = 0f;
	}

	public void ToChaseState ()
	{
		enemy.currentState = enemy.chaseState;
		lookTimer = 0f;
	}

	public void ToAtackState ()
	{//no se puede desde que observa porque primero tiene que estar en chase y luego recien puede atacar
	}

	public void ToLookState ()
	{
		Debug.Log ("Can't transition to same state");
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

	private void ObservarLados ()
	{
		//que se detenga
		enemy.controladorNavMesh.DetenerNavMeshAgent ();
		//comienza a mirar a los lados
		enemy.controladorAnimator.Mirar ();
		//termina de mirar entonces volver al estado de patrulla
		lookTimer += Time.deltaTime;
		if (lookTimer >= enemy.lookingDuration)
			ToPatrolState ();
	}
}
