using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;


public class TileManager : MonoBehaviour {

	public GameObject[] tileprefabs;
	public Transform playerTransform;
	private float spawnz= -6.0f;
	private float tileLength=8.03f;
	private float safezone=15.0f;
	private int amnTileScreen=7;
	public List<GameObject> activeTiles;

	int rInt;
	int last_tile=6;

	// Use this for initialization
	void Start () {
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;	
		for (int i = 0; i < amnTileScreen; i++) {

			SpawnTile ();

		}
	}

	// Update is called once per frame
	void Update () {
		rInt = Random.Range(0,4);

		if ( last_tile != 0 ) {
			rInt = 0;
			last_tile = rInt;
		} 



		if (playerTransform.position.z-safezone> (spawnz - amnTileScreen * tileLength)) {
			

			SpawnTile ();
			deleteTile ();
			SpawnTile (rInt);
			deleteTile ();
		}


	}

	void SpawnTile(int prefabIndex=0){
		GameObject go;
		go = Instantiate (tileprefabs [prefabIndex])as GameObject;
		go.transform.SetParent (transform);
		go.transform.position = Vector3.forward * spawnz;
		spawnz += tileLength;
		activeTiles.Add(go);
	}

	void deleteTile()
	{
		Destroy (activeTiles [0]);
		activeTiles.RemoveAt(0);
	}
}
