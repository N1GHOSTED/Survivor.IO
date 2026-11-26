using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using SurvivorIO.UpgradeFlow;

public class ManagerWeapons : MonoBehaviour
{
    [Header("Managers")]
    public SpriteWeapons WeaponsManager;
    public GameManager FillingScore;

    [Header("Manager Componenet Addons")]
    public GameObject GameAddonsWeapons;

    [Header("Buttons GamePlay")]
    public GameObject FirstBtn;
    public GameObject SecondBtn;
    public GameObject ThirdBtn;

    [Header("Names")]
    public Text NameOne;
    public Text NameTwo;
    public Text NameThree;

    [Header("Images")]
    public Image IconOne;
    public Image IconTwo;
    public Image IconThree;
    public Sprite HealthIcon;

    [Header("Description")]
    public TextMeshProUGUI DescriptionOne;
    public TextMeshProUGUI DescriptionTwo;
    public TextMeshProUGUI DescriptionThree;

    [Header("ShootYollow")]
    public GameObject YSpriteOne;
    public GameObject YSpriteTwo;
    public GameObject YSpriteThree;
    public GameObject YSpriteFour;
    public GameObject YSpriteFive;
    public GameObject YSpriteSix;

    [Header("ShootGreen")]
    public GameObject GSpriteOne;
    public GameObject GSpriteTwo;
    public GameObject GSpriteThree;
    public GameObject GSpriteFour;
    public GameObject GSpriteFive;
    public GameObject GSpriteSix;

    [Header("Int Managers")]
    public int PauseFirst;
    public int PauseSecond;
    public int PauseThrees;

    [Header("Boolean Manager")]
    internal bool ActivateWeapon = true;

    private const int HealthOption = 13;
    private const int RapidFireOption = 14;
    private static readonly System.Random OfferRandom = new System.Random();

    void Start()
    {

    }
    void Update()
    {
        if (ActivateWeapon == true)
        {
            if(FillingScore.ScoringLevel.fillAmount == 1)
            {
                GenerateOffers();
            }
        }
    }
    void GenerateOffers()
    {
        List<int> available = new List<int>();
        for (int option = 1; option <= 12; option++)
        {
            if (!WeaponsManager.IsWeaponUnlocked(option))
            {
                available.Add(option);
            }
        }
        available.Add(HealthOption);
        if (FillingScore.FireRateMultiplier < GameManager.MaxFireRateMultiplier)
        {
            available.Add(RapidFireOption);
        }

        ClearButtonListeners();
        List<int> offers = UpgradeOfferSelector.SelectDistinct(available, 3, OfferRandom);
        FirstBtn.SetActive(offers.Count > 0);
        SecondBtn.SetActive(offers.Count > 1);
        ThirdBtn.SetActive(offers.Count > 2);

        PauseFirst = offers.Count > 0 ? offers[0] : 0;
        PauseSecond = offers.Count > 1 ? offers[1] : 0;
        PauseThrees = offers.Count > 2 ? offers[2] : 0;
        if (offers.Count > 0)
        {
            PauseOne();
        }
        if (offers.Count > 1)
        {
            PauseTwo();
        }
        if (offers.Count > 2)
        {
            PauseThree();
        }
        ActivateWeapon = false;
    }

    void ClearButtonListeners()
    {
        FirstBtn.GetComponent<Button>().onClick.RemoveAllListeners();
        SecondBtn.GetComponent<Button>().onClick.RemoveAllListeners();
        ThirdBtn.GetComponent<Button>().onClick.RemoveAllListeners();
    }
    void PauseOne()
    {
        ManagerFirstPlace();
    }
    void PauseTwo()
    {
        ManagerSecondPlace();
    }
    void PauseThree()
    {
        ManagerThirdPlace();
    }

