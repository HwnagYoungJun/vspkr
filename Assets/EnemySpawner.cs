using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // 스폰할 적 프리팹
    public Transform player;       // 플레이어 Transform
    public float spawnRadius = 10f; // 스폰 반지름(플레이어 기준)
    public float spawnInterval = 2f; // 스폰 간격(초)

    private float timer = 0f;

    void Update()
    {
        if (player == null || enemyPrefab == null) return;
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        // 플레이어 위치 기준 원 바깥 랜덤 위치 계산
        float angle = Random.Range(0, Mathf.PI * 2);
        Vector2 spawnPos = (Vector2)player.position + new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * spawnRadius;
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
} 