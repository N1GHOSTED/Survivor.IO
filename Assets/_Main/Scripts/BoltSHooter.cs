using System.Collections;
using UnityEngine;

public class BoltSHooter : MonoBehaviour
{
    [Header("Manager")]
    public GameObject Manager;

    [Header("Prefab Manager")]
    public GameObject Diamond;
    public GameObject DiamondPos;
    public GameObject UImanager;

    [Header("Boolean Manager")]
    internal bool EnemyDispo = true;
    internal bool SpawenHire = true;
    internal bool CheckingList = true;

    [Header("Floating Manager")]
    internal int SpawenPoint;

    private Transform[] diamondPoints = new Transform[17];
    private GameObject currentEnemy;
    private float nextEnemyCacheTime;
    private GameManager cachedGameManager;
    private UIManager cachedUIManager;
    private Rigidbody2D cachedRigidbody;

    void Awake()
    {
        Manager = Manager != null ? Manager : GameObject.Find("GameManager");
        DiamondPos = DiamondPos != null ? DiamondPos : GameObject.Find("DiamondPos");
        UImanager = UImanager != null ? UImanager : GameObject.Find("UI");
        cachedGameManager = Manager != null ? Manager.GetComponent<GameManager>() : null;
        cachedUIManager = UImanager != null ? UImanager.GetComponent<UIManager>() : null;
        cachedRigidbody = GetComponent<Rigidbody2D>();

        for (int index = 1; index <= diamondPoints.Length; index++)
        {
            GameObject point = GameObject.Find("Pos" + index);
            if (point != null)
            {
                diamondPoints[index - 1] = point.transform;
            }
        }
    }

    void Start()
    {
        StartCoroutine(ItemSelfDest());
        CheckDestroy();
    }

    void Update()
    {
        CheckDestroy();
        if (Time.time >= nextEnemyCacheTime)
        {
            currentEnemy = GameObject.FindGameObjectWithTag("Enemy");
            nextEnemyCacheTime = Time.time + 0.25f;
        }

        if (cachedUIManager != null && cachedUIManager.DestroyEnemys)
        {
            Destroy(this.gameObject);
            return;
        }

        if (EnemyDispo)
        {
            if (currentEnemy != null)
            {
                MoveToward(currentEnemy.transform.position);
            }
        }
        else
        {
            if (CheckingList)
            {
                SpawenPoint = Random.Range(1, diamondPoints.Length + 1);
                CheckingList = false;
            }
            CheckPlaceSpawening();
        }
    }

    void CheckPlaceSpawening()
    {
        int pointIndex = SpawenPoint - 1;
        if (!SpawenHire || pointIndex < 0 || pointIndex >= diamondPoints.Length || diamondPoints[pointIndex] == null)
        {
            return;
        }

        Transform target = diamondPoints[pointIndex];
        MoveToward(target.position);
        if (Vector2.Distance(transform.position, target.position) <= 0.05f)
        {
            if (Diamond != null)
            {
                GameObject diamond = Instantiate(Diamond, transform.position, Diamond.transform.rotation);
                if (DiamondPos != null)
                {
                    diamond.transform.SetParent(DiamondPos.transform);
                }
            }
            Destroy(this.gameObject);
        }
    }

    void MoveToward(Vector3 target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, 10f * Time.deltaTime);
        Vector2 direction = target - transform.position;
        if (cachedRigidbody != null)
        {
            cachedRigidbody.rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        }
    }

    void CheckDestroy()
    {
        if (cachedGameManager == null)
        {
            return;
        }
        if (cachedGameManager.NormalBolt)
        {
            EnemyDispo = true;
        }
        if (cachedGameManager.DiamondBolt)
        {
            EnemyDispo = false;
        }
    }

    IEnumerator ItemSelfDest()
    {
        if (cachedGameManager != null && cachedGameManager.DiamondBolt)
        {
            yield return new WaitForSeconds(1f);
            if (Diamond != null)
            {
                Instantiate(Diamond, transform.position, transform.rotation);
            }
        }
        else
        {
            yield return new WaitForSeconds(2f);
        }
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }
}
