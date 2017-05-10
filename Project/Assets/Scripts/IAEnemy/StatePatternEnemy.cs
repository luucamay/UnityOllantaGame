using UnityEngine;
using System.Collections;

public class StatePatternEnemy : MonoBehaviour
{
	//velocidad de giro
	public float searchingTurnSpeed = 120f;
	//duracion de busqueda
	public float searchingDuration = 4f;
	//duracion de busqueda
	public float lookingDuration = 3f;
	//este es un vector de transforms para dar la informacion al navmesh
	public Transform[] wayPoints;
/*en el otro script esto esta declarado en el estado patrol*/

	public MeshRenderer meshRendererFlag;
//esto es solo para cambiar el color del cubo de acuerdo al estado

	//se declaran variables invisibles en el inspector de tipo estados
	[HideInInspector] public IEnemyState currentState;
	[HideInInspector] public ChaseState chaseState;
	[HideInInspector] public AlertState alertState;
	[HideInInspector] public PatrolState patrolState;
	[HideInInspector] public AtackState atackState;
	[HideInInspector] public LookState lookState;
	//se declaran variables invisibles en el inspector que son componentes del enemigo
	[HideInInspector] public Transform chaseTarget;
	[HideInInspector] public NavMeshAgent navMeshAgent;
	[HideInInspector] public Animator animator;
	[HideInInspector] public ControladorVision controladorVision;
	[HideInInspector] public ControladorNavMesh controladorNavMesh;
	[HideInInspector] public ControladorAnimator controladorAnimator;
	[HideInInspector] public HashIDs hashIDs;

	private void Awake ()
	{	//estas lineas son medio conflictivas para mí
		chaseState = new ChaseState (this);
		alertState = new AlertState (this);
		patrolState = new PatrolState (this);
		atackState = new AtackState (this);
		lookState = new LookState (this);
		//obteniendo el componente de navmesh
		navMeshAgent = GetComponent<NavMeshAgent> ();
		animator = GetComponent<Animator> ();
		controladorVision = GetComponent<ControladorVision> ();
		controladorNavMesh = GetComponent<ControladorNavMesh> ();
		controladorAnimator = GetComponent<ControladorAnimator> ();
		hashIDs = GetComponent<HashIDs> ();
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
