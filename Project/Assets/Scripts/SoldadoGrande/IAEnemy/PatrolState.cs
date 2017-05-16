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

	public void ToAtackState ()
	{
	}

	public void ToLookState ()
	{
		enemy.currentState = enemy.lookState;
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
		ActualizarWayPointDestino ();
		//preguntar si hemos llegado
		enemy.controladorAnimator.Caminar ();
		if (enemy.controladorNavMesh.HemosLlegado ()) {
			nextWayPoint = (nextWayPoint + 1) % enemy.wayPoints.Length;
			//detener script e ir a estado de observar a los costados
			ToLookState ();
		}
	}

	void ActualizarWayPointDestino ()
	{
		enemy.controladorNavMesh.ActualizarPuntoDestinoNavMeshAgent (enemy.wayPoints [nextWayPoint].position);
	}
}