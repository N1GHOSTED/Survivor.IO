using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SurvivorIO.UpgradeFlow;

public class SpawenManager : MonoBehaviour
{
    [Header("Spawener Managers")]
    public UIManager UI;
    public GameManager Managers;

    [Header("Enemys Manager")]
    public GameObject Zombie;

    [Header("Spawents Poins")]
    public GameObject SpawenLocalisation;
    public GameObject Spawen1;
    public GameObject Spawen2;
    public GameObject Spawen3;
    public GameObject Spawen4;
    public float spawnInterval = 0.9f;
    public int maxEnemies = 150;

    [Header("Boolean Manager")]
    internal bool SpawenPos1 = false;
    internal bool SpawenPos2 = false;
    internal bool SpawenPos3 = false;
    internal bool SpawenPos4 = false;
    internal bool ManagerPose = false;
    [Header("Vectors Controller")]
    internal Vector3 Pos;
    private Coroutine loop;

    private void OnEnable()
    {
        if (loop == null)
        {
            loop = StartCoroutine(SpawnRoutine());
        }
    }

    private void OnDisable()
    {
        if (!gameObject.activeInHierarchy)
        {
            loop = null;
        }
    }

    public IEnumerator stopSpawning()
    {
        yield break;
    }

    public IEnumerator SpaweningManager()
    {
        yield break;
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            if (!ManagerPose && Managers != null && Zombie != null && SpawenLocalisation != null)
            {
                int enemyCount = CountEnemyChildren();
                int spawnCount = SpawnCapacity.GetSpawnCount(enemyCount, Managers.GetEnemyCount(), maxEnemies);
                for (int index = 0; index < spawnCount; index++)
                {
                    GameObject point = index % 2 == 0 ? Spawen1 : Spawen2;
                    if (point == null)
                    {
                        continue;
                    }

                    Vector3 position = point.transform.position;
                    position.x += Random.Range(-5f, 5f);
                    position.y += Random.Range(-5f, 5f);
                    GameObject enemy = Instantiate(Zombie, position, point.transform.rotation);
                    enemy.transform.SetParent(SpawenLocalisation.transform);
                    enemyCount++;
                }
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private int CountEnemyChildren()
    {
        int enemyCount = 0;
        Transform parent = SpawenLocalisation.transform;
        for (int index = 0; index < parent.childCount; index++)
        {
            if (parent.GetChild(index).CompareTag("Enemy"))
            {
                enemyCount++;
            }
        }

        return enemyCount;
    }
}
