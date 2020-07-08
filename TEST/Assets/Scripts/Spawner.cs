using UnityEngine;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    [SerializeField] private static float startInterval = 5f;
    [SerializeField] private SphereInstance[] obstaclePrefabs;
    [SerializeField] private float lifeTime = 2f;

    private float randomInterval;
    private float interval = 5f;
    private float timer = 0f;

    public SpawnManager somethingManager;

    private ScoreManager ScoreManager;
    

    // Це не зрозуміло для чого. Воно не використовується? 

    private void Awake()
    {
        randomInterval = Random.Range(1f, startInterval);
    }

    private void OnEnable()
    {
        interval = randomInterval;
        timer = 0f;
    }

    private void OnDisable()
    {
        ScoreManager.score = 0;
        ScoreManager.redMissCount = 0;
        ScoreManager.greenMissCount = 0;
        ScoreManager.ChangeScore();
    }

    private void Update()
    {
        // тут дуже зле. Купа якихось чисел, купа else. Це треба переробити.  
        timer += Time.deltaTime;
        startInterval = Mathf.Clamp(5f - ((int)timer / 15), 1.5f, 5f);
        lifeTime = Mathf.Clamp(5f - ((int)timer / 15) * 0.5f, 3f, 5f);

        interval -= Time.deltaTime;
        if (interval > 0)
            return;
        randomInterval = Random.Range(1f, startInterval);
        if (interval <= 0)
        {
            somethingManager.SpawnAtRandomPosInsideRect();
            interval = randomInterval;
        }
    }

    public void SpawnObstacle(Vector3 pos)
    {
        var randomPrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
        var instance = Instantiate(randomPrefab, pos, transform.rotation);
        Destroy(instance.gameObject, lifeTime);
    }
}