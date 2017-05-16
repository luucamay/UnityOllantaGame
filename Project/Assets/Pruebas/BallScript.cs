using UnityEngine;
using System.Collections;
 
public class BallScript : MonoBehaviour {
 
 
    public GameObject ParentBone;
    public Rigidbody RBody;
    public float Force;
    public bool hasbeenthrown;
 
 
    void Start () {
 
   
        transform.position = ParentBone.transform.position;
        RBody.useGravity = false;
        hasbeenthrown = false;
    }
   
    void Update () {
 
        if(!hasbeenthrown){
 
        transform.position = ParentBone.transform.position;
        }
    }
 
    public void ReleaseMeow(){
 
        transform.parent = null;
        RBody.useGravity = true;
        transform.rotation = ParentBone.transform.rotation;
        RBody.AddForce (transform.forward * Force);
        hasbeenthrown = true;
    }
}