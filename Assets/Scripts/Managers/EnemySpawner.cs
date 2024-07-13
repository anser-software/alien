using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemySpawner : MonoBehaviour
{
    
    [SerializeField] private int _maxEnemies;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private float _minRadiusFromPlayer, _maxRadiusFromPlayer;
    [SerializeField] private float _spawnInterval;
    [SerializeField] private float _verticalOffset;
    
    private void Start()
    {
        StartCoroutine(SpawnNPC());
    }

    private IEnumerator SpawnNPC()
    {
        while (true)
        {
            while (EnemyManager.Instance.Enemies.Count < _maxEnemies)
            {
                var npcInstance = Instantiate(_enemyPrefab, GetSpawnPoint(), Quaternion.identity);
                npcInstance.transform.parent = transform;
                yield return null;
            }
            yield return new WaitForSeconds(_spawnInterval);
        }
    }

    private Vector3 GetSpawnPoint()
    {
        var offset = Random.insideUnitCircle.normalized;
        var offset3D = new Vector3(offset.x, 0, offset.y);
        return Player.Instance.transform.position + Vector3.up * _verticalOffset + offset3D * Random.Range(_minRadiusFromPlayer, _maxRadiusFromPlayer);
    }
    
}
