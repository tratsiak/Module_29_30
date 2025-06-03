using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int _enemiesToSpawn;

    [SerializeField] private Ork _orkPrefab;
    [SerializeField] private Elf _elfPrefab;
    [SerializeField] private Dragon _dragonPrefab;

    [SerializeField] private OrkSettings[] _orkSettings;
    [SerializeField] private ElfSettings[] _elfSettings;
    [SerializeField] private DragonSettings[] _dragonSettings;

    private void Start()
    {
        SpawnEnemies(_orkPrefab, _orkSettings);
        SpawnEnemies(_elfPrefab, _elfSettings);
        SpawnEnemies(_dragonPrefab, _dragonSettings);
    }

    private void SpawnEnemies(Enemy enemyPrefab, EnemySettings[] settingsPool)
    {
        for (int i = 0; i < _enemiesToSpawn; i++)
        {
            EnemySettings randomSettings = settingsPool[Random.Range(0, settingsPool.Length)];

            Enemy enemy = Instantiate(enemyPrefab, GetRandomPosition(), Quaternion.identity);
            enemy.Initialize(randomSettings);

            Debug.Log(enemy.GetInfo());
        }
    }

    private Vector3 GetRandomPosition()
    {
        return new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f));
    }
}
