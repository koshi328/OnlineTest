using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public virtual void Movement(float x, float z, float speed)
    {
        Vector3 vel = new Vector3(x, 0, z).normalized * speed * Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(Vector3.Lerp(vel, transform.forward, 0.05f));
        transform.position += vel;
    }
}
