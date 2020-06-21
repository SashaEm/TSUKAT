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

    private readonly List<Vector2> directions = new List<Vector2>
    {
        Vector2.up,
        Vector2.right,
        Vector2.down,
        Vector2.left,
        new Vector2(1,1).normalized, // up+right
        new Vector2(1,-1).normalized, // down+right
        new Vector2(-1,-1).normalized, // down+left
        new Vector2(-1,1).normalized, // up+left
    };

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
        RaycastFromCamera.score = 0;
        RaycastFromCamera.redMissCount = 0;
        RaycastFromCamera.greenMissCount = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer < 15f)
        {
            startInterval = 5f;
            lifeTime = 5f;
        }else if (timer < 30f)
        {
            startInterval = 4f;
            lifeTime =4.5f;
        }
        else if (timer < 45f)
        {
            startInterval = 3f;
            lifeTime =4f;
        }
        else if(timer < 60f)
        {
            startInterval = 2f;
            lifeTime = 3.5f;
        }
        else
        {
            startInterval = 1.5f;
            lifeTime = 3f;
        }
      

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
        //instance.Initialize(directions[Random.Range(0, directions.Count)]);
        Destroy(instance.gameObject, lifeTime);
    }
}