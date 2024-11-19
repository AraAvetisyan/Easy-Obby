using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
public class Rewarder : MonoBehaviour
{
    public static Rewarder instance;
    //[SerializeField] string RewardForGold = "GetGold";
    [SerializeField] string AppForDiamond1 = "AppForDiamond1";
    [SerializeField] string AppForDiamond2 = "AppForDiamond2";
    [SerializeField] string AppForDiamond3 = "AppForDiamond3";
    [SerializeField] string AppForDiamond4 = "AppForDiamond4";
    [SerializeField] string AppForDiamond5 = "AppForDiamond5";

    [SerializeField] string AppForCoin1 = "AppForCoin1";
    [SerializeField] string AppForCoin2 = "AppForCoin2";
    [SerializeField] string AppForCoin3 = "AppForCoin3";
    [SerializeField] string AppForCoin4 = "AppForCoin4";
    [SerializeField] string AppForCoin5 = "AppForCoin5";

    [SerializeField] string AppForDiamondAndCoin = "AppForDiamondAndCoin";



    [SerializeField] string DoubleJump = "DoubleJump";

    [SerializeField] string AccessoryReward10 = "AccessoryReward10";
    [SerializeField] string CapReward4 = "CapReward4";
    // public int RewardForGoldGold = 50;
    public int PurchaseForDiamond_Diamond1 = 10;
    public int PurchaseForDiamond_Diamond2 = 20;
    public int PurchaseForDiamond_Diamond3 = 30;
    public int PurchaseForDiamond_Diamond4 = 40;
    public int PurchaseForDiamond_Diamond5 = 50;

    public int PurchaseForCoin_Coin1 = 100;
    public int PurchaseForCoin_Coin2 = 500;
    public int PurchaseForCoin_Coin3 = 1000;
    public int PurchaseForCoin_Coin4 = 2500;
    public int PurchaseForCoin_Coin5 = 5000;

    public int PurchaseForDiamondAndCoin_DiamondAndCoin = 5000;
   // public Action RewardShowed;
    Dictionary<string, int> OperationNameAndReward = new();
    public static Action<bool> ChangeDiamond;
    public static Action<bool> ChangeCoin;
    private void Awake()
    {
      //  OperationNameAndReward.Add(RewardForGold, RewardForGoldGold);
        OperationNameAndReward.Add(AppForDiamond1, PurchaseForDiamond_Diamond1);
        OperationNameAndReward.Add(AppForDiamond2, PurchaseForDiamond_Diamond2);
        OperationNameAndReward.Add(AppForDiamond3, PurchaseForDiamond_Diamond3);
        OperationNameAndReward.Add(AppForDiamond4, PurchaseForDiamond_Diamond4);
        OperationNameAndReward.Add(AppForDiamond5, PurchaseForDiamond_Diamond5);

        OperationNameAndReward.Add(AppForCoin1, PurchaseForCoin_Coin1);
        OperationNameAndReward.Add(AppForCoin2, PurchaseForCoin_Coin2);
        OperationNameAndReward.Add(AppForCoin3, PurchaseForCoin_Coin3);
        OperationNameAndReward.Add(AppForCoin4, PurchaseForCoin_Coin4);
        OperationNameAndReward.Add(AppForCoin5, PurchaseForCoin_Coin5);

        OperationNameAndReward.Add(AppForDiamondAndCoin, PurchaseForDiamondAndCoin_DiamondAndCoin);

        OperationNameAndReward.Add(DoubleJump, 0);
        OperationNameAndReward.Add(AccessoryReward10, 0);
        OperationNameAndReward.Add(CapReward4, 0);
        instance = this;
    }
    void Start()
    {
       // Geekplay.Instance.SubscribeOnReward(RewardForGold, GetGoldReward);
      //  Geekplay.Instance.SubscribeOnPurchase(AppForDiamond1, GetDiamondPur1);
       // Geekplay.Instance.SubscribeOnPurchase(AppForDiamond2, GetDiamondPur2);
       // Geekplay.Instance.SubscribeOnPurchase(AppForDiamond3, GetDiamondPur3);
      //  Geekplay.Instance.SubscribeOnPurchase(AppForDiamond4, GetDiamondPur4);
      //  Geekplay.Instance.SubscribeOnPurchase(AppForDiamond5, GetDiamondPur5);

      //  Geekplay.Instance.SubscribeOnPurchase(AppForCoin1, GetCoinPur1);
     //   Geekplay.Instance.SubscribeOnPurchase(AppForCoin2, GetCoinPur2);
     //   Geekplay.Instance.SubscribeOnPurchase(AppForCoin3, GetCoinPur3);
     //   Geekplay.Instance.SubscribeOnPurchase(AppForCoin4, GetCoinPur4);
    //    Geekplay.Instance.SubscribeOnPurchase(AppForCoin5, GetCoinPur5);

     //   Geekplay.Instance.SubscribeOnPurchase(AppForDiamondAndCoin, GetDiamondAndCoin);

        Geekplay.Instance.SubscribeOnReward(DoubleJump, GetDoubleJump);
        Geekplay.Instance.SubscribeOnReward(AccessoryReward10, GetAccessoryReward10);
        Geekplay.Instance.SubscribeOnReward(CapReward4, GetCapReward4);
    }
    public int GetDiamondCountByName(string Name)
    {
        try
        {
            return OperationNameAndReward[Name];
        }
        catch
        {
            Debug.Log("Õ≈¬≈–ÕŒ≈ »Ãﬂ ƒÀﬂ PURCHASE");
            return -1;
        }
    }

