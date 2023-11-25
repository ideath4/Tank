using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<Transform> spawnPoints;
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] int maxEnemies = 10;
    public  List<Unit> Enemies;
    // Start is called before the first frame update
    void Start()
    {
        Enemies = new List<Unit>();
    }
    void SpawnEnemy()
    {
        Transform point = spawnPoints[Random.Range(0, spawnPoints.Count)];
        GameObject enemy = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Count)]);
        enemy.transform.position = point.position;
        Unit unit = enemy.GetComponent<Unit>();
        Enemies.Add(unit);
        unit.OnEnemyDie.AddListener(OnEnemyDie);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Enemies.Count >= maxEnemies)
            return;
        SpawnEnemy();
    }
    public void OnEnemyDie(Unit unit)
    {
        for(int i = 0; i < Enemies.Count; i++)
        {
            if(Enemies[i] == unit)
            {
                Enemies[i].OnEnemyDie.RemoveListener(OnEnemyDie);
                Enemies.RemoveAt(i);
                return;
            }
        }

    }
}
