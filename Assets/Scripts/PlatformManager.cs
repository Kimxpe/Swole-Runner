using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour {

	public GameObject[] platformPrefabs;

	private Transform playerTrans;
	private float spawnZ = -10.0f;
	private float platformLength = 10.0f;
	private float safeZone = 15.0f;
	private int amntPlatformsOnScreen = 5;
	private int lastPrefabIndex = 0;

	private List<GameObject> activePlatforms;

	void Start () {
		activePlatforms = new List<GameObject> ();

		playerTrans = GameObject.FindGameObjectWithTag ("Player").transform;

		for (int i = 0; i < amntPlatformsOnScreen; i++) {
			if (i < 3) {
				SpawnPlatform (0);
			} else {
				SpawnPlatform ();
			}
		}
	}

	void Update () {
		if (playerTrans.position.z - safeZone > (spawnZ - amntPlatformsOnScreen * platformLength)) {
			SpawnPlatform ();
			DeletePlatform ();
		}
	}

	private void SpawnPlatform (int prefabIndex = -1) {
		GameObject go;
		if (prefabIndex == -1) {

			go = Instantiate (platformPrefabs [RandomPrefabIndex()]) as GameObject;
		} else {
			go = Instantiate (platformPrefabs [prefabIndex]) as GameObject;
		}
		go.transform.SetParent (transform);
		go.transform.position = Vector3.forward * spawnZ;
		spawnZ += platformLength;

		activePlatforms.Add (go);
	}

	private void DeletePlatform () {
		Destroy (activePlatforms [0]);
		activePlatforms.RemoveAt (0);
	}

	private int RandomPrefabIndex () {
		if (platformPrefabs.Length <= 1) {
			return 0;
		}

		int randomIndex = lastPrefabIndex;
		while (randomIndex == lastPrefabIndex) {
			randomIndex = Random.Range (0, platformPrefabs.Length);
		}

		lastPrefabIndex = randomIndex;
		return randomIndex;
	}
}
