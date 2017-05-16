using UnityEngine;
using System.Collections;

public class VRWalkWhilePressing : MonoBehaviour {
	//que tan rapido se mueve
	public float speed = 3.0F;
	public float rotateSpeed = 3.0F;
	//debo avanzar o no
	public bool moveForward;
	//script del CharacterController
	private CharacterController controller;
	//GvrViewer Script
	//private GvrViewer gvrViewer;
	//VR Head
	private Transform vrHead;
	//Animator o máquina de estados de Ollanta
	private Animator animOllanta;
	//Codigo Hash para acceder a parametro del animator y que no tarde en comparar cadena a cadena
	int speedHash=Animator.StringToHash("Speed");
	void Start(){
		//encontrar al CharacterController
		controller = GetComponent<CharacterController>();
		//encontrar GvrViewer en el hijo 0
		//gvrViewer =transform.GetChild(0).GetComponent<GvrViewer>();
		//Encontrar la cabeza VR Head
		vrHead =Camera.main.transform;
		//encontrar animacion de Ollantay
		animOllanta = GetComponentInChildren<Animator>();
	}

	void Update() {
		//En el boton de Google VR, o el  Gear VR touchpad is pressed 
		if (Input.GetButton ("Fire1")) {
			//Cambiar el estado de  moveForward
			moveForward = true;
			//cambiar el estado de animacion a caminar
			/*en un futuro ver la opcion que mientras mas tiempo se presione el bóton mas caminar*/
			animOllanta.SetFloat (speedHash,0.5f);
		} else {
			moveForward = false;
			//cambiar el estado de animacion a idle
			animOllanta.SetFloat (speedHash,0);
		}
		//Revisar si el terreno si debo moverme
		if(moveForward){
			//Encontrar la direccion del forward
			Vector3 forward = vrHead.TransformDirection(Vector3.forward);
			//decirle al CharacterController moverse adelante
			controller.SimpleMove(forward * speed);
		}

	}
}
