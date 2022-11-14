using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Transform points;
    Transform[] enemy;
    [SerializeField] GameObject enemyPrefab;
    GameObject go;

    // Start is called before the first frame update
    void Start()
    {
        enemy = new Transform[points.childCount];
        for (int i = 0; i < enemy.Length; i++)
        {
            enemy[i] = points.GetChild(i);
            go = Instantiate(enemyPrefab, points.GetChild(i));
            go.transform.position = enemy[i].position;
        }
    }
}