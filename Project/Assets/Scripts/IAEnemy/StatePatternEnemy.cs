using UnityEngine;
using System.Collections;

public class StatePatternEnemy : MonoBehaviour
{
	//velocidad de giro
	public float searchingTurnSpeed = 120f;
	//duracion de busqueda
	public float searchingDuration = 4f;
	//este es un vector de transforms para dar la informacion al navmesh
	public Transform[] wayPoints;/*en el otro script esto esta declarado en el estado patrol*/

	public MeshRenderer meshRendererFlag;//esto es solo para cambiar el color del cubo de acuerdo al estado

	//se declaran variables invisibles en el inspector de tipo estados
	[HideInInspector] public IEnemyState currentState;
	[HideInInspector] public ChaseState chaseState;
	[HideInInspector] public AlertState alertState;
	[HideInInspector] public PatrolState patrolState;
	//se declaran variables invisibles en el inspector que son componentes del enemigo
	[HideInInspector] public Transform chaseTarget;
	[HideInInspector] public NavMeshAgent navMeshAgent;
	[HideInInspector] public ControladorVision controladorVision;
	[HideInInspector] public ControladorNavMesh controladorNavMesh;
	[HideInInspector] public Animator animGuardiaGrande;
	[HideInInspector] public int isWalkingHash=Animator.StringToHash("IsWalking");

	private void Awake ()
	{
		chaseState = new ChaseState (this);
		alertState = new AlertState (this);
		patrolState = new PatrolState (this);
		//obteniendo el componente de navmesh
		navMeshAgent = GetComponent<NavMeshAgent> ();
		controladorVision = GetComponent<ControladorVision> ();
		controladorNavMesh = GetComponent<ControladorNavMesh> ();
		animGuardiaGrande = GetComponent<Animator> ();
	}

	void Start ()
	{
		currentState = patrolState;//definiendo como estado inicial a patrolState
	}

	void Update ()
	{
		currentState.UpdateState ();
	}
	//cuando se activa el trigger activar el trigger del estado actual
	private void OnTriggerEnter (Collider other)
	{
		currentState.OnTriggerEnter (other);
	}
}