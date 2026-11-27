using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DiamondVip : MonoBehaviour
{
    public GameObject Player;
    public GameObject Manager;
    public GameObject UIManager;
    internal bool MoveOn = false;
    public bool Green = false;
    public bool WorkOn = true;
    public float ExperienceValue = 1f;
    private bool IsCollected;
    private GameManager gameManager;
    private ManagerMecanique mecanique;
    private UIManager uiManager;
    void Start()
    {
        StartCoroutine(FollowPlayer());
        Player = GameObject.FindGameObjectWithTag("Player");
        Manager = GameObject.Find("GameManager");
        UIManager = GameObject.Find("UI");
        gameManager = Manager != null ? Manager.GetComponent<GameManager>() : null;
        mecanique = UIManager != null ? UIManager.GetComponent<ManagerMecanique>() : null;
        uiManager = UIManager != null ? UIManager.GetComponent<UIManager>() : null;
    }
    void Update()
    {
        if (MoveOn == true)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, Player.transform.position, 10f * Time.deltaTime);
        }
        if(uiManager != null && uiManager.MapReady == false)
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator FollowPlayer()
    {
        if(WorkOn == true)
        {
            yield return new WaitForSeconds(3f);
            MoveOn = true;
            yield return new WaitForSeconds(1f);
            Destroy(this.gameObject);
        }
    }
    IEnumerator FlashingLed()
    {
        yield return new WaitForEndOfFrame();
        if (gameManager != null) gameManager.FillingFlash.SetActive(true);
        yield return new WaitForSeconds(0.005f);
        if (gameManager != null) gameManager.FillingFlash.SetActive(false);
        yield return new WaitForEndOfFrame();
        Destroy(this.gameObject);

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (IsCollected || !other.CompareTag("Player"))
        {
            return;
        }

        IsCollected = true;
        if (gameManager != null) gameManager.ValureLevel += ExperienceValue;
        if (Green)
        {
            if (mecanique != null) mecanique.GemsInt += 1;
        }
        StartCoroutine(FlashingLed());
    }
}
