using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class AppRewardCell : MonoBehaviour
{
    public string PurName;
    public Button RewardDiamondButton;
  

    private void InAppOperation()
    {
        Geekplay.Instance.ShowRewardedAd("DoubleJump");
    }
}
