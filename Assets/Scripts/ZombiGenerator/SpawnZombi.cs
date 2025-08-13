using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using UnityEngine;

public class SpawnZombi : MonoBehaviour
{
    [SerializeField] private GameObject _prefZombi;
    private GameObject[] _enamyOnWave;
    [SerializeField] private Vector2[] _spawnPoints = new Vector2[4];
    [SerializeField] private int enemIsDead;
    [SerializeField] private int enemyCount;
    [SerializeField] private int enemyCountProgress;
    [SerializeField] private int enemyCountForProgress;
    [SerializeField] private int enemyOnWave;
    private int enemyRandomSpawnPoint;

    private void Start()
    {
        EventDeathEnamy.EnemyDied += RespawnEnamy;
        EventDeathEnamy.EnemyDied += CountDeadEnamy;
        RespawnEnamy(enemyCount);
    }

    private void FixedUpdate()
    {
        _enamyOnWave = GameObject.FindGameObjectsWithTag("Enamy");
        enemyOnWave = _enamyOnWave.Length;
    }

    /*public void ControlRespawnEnemy()
    {
        enemisOnWave = GameObject.FindGameObjectsWithTag("Enamy");

        while (enemisOnWave.Length < enemyCount)
        {
            if (enemisOnWave.Length < enemyCount)
            {
                RespawnEnamy();
            }
        }
    }*/

    public void CountDeadEnamy()
    {
        enemIsDead++;
        if (enemIsDead % enemyCountForProgress == 0 && enemIsDead != 0)
        {
            enemyCount += enemyCountProgress;
            RespawnEnamy(enemyCountProgress);
        }
    }

    public void RespawnEnamy(int size)
    {
        for (int i = 0; i < size; i++)
        {
            RespawnEnamy();
        }
    }

    private void RespawnEnamy()
    {
        enemyRandomSpawnPoint = Random.Range(0, 4);
        Vector3 position = new Vector3(_spawnPoints[enemyRandomSpawnPoint].x, 1.67f, _spawnPoints[enemyRandomSpawnPoint].y);
        GameObject enemy = Instantiate(_prefZombi, position, Quaternion.identity);
    }

    private void OnDestroy()
    {
        EventDeathEnamy.EnemyDied -= RespawnEnamy;
        EventDeathEnamy.EnemyDied -= CountDeadEnamy;
    }
}
