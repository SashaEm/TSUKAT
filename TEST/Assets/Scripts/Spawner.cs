using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float startInterval = 5f;
    [SerializeField] private GameObject[] gameObjects;
    [SerializeField] private float lifeTime = 2f;

    private float interval = 5f;

    void Awake()
    {
        interval = startInterval;
    }
    void Update()
    {
        interval -= Time.deltaTime;
        float obstacle = Random.Range(0f, gameObjects.Length);
        if(interval <= 0f)
        {
            GameObject gameObject1 = gameObjects[(int)obstacle];
            GameObject instance = Instantiate(gameObject1, transform.position, transform.rotation);
            instance.SetActive(true);
            Destroy(instance, lifeTime);
            interval = startInterval;
        }
    }
}
