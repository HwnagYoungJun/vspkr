using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Transform player;

    void Start()
    {
        // "Player" 태그가 붙은 오브젝트를 찾아서 참조
        player = GameObject.FindWithTag("Player")?.transform;
    }

    void Update()
    {
        if (player == null) return;

        // 플레이어를 향한 방향 벡터 계산
        Vector2 direction = (player.position - transform.position).normalized;

        // 적 이동
        transform.Translate(direction * moveSpeed * Time.deltaTime);

        // 너무 멀어지면 자동 제거 (옵션)
        float despawnDistance = 20f;
        if (Vector2.Distance(transform.position, player.position) > despawnDistance)
        {
            Destroy(gameObject);
        }
    }
}
