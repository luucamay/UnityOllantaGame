using UnityEngine;
using System.Collections;

public class ControladorVision : MonoBehaviour {

    public Transform Ojos;
    public float rangoVision = 20f;
    public Vector3 offset = new Vector3(0f, 0.75f, 0f);

    private ControladorNavMesh controladorNavMesh;

    void Awake()
    {
        controladorNavMesh = GetComponent<ControladorNavMesh>();
    }

    public bool PuedeVerAlJugador(out RaycastHit hit, bool mirarHaciaElJugador = false)
    {
        Vector3 vectorDireccion;
        if (mirarHaciaElJugador)
        {
            vectorDireccion = (controladorNavMesh.perseguirObjectivo.position + offset) - Ojos.position;
        }else
        {
            vectorDireccion = Ojos.forward;
        }

        return Physics.Raycast(Ojos.position, vectorDireccion, out hit, rangoVision) && hit.collider.CompareTag("Player");
    }
}
