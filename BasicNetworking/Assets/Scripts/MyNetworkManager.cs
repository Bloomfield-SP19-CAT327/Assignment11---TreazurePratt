using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MyNetworkManager : NetworkManager {

    GameObject playerToSpawn;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        playerToSpawn = (GameObject)Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        playerToSpawn.GetComponent<Player>().color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));

        playerToSpawn.GetComponent<Renderer>().material.color = playerToSpawn.GetComponent<Player>().color;
        NetworkServer.AddPlayerForConnection(conn, playerToSpawn, playerControllerId);
    }
}
