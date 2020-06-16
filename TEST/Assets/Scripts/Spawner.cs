using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float startInterval = 5f;
    [SerializeField] private float interval = 5f;
    [SerializeField] private GameObject[] gameObjects;

    void Update()
    {
        interval -= Time.deltaTime;
        float obstacle = Random.Range(0f, gameObjects.Length);
        if(interval <= 0f)
        {
            GameObject gameObject1 = gameObjects[(int)obstacle];
            Instantiate(gameObject1, transform.position, transform.rotation);
            gameObject1.SetActive(true);
            interval = startInterval;
        }
    }
}
