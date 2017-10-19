using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Photon.MonoBehaviour {

    PhotonView _photonView;
    Renderer _renderer;
    public float _c;
	// Use this for initialization
	void Start () {
        _photonView = GetComponent<PhotonView>();
        _renderer = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!photonView.isMine) return;

        float y = Input.GetAxis("Vertical") * Time.deltaTime;
        float x = Input.GetAxis("Horizontal") * Time.deltaTime;
        transform.position += new Vector3(x, y, 0);

        _photonView.RPC("Send", PhotonTargets.AllViaServer, _c);

        if(Input.GetKey(KeyCode.Space))
        {
            _c = (_c >= 1.0f) ? 0.0f : _c + Time.deltaTime;
        }
	}

    [PunRPC]
    private void Send(float c)
    {
        _renderer.material.color = new Color(c, c, c, 1);
    }
}
