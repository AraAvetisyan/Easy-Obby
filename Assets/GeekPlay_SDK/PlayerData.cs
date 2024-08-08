using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public int Coins { 
        get
        {
            return _coinsDontUse;
        }
        set
        {
            _coinsDontUse = value;
            CoinsChanged?.Invoke(_coinsDontUse);
        }
    }    
    public event Action<int> CoinsChanged;
    public int _coinsDontUse;
    public bool IsFirstPlay;
    public int BuildCount;
    public int DestroyCount;
    public int CurrentSaveSlotLoading;
    public bool IsPlayerMapLoad;
    /////InApps//////
    public string lastBuy;

    public int RunningSaveProgress;
    public int BikeSaveProgress;
    public bool RunningMap;
    public int IsFirstTry;
}