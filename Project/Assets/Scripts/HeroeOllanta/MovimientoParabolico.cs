using UnityEngine;
using System.Collections;

public class MovimientoParabolico : MonoBehaviour {
	public float distancia;
	public GameObject prefab;
	void Start () {
	}
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.A)){
			lanzar ();
		}
	}
	public void lanzar(){
		//GameObject nuevaLanza = (GameObject) Instantiate (prefab, transform.position+Camera.main.transform.forward*2, transform.rotation);
		GameObject nuevaLanza = (GameObject) Instantiate (prefab);
		nuevaLanza.transform.position = transform.position+Camera.main.transform.forward*4;
		Rigidbody rb = nuevaLanza.GetComponent <Rigidbody> ();
		rb.velocity = Camera.main.transform.forward*distancia;
	}
}

