using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMgr : MonoBehaviour
{
    public Vector2 rangeX;
    public Vector2 rangeY;
    public GameObject powerUpPrefab;
    public float spawnTimer = 5.0f;

	private GameObject powerUpInstance;
	private bool isSpawning = false;

    private void Start()
    {
		StartCoroutine(SpawnTimer());
		spawnTimer = ParametersMgr.instance.GetParameterFloat("timeIntervalBetweenSpawns");
    }

	private void Update()
	{
		if (isSpawning == false && powerUpInstance == null)
		{
			StartCoroutine(SpawnTimer());
		}

		if (Input.GetKey(KeyCode.R))
		{
			SceneManager.LoadScene(0);
		}
	}

    private IEnumerator SpawnTimer()
    {
		isSpawning = true;
        yield return new WaitForSeconds(spawnTimer);
		powerUpInstance = Spawn();
		isSpawning = false;
    }

    private GameObject Spawn()
    {
        float randX = Random.Range(rangeX.x, rangeX.y);
        float randY = Random.Range(rangeY.x, rangeY.y);
		GameObject result = GameObject.Instantiate(powerUpPrefab);
		result.GetComponent<OrbitorPowerUp>().Setup(randX, randY);
		return result;
    }

}
