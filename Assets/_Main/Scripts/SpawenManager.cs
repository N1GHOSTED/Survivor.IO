using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [Header("Boolean Manager")]
    internal bool SpawenPos1 = false;
    internal bool SpawenPos2 = false;
    internal bool SpawenPos3 = false;
    internal bool SpawenPos4 = false;
    internal bool ManagerPose = false;
    internal bool MakeIt = false;
    [Header("Vectors Controller")]
    internal Vector3 Pos;

    void OnEnable()
    {
        MakeIt = true;
        StopAllCoroutines();
        StartCoroutine(SpawnRoutine());
    }
    void OnDisable()
    {
        MakeIt = false;
        StopAllCoroutines();
    }
    void Update()
    {

            MakeIt = true;
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
        while (MakeIt && Managers != null && Zombie != null)
        {
            if (!ManagerPose)
            {
                int count = Managers.GetEnemyCount();
                for (int index = 0; index < count; index++)
                {
                    GameObject point = index % 2 == 0 ? Spawen1 : Spawen2;
                    if (point == null || SpawenLocalisation == null)
                    {
                        continue;
                    }

                    Vector3 position = point.transform.position;
                    position.x += Random.Range(-5f, 5f);
                    position.y += Random.Range(-5f, 5f);
                    GameObject enemy = Instantiate(Zombie, position, point.transform.rotation);
                    enemy.transform.SetParent(SpawenLocalisation.transform);
                }
            }
            yield return new WaitForSeconds(0.9f);
        }
    }
}
