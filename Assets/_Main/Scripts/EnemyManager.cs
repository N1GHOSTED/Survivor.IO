using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using static UnityEngine.GraphicsBuffer;

public class EnemyManager : MonoBehaviour
{
    [Header("Manager Enemy")]
    public GameObject Manager;
    public GameObject HitEffect;
    public GameObject BloodLocalisation;
    public GameObject UImanager;
    private AudioSource Audio;

    public GameObject Bolt;
    private Transform Player;
    internal bool FollowPlayer = true;
    internal float ValueAdd = 1f;
    internal int Diamond;
    private bool DeathStarted;
    private GameManager gameManager;
    private UIManager uiManager;
    private Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    public float Health = 1f;
    public float MaxHealth = 1f;

    [Header("Diamond")]
    public GameObject BlueDiamond;
    public GameObject RedDiamond;
    public GameObject GreenDiamond;

    void Start()
    {
        Manager = Manager != null ? Manager : GameObject.Find("GameManager");
        UImanager = UImanager != null ? UImanager : GameObject.Find("UI");
        BloodLocalisation = BloodLocalisation != null ? BloodLocalisation : GameObject.Find("BloodManager");
        Player = Player != null ? Player : GameObject.FindGameObjectWithTag("Player").transform;
        gameManager = Manager != null ? Manager.GetComponent<GameManager>() : null;
        uiManager = UImanager != null ? UImanager.GetComponent<UIManager>() : null;
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        Diamond = Random.Range(1, 4);
        Audio = GetComponent<AudioSource>();
        if (gameManager != null)
        {
            MaxHealth = gameManager.GetEnemyHealth();
            Health = MaxHealth;
        }
    }

    void Update()
    {
        if(FollowPlayer == true)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, Player.position, gameManager.SpeedEnemy * Time.deltaTime);
            spriteRenderer.flipX = Player.transform.position.x < this.transform.position.x;
        }
        if(uiManager != null && uiManager.DestroyEnemys == true)
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator AnimationController()
    {
        yield return new WaitForSeconds(0.5f);
        if(Diamond == 1)
        {
            (Instantiate(BlueDiamond, transform.position, transform.rotation) as GameObject).transform.SetParent(BloodLocalisation.transform);
        }
        if (Diamond == 2)
        {
            (Instantiate(RedDiamond, transform.position, transform.rotation) as GameObject).transform.SetParent(BloodLocalisation.transform);
        }
        if (Diamond == 3)
        {
            (Instantiate(GreenDiamond, transform.position, transform.rotation) as GameObject).transform.SetParent(BloodLocalisation.transform);
        }
        Destroy(this.gameObject);
    }
    IEnumerator BallController()
    {
        yield return new WaitForSeconds(0.5f);
        if (Diamond == 1)
        {
            (Instantiate(BlueDiamond, transform.position, transform.rotation) as GameObject).transform.SetParent(BloodLocalisation.transform);
        }
        if (Diamond == 2)
        {
            (Instantiate(RedDiamond, transform.position, transform.rotation) as GameObject).transform.SetParent(BloodLocalisation.transform);
        }
        if (Diamond == 3)
        {
            (Instantiate(GreenDiamond, transform.position, transform.rotation) as GameObject).transform.SetParent(BloodLocalisation.transform);
        }
        Destroy(this.gameObject);
    }
    public void TakeDamage(float damage, string damageSource)
    {
        if (DeathStarted)
        {
            return;
        }

        ValueAdd = damage;
        Health -= damage;
        if (Health <= 0f)
        {
            DeathStarted = true;
            if (Audio != null)
            {
                Audio.Play();
            }
            if (Bolt != null)
            {
                Bolt.SetActive(true);
                Bolt.GetComponent<TextMeshProUGUI>().text = damageSource + ": " + damage.ToString("0.##");
            }
            if (animator != null)
            {
                animator.Play("ZombieDeath");
            }
            if (HitEffect != null)
            {
                (Instantiate(HitEffect, transform.position, transform.rotation) as GameObject).transform.SetParent(BloodLocalisation.transform);
            }
            if (gameManager != null)
            {
                gameManager.CurrentKilled += 1;
            }
            StartCoroutine(AnimationController());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (DeathStarted)
        {
            return;
        }

        if (other.CompareTag("Bolt")) TakeDamage(1f, "Bolt");
        else if (other.CompareTag("ball")) TakeDamage(1f, "Ball");
        else if (other.CompareTag("Fire")) TakeDamage(1f, "Fire");
        else if (other.CompareTag("Spiner")) TakeDamage(1f, "Spinner");
        if (other.CompareTag("Player"))
        {
            Audio.Play();
            FollowPlayer = false;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FollowPlayer = true;

        }
    }
}
