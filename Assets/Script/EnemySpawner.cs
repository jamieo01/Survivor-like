using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private int _currentThreatLevel;
    [SerializeField] private GameObject[] _spawnableEnemies;

    private int _amountOfSpawnedEnemies = 0;
    private int _maxSpawnableEnemies  = 100;
    private Vector3 _playerPosition;

    private void Update()
    {
        _playerPosition = References.Player.transform.localPosition;
        
        if (_amountOfSpawnedEnemies < _maxSpawnableEnemies) SpawnEnemy();
    }

    private void SpawnEnemy() 
    {
        Instantiate(_spawnableEnemies[0], new Vector3( _playerPosition.x + Random.Range(-40,40) * 10 , 2, _playerPosition.z + Random.Range(-40, 40)* 10) ,Quaternion.identity);

        _amountOfSpawnedEnemies++;
    }
}