    /////////
    void ManagerThirdPlace()
    {
        if (PauseThrees == 1)
        {
            AguelThree();
        }
        if (PauseThrees == 2)
        {
            BallThree();
        }
        if (PauseThrees == 3)
        {
            BrikThree();
        }
        if (PauseThrees == 4)
        {
            DroneAThree();
        }
        if (PauseThrees == 5)
        {
            DroneBThree();
        }
        if (PauseThrees == 6)
        {
            DroneCThree();
        }
        if (PauseThrees == 7)
        {
            FireGaseThree();
        }
        if (PauseThrees == 8)
        {
            FireShanShonThree();
        }
        if (PauseThrees == 9)
        {
            GunThree();
        }
        if (PauseThrees == 10)
        {
            ProtecteurThree();
        }
        if (PauseThrees == 11)
        {
            SprineAThree();
        }
        if (PauseThrees == 12)
        {
            SprineBThree();
        }
        if (PauseThrees == HealthOption)
        {
            HealthThree();
        }
        if (PauseThrees == RapidFireOption)
        {
            RapidFireThree();
        }
    }
    void ManagerSecondPlace()
    {
        if (PauseSecond == 1)
        {
            AguelTwo();
        }
        if (PauseSecond == 2)
        {
            BallTwo();
        }
        if (PauseSecond == 3)
        {
            BrikWallTwo();
        }
        if (PauseSecond == 4)
        {
            DroneATwo();
        }
        if (PauseSecond == 5)
        {
            DroneBTwo();
        }
        if (PauseSecond == 6)
        {
            DroneCTow();
        }
        if (PauseSecond == 7)
        {
            FireGaaseTwo();
        }
        if (PauseSecond == 8)
        {
            FireShanshonTwo();
        }
        if (PauseSecond == 9)
        {
            GunTwo();
        }
        if (PauseSecond == 10)
        {
            ProtecteurTwo();
        }
        if (PauseSecond == 11)
        {
            SprineATwo();
        }
        if (PauseSecond == 12)
        {
            SprineBTwo();
        }
        if (PauseSecond == HealthOption)
        {
            HealthTwo();
        }
        if (PauseSecond == RapidFireOption)
        {
            RapidFireTwo();
        }
    }
    void ManagerFirstPlace()
    {
        if(PauseFirst == 1)
        {
            AguelOne();
        }
        if (PauseFirst == 2)
        {
            BallOne();
        }
        if (PauseFirst == 3)
        {
            BrikWallOne();
        }
        if (PauseFirst == 4)
        {
            DroneAOne();
        }
        if (PauseFirst == 5)
        {
            DroneBOne();
        }
        if (PauseFirst == 6)
        {
            DroneCOne();
        }
        if (PauseFirst == 7)
        {
            FireGaseOne();
        }
        if (PauseFirst == 8)
        {
            FireShanshonOne();
        }
        if (PauseFirst == 9)
        {
            GunOne();
        }
        if (PauseFirst == 10)
        {
            ProtecteurOne();
        }
        if (PauseFirst == 11)
        {
            SprineAOne();
        }
        if (PauseFirst == 12)
        {
            SprineBOne();
        }
        if (PauseFirst == HealthOption)
        {
            HealthOne();
        }
        if (PauseFirst == RapidFireOption)
        {
            RapidFireOne();
        }
    }
    /// <summary>
    /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    
    public void ClearButton()
    {
        StartCoroutine(FinishingCleaning());
    }
    IEnumerator FinishingCleaning()
    {
        yield return new WaitForSeconds(1f);
        ClearButtonListeners();
    }
    /////////////
    void AguelOne()
    {
        NameOne.text = WeaponsManager.Naguel;
        DescriptionOne.text = WeaponsManager.DAguel;
        IconOne.sprite = WeaponsManager.SAguel;
        FirstBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.Onaguel);
    }
    void AguelTwo()
    {
        NameTwo.text = WeaponsManager.Naguel;
        DescriptionTwo.text = WeaponsManager.DAguel;
        IconTwo.sprite = WeaponsManager.SAguel;
        SecondBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.Onaguel);
    }
    void AguelThree()
    {
        NameThree.text = WeaponsManager.Naguel;
        DescriptionThree.text = WeaponsManager.DAguel;
        IconThree.sprite = WeaponsManager.SAguel;
        ThirdBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.Onaguel);
    }
    /////
    void FireGaseOne()
    {
        NameOne.text = WeaponsManager.NFireGase;
        DescriptionOne.text = WeaponsManager.DFireGase;
        IconOne.sprite = WeaponsManager.SFireGase;
        FirstBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnFireGase);
    }
    void FireGaaseTwo()
    {
        NameTwo.text = WeaponsManager.NFireGase;
        DescriptionTwo.text = WeaponsManager.DFireGase;
        IconTwo.sprite = WeaponsManager.SFireGase;
        SecondBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnFireGase);
    }
    void FireGaseThree()
    {
        NameThree.text = WeaponsManager.NFireGase;
        DescriptionThree.text = WeaponsManager.DFireGase;
        IconThree.sprite = WeaponsManager.SFireGase;
        ThirdBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnFireGase);
    }
    /////
    void FireShanshonOne()
    {
        NameOne.text = WeaponsManager.NSalsaRanshon;
        DescriptionOne.text = WeaponsManager.DSalsaRanshon;
        IconOne.sprite = WeaponsManager.SSalsaRanshone;
        FirstBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnSalsaRanshon);
    }
    void FireShanshonTwo()
    {
        NameTwo.text = WeaponsManager.NSalsaRanshon;
        DescriptionTwo.text = WeaponsManager.DSalsaRanshon;
        IconTwo.sprite = WeaponsManager.SSalsaRanshone;
        SecondBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnSalsaRanshon);
    }
    void FireShanShonThree()
    {
        NameThree.text = WeaponsManager.NSalsaRanshon;
        DescriptionThree.text = WeaponsManager.DSalsaRanshon;
        IconThree.sprite = WeaponsManager.SSalsaRanshone;
        ThirdBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnSalsaRanshon);
    }
    ////
    void BallOne()
    {
        NameOne.text = WeaponsManager.NBall;
        DescriptionOne.text = WeaponsManager.DBall;
        IconOne.sprite = WeaponsManager.SBall;
        FirstBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnBall);
    }
    void BallTwo()
    {
        NameTwo.text = WeaponsManager.NBall;
        DescriptionTwo.text = WeaponsManager.DBall;
        IconTwo.sprite = WeaponsManager.SBall;
        SecondBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnBall);
    }
    void BallThree()
    {
        NameThree.text = WeaponsManager.NBall;
        DescriptionThree.text = WeaponsManager.DBall;
        IconThree.sprite = WeaponsManager.SBall;
        ThirdBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnBall);
    }
    //////
    void SprineBOne()
    {
        NameOne.text = WeaponsManager.NSprineB;
        DescriptionOne.text = WeaponsManager.DSprineB;
        IconOne.sprite = WeaponsManager.SSprineB;
        FirstBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnSprineB);
    }
    void SprineBTwo()
    {
        NameTwo.text = WeaponsManager.NSprineB;
        DescriptionTwo.text = WeaponsManager.DSprineB;
        IconTwo.sprite = WeaponsManager.SSprineB;
        SecondBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnSprineB);
    }
    void SprineBThree()
    {
        NameThree.text = WeaponsManager.NSprineB;
        DescriptionThree.text = WeaponsManager.DSprineB;
        IconThree.sprite = WeaponsManager.SSprineB;
        ThirdBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnSprineB);
    }
    //////
    void SprineAOne()
    {
        NameOne.text = WeaponsManager.NSprineA;
        DescriptionOne.text = WeaponsManager.DSprineA;
        IconOne.sprite = WeaponsManager.SSprineA;
        FirstBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnSprineA);
    }
    void SprineATwo()
    {
        NameTwo.text = WeaponsManager.NSprineA;
        DescriptionTwo.text = WeaponsManager.DSprineA;
        IconTwo.sprite = WeaponsManager.SSprineA;
        SecondBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnSprineA);
    }
    void SprineAThree()
    {
        NameThree.text = WeaponsManager.NSprineA;
        DescriptionThree.text = WeaponsManager.DSprineA;
        IconThree.sprite = WeaponsManager.SSprineA;
        ThirdBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnSprineA);
    }
    ////
    void GunOne()
    {
        NameOne.text = WeaponsManager.NGun;
        DescriptionOne.text = WeaponsManager.DGun;
        IconOne.sprite = WeaponsManager.SGun;
        FirstBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnGun);
    }
    void GunTwo()
    {
        NameTwo.text = WeaponsManager.NGun;
        DescriptionTwo.text = WeaponsManager.DGun;
        IconTwo.sprite = WeaponsManager.SGun;
        SecondBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnGun);
    }
    void GunThree()
    {
        NameThree.text = WeaponsManager.NGun;
        DescriptionThree.text = WeaponsManager.DGun;
        IconThree.sprite = WeaponsManager.SGun;
        ThirdBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnGun);
    }
    ////////////
    void BrikWallOne()
    {
        NameOne.text = WeaponsManager.NBrikeWall;
        DescriptionOne.text = WeaponsManager.DBrikWall;
        IconOne.sprite = WeaponsManager.SBrikWall;
        FirstBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnBrikWall);
    }
    void BrikWallTwo()
    {
        NameTwo.text = WeaponsManager.NBrikeWall;
        DescriptionTwo.text = WeaponsManager.DBrikWall;
        IconTwo.sprite = WeaponsManager.SBrikWall;
        SecondBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnBrikWall);
    }
    void BrikThree()
    {
        NameThree.text = WeaponsManager.NBrikeWall;
        DescriptionThree.text = WeaponsManager.DBrikWall;
        IconThree.sprite = WeaponsManager.SBrikWall;
        ThirdBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnBrikWall);
    }
    /////////
    void DroneAOne()
    {
        NameOne.text = WeaponsManager.NDroneA;
        DescriptionOne.text = WeaponsManager.DDroneA;
        IconOne.sprite = WeaponsManager.SDroneA;
        FirstBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnDroneA);
    }
    void DroneATwo()
    {
        NameTwo.text = WeaponsManager.NDroneA;
        DescriptionTwo.text = WeaponsManager.DDroneA;
        IconTwo.sprite = WeaponsManager.SDroneA;
        SecondBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnDroneA);
    }
    void DroneAThree()
    {
        NameThree.text = WeaponsManager.NDroneA;
        DescriptionThree.text = WeaponsManager.DDroneA;
        IconThree.sprite = WeaponsManager.SDroneA;
        ThirdBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnDroneA);
    }
    /////////////////////
    void DroneBOne()
    {
        NameOne.text = WeaponsManager.NDroneB;
        DescriptionOne.text = WeaponsManager.DDroneB;
        IconOne.sprite = WeaponsManager.SDroneB;
        FirstBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnDroneB);
    }
    void DroneBTwo()
    {
        NameTwo.text = WeaponsManager.NDroneB;
        DescriptionTwo.text = WeaponsManager.DDroneB;
        IconTwo.sprite = WeaponsManager.SDroneB;
        SecondBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnDroneB);
    }
    void DroneBThree()
    {
        NameThree.text = WeaponsManager.NDroneB;
        DescriptionThree.text = WeaponsManager.DDroneB;
        IconThree.sprite = WeaponsManager.SDroneB;
        ThirdBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnDroneB);
    }
    /////////////////////
    void DroneCOne()
    {
        NameOne.text = WeaponsManager.NDroneC;
        DescriptionOne.text = WeaponsManager.DDroneC;
        IconOne.sprite = WeaponsManager.SDroneC;
        FirstBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnDroneC);
    }
    void DroneCTow()
    {
        NameTwo.text = WeaponsManager.NDroneC;
        DescriptionTwo.text = WeaponsManager.DDroneC;
        IconTwo.sprite = WeaponsManager.SDroneC;
        SecondBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnDroneC);
    }
    void DroneCThree()
    {
        NameThree.text = WeaponsManager.NDroneC;
        DescriptionThree.text = WeaponsManager.DDroneC;
        IconThree.sprite = WeaponsManager.SDroneC;
        ThirdBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnDroneC);
    }
    /////////////////////
    void ProtecteurOne()
    {
        NameOne.text = WeaponsManager.NProtecteurGreen;
        DescriptionOne.text = WeaponsManager.DProtecteurGreen;
        IconOne.sprite = WeaponsManager.SProtecteurGreen;
        FirstBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnProtecteurGreen);
    }
    void ProtecteurTwo()
    {
        NameTwo.text = WeaponsManager.NProtecteurGreen;
        DescriptionTwo.text = WeaponsManager.DProtecteurGreen;
        IconTwo.sprite = WeaponsManager.SProtecteurGreen;
        SecondBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnProtecteurGreen);
    }
    void ProtecteurThree()
    {
        NameThree.text = WeaponsManager.NProtecteurGreen;
        DescriptionThree.text = WeaponsManager.DProtecteurGreen;
        IconThree.sprite = WeaponsManager.SProtecteurGreen;
        ThirdBtn.GetComponent<Button>().onClick.AddListener(WeaponsManager.OnProtecteurGreen);
    }

    void HealthOne()
    {
        NameOne.text = "Vitality";
        DescriptionOne.text = "Increase maximum health by 20 and recover 20 health.";
        IconOne.sprite = HealthIcon;
        FirstBtn.GetComponent<Button>().onClick.AddListener(FillingScore.UpgradeHealth);
    }

    void HealthTwo()
    {
        NameTwo.text = "Vitality";
        DescriptionTwo.text = "Increase maximum health by 20 and recover 20 health.";
        IconTwo.sprite = HealthIcon;
        SecondBtn.GetComponent<Button>().onClick.AddListener(FillingScore.UpgradeHealth);
    }

    void HealthThree()
    {
        NameThree.text = "Vitality";
        DescriptionThree.text = "Increase maximum health by 20 and recover 20 health.";
        IconThree.sprite = HealthIcon;
        ThirdBtn.GetComponent<Button>().onClick.AddListener(FillingScore.UpgradeHealth);
    }

    void RapidFireOne()
    {
        NameOne.text = "Rapid Fire";
        DescriptionOne.text = "Increase the player's firing speed by 25%.";
        IconOne.sprite = WeaponsManager.SGun;
        FirstBtn.GetComponent<Button>().onClick.AddListener(FillingScore.UpgradeFireRate);
    }

    void RapidFireTwo()
    {
        NameTwo.text = "Rapid Fire";
        DescriptionTwo.text = "Increase the player's firing speed by 25%.";
        IconTwo.sprite = WeaponsManager.SGun;
        SecondBtn.GetComponent<Button>().onClick.AddListener(FillingScore.UpgradeFireRate);
    }

    void RapidFireThree()
    {
        NameThree.text = "Rapid Fire";
        DescriptionThree.text = "Increase the player's firing speed by 25%.";
        IconThree.sprite = WeaponsManager.SGun;
        ThirdBtn.GetComponent<Button>().onClick.AddListener(FillingScore.UpgradeFireRate);
    }
}
