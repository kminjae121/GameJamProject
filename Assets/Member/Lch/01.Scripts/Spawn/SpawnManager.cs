using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Monosingleton<SpawnManager>
{
    [SerializeField] private EnemySpawnDataList spawnDataList;
    [SerializeField] private List<Transform> spawnTrm;
    private float _spawnTime;
    private float _currentSpawnTime;
    private List<Enemy> _spawnEnemyList = new List<Enemy>();

    private void Start()
    {
        _spawnTime = Random.Range(0f,4.5f);
    }

    private void Update()
    {
        _currentSpawnTime += Time.deltaTime;

        foreach(EnemySpawnData data in spawnDataList.datas)
        {
            if(data.SpawnLevel <= GameManager.Instance._currentwave)
            {
                _spawnEnemyList.Add(data.enemy);
            }
        }

        if(_currentSpawnTime >= _spawnTime)
        {
            int spawnTrmIndx = Random.Range(0, spawnTrm.Count);
            int spawnEnemy = Random.Range(0, _spawnEnemyList.Count);

            Enemy enemy = _spawnEnemyList[spawnEnemy];
            enemy = Instantiate(enemy, spawnTrm[spawnTrmIndx].position, Quaternion.identity);

            RandomSpawnTime();
            _currentSpawnTime = 0;
        }
    }

    private void RandomSpawnTime()
    {
        _spawnTime = Random.Range(0, 4.5f);
    }
}
