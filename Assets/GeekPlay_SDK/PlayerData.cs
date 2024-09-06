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




    public int RunningMapIndex;

    public int[] RunningSaveProgressLevels;
    public int[] RunningSaveProgressMenuLevels;
    public float[] RunningFillAmountLevels;
    public float[] BestRunningMapMinutesLevels;
    public float[] BestRunningMapSecondsLevels;
    public float[] CurrentRunningMapMinutesLevels;
    public float[] CurrentRunningMapSecondsLevels;


    public int BicycleMapIndex;

    public int[] BicycleSaveProgressLevels;
    public int[] BicycleSaveProgressMenuLevels;
    public float[] BicycleFillAmountLevels;
    public float[] BestBicycleMapMinutesLevels;
    public float[] BestBicycleMapSecondsLevels;
    public float[] CurrentBicycleMapMinutesLevels;
    public float[] CurrentBicycleMapSecondsLevels;



    public int CarMapIndex;

    public int[] CarSaveProgressLevels;
    public int[] CarSaveProgressMenuLevels;
    public float[] CarFillAmountLevels;
    public float[] BestCarMapMinutesLevels;
    public float[] BestCarMapSecondsLevels;
    public float[] CurrentCarMapMinutesLevels;
    public float[] CurrentCarMapSecondsLevels;


   
}