using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData
{

    /////InApps//////
    public string lastBuy;

    public int Coins;
    public int Diamond;
    public int IsFirstTry;

    public int MapIndex;

    public int[] SaveProgressLevels;
    public int[] SaveProgressMenuLevels;
    public float[] FillAmountLevels;
    public float[] BestMapMinutesLevels;
    public float[] BestMapSecondsLevels;
    public float[] CurrentMapMinutesLevels;
    public float[] CurrentMapSecondsLevels;
}