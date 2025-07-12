using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class SpawnManager : Monosingleton<SpawnManager>
{
    [SerializeField] private EnemySpawnDataList spawnDataList;
    [SerializeField] private Boss bossPrefab;
    [SerializeField] private float radius = 15;
    private float _spawnTime;
    private float _currentSpawnTime;
    private List<Enemy> _spawnEnemyList = new List<Enemy>();
    private float _count = 0;

    private void Start()
    {
        _spawnTime = Random.Range(0f,4.5f);
    }

    private void Update()
    {
        if(GameManager.Instance._isWaiting == false)
        {
            if (GameManager.Instance.isEnd == false)
            {
                _currentSpawnTime += Time.deltaTime;

                foreach (EnemySpawnData data in spawnDataList.datas)
                {
                    if (data.SpawnLevel <= GameManager.Instance._currentwave)
                    {
                        _spawnEnemyList.Add(data.enemy);
                    }
                }

                if (_currentSpawnTime >= _spawnTime)
                {
                    SpawnEnemy();
                }
            }
            else
            {
                if(_count == 0)
                {

                    Vector3 spawnPos = Random.insideUnitCircle.normalized * radius;
                    Boss boss = Instantiate(bossPrefab, spawnPos, Quaternion.identity);
                    _count++;
                }
            }
        }
        
    }

    private void SpawnEnemy()
    {
        int spawnEnemy = Random.Range(0, _spawnEnemyList.Count);
        Vector3 spawnPos = Random.insideUnitCircle.normalized * radius;

        Enemy enemy = _spawnEnemyList[spawnEnemy];
        enemy = Instantiate(enemy, spawnPos, Quaternion.identity);

        RandomSpawnTime();
        _currentSpawnTime = 0;
    }

    private void RandomSpawnTime()
    {
        _spawnTime = Random.Range(0, 4.5f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position,  radius);
    }
}
