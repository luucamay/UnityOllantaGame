using UnityEngine;
using System.Collections;

public class ArmaHeroe : MonoBehaviour {
	Rigidbody rb;	
	void Start () {
		rb = GetComponent <Rigidbody> ();
	}
	
	void FixedUpdate () {
		if (rb.velocity != Vector3.zero) {
			//transform.rotation = Quaternion.LookRotation (rb.velocity);
			transform.forward = Vector3.Slerp (transform.forward, rb.velocity.normalized, Time.deltaTime);
		}
	}
}
