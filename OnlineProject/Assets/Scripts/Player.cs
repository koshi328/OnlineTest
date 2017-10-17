using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Photon.MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!photonView.isMine) return;

        float y = Input.GetAxis("Vertical") * Time.deltaTime;
        float x = Input.GetAxis("Horizontal") * Time.deltaTime;
        transform.position += new Vector3(x, y, 0);
	}
}
