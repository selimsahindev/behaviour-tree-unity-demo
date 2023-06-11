using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;

    private bool isSpawned = false;

    private void Update()
    {
        if (isSpawned)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            enemy.SetActive(true);
            isSpawned = true;
        }
    }
}
