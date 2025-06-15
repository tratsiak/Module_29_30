using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int _enemiesToSpawn;

    [SerializeField] private Ork _orkPrefab;
    [SerializeField] private Elf _elfPrefab;
    [SerializeField] private Dragon _dragonPrefab;

    [SerializeField] private EnemySettings _enemySettings;

    private List<Enemy> _enemies = new List<Enemy>();

    private void Start()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < _enemiesToSpawn; i++)
        {
            _enemies.Add(CreateEnemy(_enemySettings.GetSettingsByType(EnemyType.Dragon)));
            _enemies.Add(CreateEnemy(_enemySettings.GetSettingsByType(EnemyType.Elf)));
            _enemies.Add(CreateEnemy(_enemySettings.GetSettingsByType(EnemyType.Ork)));
        }

        foreach (Enemy enemy in _enemies)
            Debug.Log(enemy.GetInfo());
    }

    private Enemy CreateEnemy(ISettings settings)
    {
        switch (settings)
        {
            case DragonSettings dragonSettings:
                Dragon dragon = Instantiate(_dragonPrefab, GetRandomPosition(), Quaternion.identity);
                dragon.Initialize(dragonSettings);
                return dragon;

            case ElfSettings elfSettings:
                Elf elf = Instantiate(_elfPrefab, GetRandomPosition(), Quaternion.identity);
                elf.Initialize(elfSettings);
                return elf;

            case OrkSettings orkSettings:
                Ork ork = Instantiate(_orkPrefab, GetRandomPosition(), Quaternion.identity);
                ork.Initialize(orkSettings);
                return ork;

            default:
                throw new InvalidOperationException($"Invalid enemy settings.");
        }
    }

    private Vector3 GetRandomPosition()
    {
        return new Vector3(UnityEngine.Random.Range(-5f, 5f), 0, UnityEngine.Random.Range(-5f, 5f));
    }
}

[Serializable]
public class EnemySettings
{
    [SerializeField] private OrkSettings[] _orkSettings;
    [SerializeField] private ElfSettings[] _elfSettings;
    [SerializeField] private DragonSettings[] _dragonSettings;

    public ISettings GetSettingsByType(EnemyType enemyType)
    {
        switch (enemyType)
        {
            case EnemyType.Dragon:
                return _dragonSettings[UnityEngine.Random.Range(0, _dragonSettings.Length)];

            case EnemyType.Elf:
                return _elfSettings[UnityEngine.Random.Range(0, _elfSettings.Length)];

            case EnemyType.Ork:
                return _orkSettings[UnityEngine.Random.Range(0, _orkSettings.Length)];

            default:
                throw new ArgumentException($"Invalid enemy type: {enemyType}.");
        }
    }
}
