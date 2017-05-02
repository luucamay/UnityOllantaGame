using UnityEngine;
using System.Collections;

public class Colisionar : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {
	
	}
	void OnTriggerEnter(Collider otro){
		MeshRenderer rend = GetComponent<MeshRenderer> ();
		rend.material.color = Color.red;

		GameObject detectado = otro.gameObject;
		Debug.Log (detectado.tag);
	}
	void OnTriggerExit(Collider otro){
		MeshRenderer rend = GetComponent<MeshRenderer> ();
		rend.material.color = Color.blue;
		GameObject detectado = otro.gameObject;
		Debug.Log (detectado.tag);
	}
}
