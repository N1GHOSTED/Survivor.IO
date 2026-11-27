using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBullte : MonoBehaviour
{
    public GameObject FollowPoint;
    public bool Sec1;
    public bool Sec2;
    public bool Sec3;
    public bool Sec4;
    public bool Sec5;
    public bool Sec6;
    internal Vector3 Pos;
    private Rigidbody2D cachedRigidbody;

    void Start()
    {
        StartCoroutine(Destri());
        if (FollowPoint == null)
        {
            Destroy(this.gameObject);
            return;
        }
        Pos = FollowPoint.transform.position;
        cachedRigidbody = GetComponent<Rigidbody2D>();
    }
    IEnumerator Destri()
    {
        yield return new WaitForSeconds(4f);
        Destroy(this.gameObject);
    }
    void Update()
    {
        if (FollowPoint == null)
        {
            Destroy(this.gameObject);
            return;
        }
        transform.position = Vector2.MoveTowards(this.transform.position, Pos, 7f * Time.deltaTime);
        Vector2 direction = Pos - transform.position;
        float Angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (cachedRigidbody != null)
        {
            cachedRigidbody.rotation = Angle;
        }

        if(Vector2.Distance(transform.position, Pos) <= 0.05f)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyManager enemy = collision.GetComponent<EnemyManager>();
            if (enemy != null)
            {
                enemy.TakeDamage(1f, "Gun");
            }
            Destroy(this.gameObject);
        }
    }
}
