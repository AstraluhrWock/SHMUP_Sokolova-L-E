using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    static public Main main;

    public GameObject[] prefabEnemies;
    public float enemySpawnPerSecond = 0.5f;
    public float enemyDefaultPadding = 1.5f;

    private BoundsCheck _boundsCheck;

    private void Awake()
    {
        main = this;
        _boundsCheck = GetComponent<BoundsCheck>();
        Invoke("SpawnEnemy", 1f/enemySpawnPerSecond);
    }

    public void SpawnEnemy()
    {
        int randomPref = Random.Range(0, prefabEnemies.Length);
        GameObject gameObject = Instantiate<GameObject>(prefabEnemies[randomPref]);

        float enemyPadding = enemyDefaultPadding;
        if (gameObject.GetComponent<BoundsCheck>() != null)
        {
            enemyPadding = Mathf.Abs(gameObject.GetComponent<BoundsCheck>().radius);
        }

        Vector3 pos = Vector3.zero;
        float xMin = -_boundsCheck.camWidth + enemyPadding;
        float xMax = _boundsCheck.camWidth - enemyPadding;
        pos.x = Random.Range(xMin, xMax);
        pos.y = _boundsCheck.camHeight + enemyPadding;
        gameObject.transform.position = pos;

        Invoke("SpawnEnemy", 1f/enemySpawnPerSecond);
    }

    public void DelayedRestart(float delay)
    {
        Invoke("Restart", delay);
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
