using UnityEngine;
using System.Collections;

public class MatarSoldado : MonoBehaviour
{
	public ControladorAnimator controladorAnimator;

	void Start ()
	{
	}

	void Update ()
	{
	
	}

	void OnTriggerEnter (Collider otro)
	{
		if (otro.CompareTag ("Enemy")) {
			Debug.Log (otro);
			//deshabilitando el cubo;
			//otro.GetComponentInParent <Transform>().GetChild (3).gameObject.SetActive (false);
			//deshabilitando los ojos;
			otro.gameObject.SetActive (false);
			//obteniendo el animator;
			controladorAnimator = otro.gameObject.GetComponentInParent <ControladorAnimator> ();
			controladorAnimator.Morir ();
		}
	}
}
