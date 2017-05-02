using UnityEngine;
using System.Collections;

public class PatrolState :IEnemyState
{
	private readonly StatePatternEnemy enemy;
	private int nextWayPoint;

	public PatrolState (StatePatternEnemy statePatternEnemy)
	{
		enemy = statePatternEnemy;
	}

	public void UpdateState ()
	{
		Look ();
		Patrol ();
	}

	public void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag ("Player"))
			ToAlertState ();
	}

	public void ToPatrolState ()
	{
		Debug.Log ("Can't transition to same state");
	}

	public void ToAlertState ()
	{
		enemy.currentState = enemy.alertState;
	}

	public void ToChaseState ()
	{
		enemy.currentState = enemy.chaseState;
	}
	//¿puedo ver al enemigo?
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
	//vigilar de acyerdi a los way points
	void Patrol ()
	{
		//para cambiar el color del cubo
		enemy.meshRendererFlag.material.color = Color.green;
		ActualizarWayPointDestino();
		//preguntar si hemos llegado
		if (enemy.controladorNavMesh.HemosLlegado())
		{
			nextWayPoint = (nextWayPoint + 1) % enemy.wayPoints.Length;
		}
	}
	void ActualizarWayPointDestino()
	{
		enemy.controladorNavMesh.ActualizarPuntoDestinoNavMeshAgent(enemy.wayPoints[nextWayPoint].position);
	}
}