    //private void GetGoldReward()
    //{
    //    Geekplay.Instance.PlayerData.Coins += RewardForGoldGold;
    //    RewardShowed?.Invoke();
    //}
    public void GetDiamondPur1()
    {
        Geekplay.Instance.PlayerData.Diamond += PurchaseForDiamond_Diamond1;
        ChangeDiamond?.Invoke(true);
       // Geekplay.Instance.PlayerData.DonatCount += PurchaseForGoldGold1;
       //  Geekplay.Instance.Leaderboard("Donat", Geekplay.Instance.PlayerData.DonatCount);
        Geekplay.Instance.Save();
    }
    public void GetDiamondPur2()
    {
        Geekplay.Instance.PlayerData.Diamond += PurchaseForDiamond_Diamond2;
        ChangeDiamond?.Invoke(true);
        //  Geekplay.Instance.PlayerData.DonatCount += PurchaseForGoldGold2;
        //  Geekplay.Instance.Leaderboard("Donat", Geekplay.Instance.PlayerData.DonatCount);
        Geekplay.Instance.Save();
    }
    public void GetDiamondPur3()
    {
        Geekplay.Instance.PlayerData.Diamond += PurchaseForDiamond_Diamond3;
        ChangeDiamond?.Invoke(true);
        //    Geekplay.Instance.PlayerData.DonatCount += PurchaseForGoldGold3;
        //   Geekplay.Instance.Leaderboard("Donat", Geekplay.Instance.PlayerData.DonatCount);
        Geekplay.Instance.Save();
    }
    public void GetDiamondPur4()
    {
        Geekplay.Instance.PlayerData.Diamond += PurchaseForDiamond_Diamond4;
        ChangeDiamond?.Invoke(true);
        // Geekplay.Instance.PlayerData.DonatCount += PurchaseForGoldGold4;
        //  Geekplay.Instance.Leaderboard("Donat", Geekplay.Instance.PlayerData.DonatCount);
        Geekplay.Instance.Save();
    }
    public void GetDiamondPur5()
    {
        Geekplay.Instance.PlayerData.Diamond += PurchaseForDiamond_Diamond5;
        ChangeDiamond?.Invoke(true);
        //  Geekplay.Instance.PlayerData.DonatCount += PurchaseForGoldGold5;
        //  Geekplay.Instance.Leaderboard("Donat", Geekplay.Instance.PlayerData.DonatCount);
        Geekplay.Instance.Save();
    }

    public void GetCoinPur1()
    {
        Geekplay.Instance.PlayerData.Coins += PurchaseForCoin_Coin1;
        ChangeCoin?.Invoke(true);
        Geekplay.Instance.Save();
    }
    public void GetCoinPur2()
    {
        Geekplay.Instance.PlayerData.Coins += PurchaseForCoin_Coin2;
        ChangeCoin?.Invoke(true);
        Geekplay.Instance.Save();
    }
    public void GetCoinPur3()
    {
        Geekplay.Instance.PlayerData.Coins += PurchaseForCoin_Coin3;
        ChangeCoin?.Invoke(true);
        Geekplay.Instance.Save();
    }
    public void GetCoinPur4()
    {
        Geekplay.Instance.PlayerData.Coins += PurchaseForCoin_Coin4;
        ChangeCoin?.Invoke(true);
        Geekplay.Instance.Save();
    }
    public void GetCoinPur5()
    {
        Geekplay.Instance.PlayerData.Coins += PurchaseForCoin_Coin5;
        ChangeCoin?.Invoke(true);
        Geekplay.Instance.Save();
    }
    public void GetDiamondAndCoin()
    {
        Geekplay.Instance.PlayerData.Coins += PurchaseForCoin_Coin5;
        Geekplay.Instance.PlayerData.Diamond += PurchaseForDiamond_Diamond5;
        ChangeDiamond?.Invoke(true);
        ChangeCoin?.Invoke(true);
        Geekplay.Instance.Save();
    }
    private void GetDoubleJump()
    {
        Teleport.Instance.DoubleJumpReward();
    }
    private void GetAccessoryReward10()
    {
        SkinShop.Instance.AccessoryReward10();
    }
    private void GetCapReward4()
    {
        SkinShop.Instance.CapReward4();
    }
}