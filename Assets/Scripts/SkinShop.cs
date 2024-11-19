using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SkinShop : MonoBehaviour
{
    public static SkinShop Instance;
    [SerializeField] private GameObject playerObject;
    [Header("UI")]

    [SerializeField] private GameObject selectHead;
    [SerializeField] private GameObject selectFace;
    [SerializeField] private GameObject selectBody;
    [SerializeField] private GameObject selectLeg;
    [SerializeField] private GameObject selectFoot;
    [SerializeField] private GameObject selectCap;
    [SerializeField] private GameObject selectAccessory;
    [SerializeField] private bool isHead;
    [SerializeField] private bool isFace;
    [SerializeField] private bool isBody;
    [SerializeField] private bool isLeg;
    [SerializeField] private bool isFoot;
    [SerializeField] private bool isCap;
    [SerializeField] private bool isAccessory;
    [SerializeField] private Button previosPageButton;
    [SerializeField] private Button nextiosPageButton;
    [SerializeField] private TextMeshProUGUI selectedPageText;
    [SerializeField] private GameObject pageOneMaterials;
    [SerializeField] private GameObject pageTwoMaterials;
    [SerializeField] private GameObject pageOneCaps;
    [SerializeField] private GameObject pageTwoCaps;
    [SerializeField] private GameObject pageOneAccessories;
    [SerializeField] private GameObject pageOneFace;
    [SerializeField] private GameObject pageTwoFace;
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private TextMeshProUGUI diamondText;


    [Header("Buy/Equip")]

    [SerializeField] private TextMeshProUGUI buyEquipText;
    [SerializeField] private Button buyEquipButton;
    [SerializeField] private int[] prices;

    [Header("Materials")]

    [SerializeField] private GameObject[] materialSelects;
    [SerializeField] private Renderer renderer;
    [SerializeField] private Material[] meshMats;
    [SerializeField] private Material[] materials;

    [Header("Face")]
    [SerializeField] private GameObject[] faceSelects;
    [SerializeField] private int[] facePrices;
    [SerializeField] private GameObject[] faceObjects;

    [Header("Cap")]
    [SerializeField] private GameObject[] capSelects;
    [SerializeField] private int[] capPrices;
    [SerializeField] private GameObject[] capObjects;
    [SerializeField] private string[] capRewardNames;

    [Header("Accessory")]
    [SerializeField] private GameObject[] accessorySelects;
    [SerializeField] private GameObject[] accessoryObjects;
    [SerializeField] private int[] accessoryPrices;
    [SerializeField] private string[] accessoriRewardNames;

    [Header("Valute")]
    [SerializeField] private bool byCoin;
    [SerializeField] private bool byDiamond;
    [SerializeField] private bool byReward;
    [SerializeField] private GameObject coinIcone;
    [SerializeField] private GameObject diamondIcone;
    [SerializeField] private GameObject rewardIcone;

    void Awake()
    {
        Instance = this;
        meshMats = renderer.materials;
        StartShop();

        PutOnItems();
    }
    
    private void Update()
    {
        playerObject.transform.Rotate(0, 25 * Time.deltaTime, 0);
    }

    public void PutOnItems()
    {
        for(int i = 0; i < materials.Length; i++)
        {
            if (Geekplay.Instance.PlayerData.HeadEquiped[i])
            {
                meshMats[0] = materials[i];
                meshMats[4] = materials[i];
                renderer.materials = meshMats;
            }
            if (Geekplay.Instance.PlayerData.BodyBoght[i])
            {
                meshMats[1] = materials[i];
                renderer.materials = meshMats;
            }
            if (Geekplay.Instance.PlayerData.LegEquiped[i])
            {
                meshMats[2] = materials[i];
                renderer.materials = meshMats;
            }
            if (Geekplay.Instance.PlayerData.FootEquiped[i])
            {
                meshMats[3] = materials[i];
                renderer.materials = meshMats;
            }
        }
        for (int i = 0; i < capObjects.Length; i++)
        {
            capObjects[i].SetActive(false);
            if (Geekplay.Instance.PlayerData.CapEquiped[i])
            {
                capObjects[i].SetActive(true);
            }
        }
        for (int i = 0; i < accessoryObjects.Length; i++)
        {
            accessoryObjects[i].SetActive(false);
            if (Geekplay.Instance.PlayerData.AccessoryEquiped[i])
            {
                accessoryObjects[i].SetActive(true);
            }
        }
        for(int i = 0; i < faceObjects.Length; i++)
        {
            faceObjects[i].SetActive(false);
            if (Geekplay.Instance.PlayerData.FaceEquiped[i])
            {
                faceObjects[i].SetActive(true);
            }
        }
    }

    public void StartShop()
    {
        isHead = true;
        isFace = false;
        isBody = false;
        isLeg = false;
        isFoot = false;
        isCap = false;
        isAccessory = false;

        for (int i = 0; i < materialSelects.Length; i++)
        {
            materialSelects[i].SetActive(false);
            if (Geekplay.Instance.PlayerData.HeadEquiped[i])
            {
                materialSelects[i].SetActive(true);
            }
        }

        selectHead.SetActive(true);
        selectFace.SetActive(false);
        selectBody.SetActive(false);
        selectLeg.SetActive(false);
        selectFoot.SetActive(false);
        selectCap.SetActive(false);
        selectAccessory.SetActive(false);

        previosPageButton.interactable = false;
        nextiosPageButton.interactable = true;

        selectedPageText.text = "1/2";

        pageOneMaterials.SetActive(true);
        pageTwoMaterials.SetActive(false);
        pageOneFace.SetActive(false);
        pageTwoFace.SetActive(false);
        pageOneCaps.SetActive(false);
        pageTwoCaps.SetActive(false);
        pageOneAccessories.SetActive(false);
    }

    public void PressedCatecoryButton(int index)
    {
        buyEquipButton.gameObject.SetActive(false);
        if(index == 0)
        {
            //head
            isHead = true;
            isFace = false;
            isBody = false;
            isLeg = false;
            isFoot = false;
            isCap = false;
            isAccessory = false;

            for (int i = 0; i < materialSelects.Length; i++)
            {
                materialSelects[i].SetActive(false);
                if (Geekplay.Instance.PlayerData.HeadEquiped[i])
                {
                    materialSelects[i].SetActive(true);
                }
            }

            selectHead.SetActive(true);
            selectFace.SetActive(false);
            selectBody.SetActive(false);
            selectLeg.SetActive(false);
            selectFoot.SetActive(false);
            selectCap.SetActive(false);
            selectAccessory.SetActive(false);

            previosPageButton.interactable = false;
            nextiosPageButton.interactable = true;

            selectedPageText.text = "1/2";

            pageOneMaterials.SetActive(true);
            pageTwoMaterials.SetActive(false);
            pageOneFace.SetActive(false);
            pageTwoFace.SetActive(false);
            pageOneCaps.SetActive(false);
            pageTwoCaps.SetActive(false);
            pageOneAccessories.SetActive(false);
        }
        else if(index == 1)
        {
            //body
            isHead = false;
            isFace = false;
            isBody = true;
            isLeg = false;
            isFoot = false;
            isCap = false;
            isAccessory = false;

            for (int i = 0; i < materialSelects.Length; i++)
            {
                materialSelects[i].SetActive(false);
                if (Geekplay.Instance.PlayerData.BodyEquiped[i])
                {
                    materialSelects[i].SetActive(true);
                }
            }

            selectHead.SetActive(false);
            selectFace.SetActive(false);
            selectBody.SetActive(true);
            selectLeg.SetActive(false);
            selectFoot.SetActive(false);
            selectCap.SetActive(false);
            selectAccessory.SetActive(false);

            previosPageButton.interactable = false;
            nextiosPageButton.interactable = true;

            selectedPageText.text = "1/2";

            pageOneMaterials.SetActive(true);
            pageTwoMaterials.SetActive(false);
            pageOneFace.SetActive(false);
            pageTwoFace.SetActive(false);
            pageOneCaps.SetActive(false);
            pageTwoCaps.SetActive(false);
            pageOneAccessories.SetActive(false);
        }
        else if(index == 2)
        {
            //leg
            isHead = false;
            isFace = false;
            isBody = false;
            isLeg = true;
            isFoot = false;
            isCap = false;
            isAccessory = false;

            for (int i = 0; i < materialSelects.Length; i++)
            {
                materialSelects[i].SetActive(false);
                if (Geekplay.Instance.PlayerData.LegEquiped[i])
                {
                    materialSelects[i].SetActive(true);
                }
            }

            selectHead.SetActive(false);
            selectFace.SetActive(false);
            selectBody.SetActive(false);
            selectLeg.SetActive(true);
            selectFoot.SetActive(false);
            selectCap.SetActive(false);
            selectAccessory.SetActive(false);

            previosPageButton.interactable = false;
            nextiosPageButton.interactable = true;

            selectedPageText.text = "1/2";

            pageOneMaterials.SetActive(true);
            pageTwoMaterials.SetActive(false);
            pageOneFace.SetActive(false);
            pageTwoFace.SetActive(false);
            pageOneCaps.SetActive(false);
            pageTwoCaps.SetActive(false);
            pageOneAccessories.SetActive(false);
        }
        else if(index == 3)
        {
            //foot
            isHead = false;
            isFace = false;
            isBody = false;
            isLeg = false;
            isFoot = true;
            isCap = false;
            isAccessory = false;


            for (int i = 0; i < materialSelects.Length; i++)
            {
                materialSelects[i].SetActive(false);
                if (Geekplay.Instance.PlayerData.FootEquiped[i])
                {
                    materialSelects[i].SetActive(true);
                }
            }

            selectHead.SetActive(false);
            selectFace.SetActive(false);
            selectBody.SetActive(false);
            selectLeg.SetActive(false);
            selectFoot.SetActive(true);
            selectCap.SetActive(false);
            selectAccessory.SetActive(false);

            previosPageButton.interactable = false;
            nextiosPageButton.interactable = true;

            selectedPageText.text = "1/2";

            pageOneMaterials.SetActive(true);
            pageTwoMaterials.SetActive(false);
            pageOneFace.SetActive(false);
            pageTwoFace.SetActive(false);
            pageOneCaps.SetActive(false);
            pageTwoCaps.SetActive(false);
            pageOneAccessories.SetActive(false);
        }
        else if (index == 4)
        {
            //cap
            isHead = false;
            isFace = false;
            isBody = false;
            isLeg = false;
            isFoot = false;
            isCap = true;
            isAccessory = false;


            for (int i = 0; i < capSelects.Length; i++)
            {
                capSelects[i].SetActive(false);
                if (Geekplay.Instance.PlayerData.CapEquiped[i])
                {
                    capSelects[i].SetActive(true);
                }
            }

            selectHead.SetActive(false);
            selectFace.SetActive(false);
            selectBody.SetActive(false);
            selectLeg.SetActive(false);
            selectFoot.SetActive(false);
            selectCap.SetActive(true);
            selectAccessory.SetActive(false);

            previosPageButton.interactable = false;
            nextiosPageButton.interactable = true;

            selectedPageText.text = "1/2";

            pageOneMaterials.SetActive(false);
            pageTwoMaterials.SetActive(false);
            pageOneFace.SetActive(false);
            pageTwoFace.SetActive(false);
            pageOneCaps.SetActive(true);
            pageTwoCaps.SetActive(false);
            pageOneAccessories.SetActive(false);
        }
        else if (index == 5)
        {
            //accessory
            isHead = false;
            isFace = false;
            isBody = false;
            isLeg = false;
            isFoot = false;
            isCap = false;
            isAccessory = true;

            for (int i = 0; i < accessorySelects.Length; i++)
            {
                accessorySelects[i].SetActive(false);
                if (Geekplay.Instance.PlayerData.AccessoryEquiped[i])
                {
                    accessorySelects[i].SetActive(true);
                }
            }

            selectHead.SetActive(false);
            selectFace.SetActive(false);
            selectBody.SetActive(false);
            selectLeg.SetActive(false);
            selectFoot.SetActive(false);
            selectCap.SetActive(false);
            selectAccessory.SetActive(true);

            previosPageButton.interactable = false;
            nextiosPageButton.interactable = false;

            selectedPageText.text = "1/1";

            pageOneMaterials.SetActive(false);
            pageTwoMaterials.SetActive(false);
            pageOneFace.SetActive(false);
            pageTwoFace.SetActive(false);
            pageOneCaps.SetActive(false);
            pageTwoCaps.SetActive(false);
            pageOneAccessories.SetActive(true);

        }
        else if (index == 6)
        {
            //face
            isHead = false;
            isFace = true;
            isBody = false;
            isLeg = false;
            isFoot = false;
            isCap = false;
            isAccessory = false;

            for (int i = 0; i < faceSelects.Length; i++)
            {
                faceSelects[i].SetActive(false);
                if (Geekplay.Instance.PlayerData.FaceEquiped[i])
                {
                    faceSelects[i].SetActive(true);
                }
            }

            selectHead.SetActive(false);
            selectFace.SetActive(true);
            selectBody.SetActive(false);
            selectLeg.SetActive(false);
            selectFoot.SetActive(false);
            selectCap.SetActive(false);
            selectAccessory.SetActive(false);


            previosPageButton.interactable = false;
            nextiosPageButton.interactable = true;

            selectedPageText.text = "1/2";

            pageOneMaterials.SetActive(false);
            pageTwoMaterials.SetActive(false);
            pageOneFace.SetActive(true);
            pageTwoFace.SetActive(false);
            pageOneCaps.SetActive(false);
            pageTwoCaps.SetActive(false);
            pageOneAccessories.SetActive(false);

        }
        PutOnItems();
    }

    public void PressedNextPreviosButton(int index)
    {
        if (isHead || isBody || isLeg || isFoot)
        {
            if (index == 1)
            {
                pageOneMaterials.SetActive(true);
                pageTwoMaterials.SetActive(false);
                selectedPageText.text = "1/2";
                previosPageButton.interactable = false;
                nextiosPageButton.interactable = true;
            }
            else if (index == 2)
            {
                pageOneMaterials.SetActive(false);
                pageTwoMaterials.SetActive(true);
                selectedPageText.text = "2/2";
                previosPageButton.interactable = true;
                nextiosPageButton.interactable = false;
            }
        }
        else if (isCap)
        {
            if (index == 1)
            {
                pageOneCaps.SetActive(true);
                pageTwoCaps.SetActive(false);
                selectedPageText.text = "1/2";
                previosPageButton.interactable = false;
                nextiosPageButton.interactable = true;
            }
            else if (index == 2)
            {
                pageOneCaps.SetActive(false);
                pageTwoCaps.SetActive(true);
                selectedPageText.text = "2/2";
                previosPageButton.interactable = true;
                nextiosPageButton.interactable = false;
            }
        }
        else if (isFace)
        {
            if (index == 1)
            {
                pageOneFace.SetActive(true);
                pageTwoFace.SetActive(false);
                selectedPageText.text = "1/2";
                previosPageButton.interactable = false;
                nextiosPageButton.interactable = true;
            }
            else if (index == 2)
            {
                pageOneFace.SetActive(false);
                pageTwoFace.SetActive(true);
                selectedPageText.text = "2/2";
                previosPageButton.interactable = true;
                nextiosPageButton.interactable = false;
            }
        }
    }
    public void PressedFaceButton(int index)
    {
        diamondIcone.SetActive(false);
        rewardIcone.SetActive(false);

        for (int i = 0; i < faceSelects.Length; i++)
        {
            faceSelects[i].SetActive(false);
        }
        faceSelects[index].SetActive(true);
        for (int i = 0; i < faceObjects.Length; i++)
        {
            faceObjects[i].SetActive(false);
        }
        faceObjects[index].SetActive(true);
        buyEquipButton.gameObject.SetActive(true);

        if (Geekplay.Instance.PlayerData.FaceEquiped[index])
        {
            buyEquipButton.gameObject.SetActive(false);
        }
        if (Geekplay.Instance.PlayerData.FaceBoght[index] == false)
        {
            if (buyEquipButton.interactable == false)
            {
                buyEquipButton.interactable = true;
            }
            if (Geekplay.Instance.PlayerData.Coins < facePrices[index])
            {
                buyEquipButton.interactable = false;
            }
            buyEquipText.text = facePrices[index].ToString();
            coinIcone.SetActive(true);
            diamondIcone.SetActive(false);
            rewardIcone.SetActive(false);


            buyEquipButton.onClick.RemoveAllListeners();
            buyEquipButton.onClick.AddListener(() => BuyFaceClicked(facePrices[index], index));
        }

        if (Geekplay.Instance.PlayerData.FaceBoght[index] == true)
        {
            coinIcone.SetActive(false);
            diamondIcone.SetActive(false);
            rewardIcone.SetActive(false);
            if (buyEquipButton.interactable == false)
            {
                buyEquipButton.interactable = true;
            }
            if (Geekplay.Instance.PlayerData.FaceEquiped[index] == true)
            {
                buyEquipButton.interactable = false;
            }
            if (Geekplay.Instance.language == "en")
            {
                buyEquipText.text = "Equip";
            }
            else if (Geekplay.Instance.language == "ru")
            {
                buyEquipText.text = "Надеть";
            }
            else if (Geekplay.Instance.language == "es")
            {
                buyEquipText.text = "Ponte";
            }
            else if (Geekplay.Instance.language == "tr")
            {
                buyEquipText.text = "Giyin";
            }
            else if (Geekplay.Instance.language == "de")
            {
                buyEquipText.text = "Anlegen";
            }
            else if (Geekplay.Instance.language == "ar")
            {
                buyEquipText.text = "ارتدِ";
            }
            buyEquipButton.onClick.RemoveAllListeners();
            buyEquipButton.onClick.AddListener(() => EquipFaceClicked(index));
        }
    }
    public void BuyFaceClicked(int price, int index)
    {
        coinIcone.SetActive(false);
        diamondIcone.SetActive(false);
        rewardIcone.SetActive(false);

        if (Geekplay.Instance.PlayerData.Coins >= price)
        {
            coinIcone.SetActive(false);
            diamondIcone.SetActive(false);
            rewardIcone.SetActive(false);
            Geekplay.Instance.PlayerData.FaceBoght[index] = true;
            Geekplay.Instance.PlayerData.Coins -= price;
            coinsText.text = Geekplay.Instance.PlayerData.Coins.ToString();
            if (Geekplay.Instance.language == "en")
            {
                buyEquipText.text = "Equip";
            }
            else if (Geekplay.Instance.language == "ru")
            {
                buyEquipText.text = "Надеть";
            }
            else if (Geekplay.Instance.language == "es")
            {
                buyEquipText.text = "Ponte";
            }
            else if (Geekplay.Instance.language == "tr")
            {
                buyEquipText.text = "Giyin";
            }
            else if (Geekplay.Instance.language == "de")
            {
                buyEquipText.text = "Anlegen";
            }
            else if (Geekplay.Instance.language == "ar")
            {
                buyEquipText.text = "ارتدِ";
            }
            if (buyEquipButton.interactable == false)
            {
                buyEquipButton.interactable = true;
            }
            coinIcone.SetActive(false);
            buyEquipButton.onClick.RemoveAllListeners();
            buyEquipButton.onClick.AddListener(() => EquipFaceClicked(index));
        }
        Geekplay.Instance.Save();
    }
    public void EquipFaceClicked(int index)
    {
        for (int i = 0; i < Geekplay.Instance.PlayerData.FaceEquiped.Length; i++)
        {
            Geekplay.Instance.PlayerData.FaceEquiped[i] = false;
        }
        Geekplay.Instance.PlayerData.FaceEquiped[index] = true;
        buyEquipButton.interactable = false;

        for (int i = 0; i < faceObjects.Length; i++)
        {
            faceObjects[i].SetActive(false);
        }
        faceObjects[index].SetActive(true);
        Geekplay.Instance.Save();
    }
    public void PressedAccessoryButton(int index)
    {
        
        if (index == 6)
        {
            byCoin = false;
            byDiamond = true;
            byReward = false;
        }
        else if(index == 10)
        {

            byCoin = false;
            byDiamond = false;
            byReward = true;
        }
        else
        {
            byCoin = true;
            byDiamond = false;
            byReward = false;
        }
        for (int i = 0; i < accessorySelects.Length; i++)
        {
            accessorySelects[i].SetActive(false);
        }
        accessorySelects[index].SetActive(true);
        for (int i = 0; i < accessoryObjects.Length; i++)
        {
            accessoryObjects[i].SetActive(false);
        }
        accessoryObjects[index].SetActive(true);
        buyEquipButton.gameObject.SetActive(true);
        if (Geekplay.Instance.PlayerData.AccessoryEquiped[index])
        {
            buyEquipButton.gameObject.SetActive(false);
        }
        if (Geekplay.Instance.PlayerData.AccessoryBoght[index] == false)
        {
            if (buyEquipButton.interactable == false)
            {
                buyEquipButton.interactable = true;
            }
            if (byCoin)
            {
                if (Geekplay.Instance.PlayerData.Coins < accessoryPrices[index])
                {
                    buyEquipButton.interactable = false;
                }
                buyEquipText.text = accessoryPrices[index].ToString();
                coinIcone.SetActive(true);
                diamondIcone.SetActive(false);
                rewardIcone.SetActive(false);
            }
            else if (byDiamond)
            {
                if (Geekplay.Instance.PlayerData.Diamond < accessoryPrices[index])
                {
                    buyEquipButton.interactable = false;
                }
                buyEquipText.text = accessoryPrices[index].ToString();
                coinIcone.SetActive(false);
                diamondIcone.SetActive(true);
                rewardIcone.SetActive(false);
            }
            else if (byReward)
            {
                buyEquipText.text = "AD";
                coinIcone.SetActive(false);
                diamondIcone.SetActive(false);
                rewardIcone.SetActive(true);
            }
            if (!byReward)
            {
                buyEquipButton.onClick.RemoveAllListeners();
                buyEquipButton.onClick.AddListener(() => BuyAccessoryClicked(accessoryPrices[index], index));
            }
            if (byReward)
            {
                buyEquipButton.onClick.RemoveAllListeners();
                buyEquipButton.onClick.AddListener(() => AccessoryRewardClicked(accessoriRewardNames[index]));
            }
        }

        if (Geekplay.Instance.PlayerData.AccessoryBoght[index] == true)
        {
            coinIcone.SetActive(false);
            diamondIcone.SetActive(false);
            rewardIcone.SetActive(false);
            if (buyEquipButton.interactable == false)
            {
                buyEquipButton.interactable = true;
            }
            if (Geekplay.Instance.PlayerData.AccessoryEquiped[index] == true)
            {
                buyEquipButton.interactable = false;
            }
            if (Geekplay.Instance.language == "en")
            {
                buyEquipText.text = "Equip";
            }
            else if (Geekplay.Instance.language == "ru")
            {
                buyEquipText.text = "Надеть";
            }
            else if (Geekplay.Instance.language == "es")
            {
                buyEquipText.text = "Ponte";
            }
            else if (Geekplay.Instance.language == "tr")
            {
                buyEquipText.text = "Giyin";
            }
            else if (Geekplay.Instance.language == "de")
            {
                buyEquipText.text = "Anlegen";
            }
            else if (Geekplay.Instance.language == "ar")
            {
                buyEquipText.text = "ارتدِ";
            }
            buyEquipButton.onClick.RemoveAllListeners();
            buyEquipButton.onClick.AddListener(() => EquipAccessoryClicked(index));
        }
    }
    public void AccessoryReward10()
    {
        coinIcone.SetActive(false);
        diamondIcone.SetActive(false);
        rewardIcone.SetActive(false);
        Geekplay.Instance.PlayerData.AccessoryBoght[10] = true;
        if (Geekplay.Instance.language == "en")
        {
            buyEquipText.text = "Equip";
        }
        else if (Geekplay.Instance.language == "ru")
        {
            buyEquipText.text = "Надеть";
        }
        else if (Geekplay.Instance.language == "es")
        {
            buyEquipText.text = "Ponte";
        }
        else if (Geekplay.Instance.language == "tr")
        {
            buyEquipText.text = "Giyin";
        }
        else if (Geekplay.Instance.language == "de")
        {
            buyEquipText.text = "Anlegen";
        }
        else if (Geekplay.Instance.language == "ar")
        {
            buyEquipText.text = "ارتدِ";
        }
        if (buyEquipButton.interactable == false)
        {
            buyEquipButton.interactable = true;
        }
        buyEquipButton.onClick.RemoveAllListeners();
        buyEquipButton.onClick.AddListener(() => EquipAccessoryClicked(10));
    }
    public void AccessoryRewardClicked(string rewardName)
    {
        Geekplay.Instance.ShowRewardedAd("AccessoryReward10");
    }
    public void BuyAccessoryClicked(int price, int index)
    {
        coinIcone.SetActive(false);
        diamondIcone.SetActive(false);
        rewardIcone.SetActive(false);
        if (byCoin)
        {
            if (Geekplay.Instance.PlayerData.Coins >= price)
            {
                coinIcone.SetActive(false);
                diamondIcone.SetActive(false);
                rewardIcone.SetActive(false);
                Geekplay.Instance.PlayerData.AccessoryBoght[index] = true;
                Geekplay.Instance.PlayerData.Coins -= price;
                coinsText.text = Geekplay.Instance.PlayerData.Coins.ToString();
                if (Geekplay.Instance.language == "en")
                {
                    buyEquipText.text = "Equip";
                }
                else if (Geekplay.Instance.language == "ru")
                {
                    buyEquipText.text = "Надеть";
                }
                else if (Geekplay.Instance.language == "es")
                {
                    buyEquipText.text = "Ponte";
                }
                else if (Geekplay.Instance.language == "tr")
                {
                    buyEquipText.text = "Giyin";
                }
                else if (Geekplay.Instance.language == "de")
                {
                    buyEquipText.text = "Anlegen";
                }
                else if (Geekplay.Instance.language == "ar")
                {
                    buyEquipText.text = "ارتدِ";
                }
                if (buyEquipButton.interactable == false)
                {
                    buyEquipButton.interactable = true;
                }
                buyEquipButton.onClick.RemoveAllListeners();
                buyEquipButton.onClick.AddListener(() => EquipAccessoryClicked(index));
            }
        }
        else if (byDiamond)
        {
            if (Geekplay.Instance.PlayerData.Diamond >= price)
            {
                coinIcone.SetActive(false);
                diamondIcone.SetActive(false);
                rewardIcone.SetActive(false);
                Geekplay.Instance.PlayerData.AccessoryBoght[index] = true;
                Geekplay.Instance.PlayerData.Diamond -= price;
                diamondText.text = Geekplay.Instance.PlayerData.Diamond.ToString();
                if (Geekplay.Instance.language == "en")
                {
                    buyEquipText.text = "Equip";
                }
                else if (Geekplay.Instance.language == "ru")
                {
                    buyEquipText.text = "Надеть";
                }
                else if (Geekplay.Instance.language == "es")
                {
                    buyEquipText.text = "Ponte";
                }
                else if (Geekplay.Instance.language == "tr")
                {
                    buyEquipText.text = "Giyin";
                }
                else if (Geekplay.Instance.language == "de")
                {
                    buyEquipText.text = "Anlegen";
                }
                else if (Geekplay.Instance.language == "ar")
                {
                    buyEquipText.text = "ارتدِ";
                }
                if (buyEquipButton.interactable == false)
                {
                    buyEquipButton.interactable = true;
                }
                buyEquipButton.onClick.RemoveAllListeners();
                buyEquipButton.onClick.AddListener(() => EquipAccessoryClicked(index));
            }
        }
        Geekplay.Instance.Save();
    }
    public void EquipAccessoryClicked(int index)
    {
        for (int i = 0; i < Geekplay.Instance.PlayerData.AccessoryEquiped.Length; i++)
        {
            Geekplay.Instance.PlayerData.AccessoryEquiped[i] = false;
        }
        Geekplay.Instance.PlayerData.AccessoryEquiped[index] = true;
        buyEquipButton.interactable = false;

        for (int i = 0; i < accessoryObjects.Length; i++)
        {
            accessoryObjects[i].SetActive(false);
        }
        accessoryObjects[index].SetActive(true);
        Geekplay.Instance.Save();
    }
    public void PressedCapButton(int index)
    {
       
        if (index == 4)
        {
            byCoin = false;
            byDiamond = false;
            byReward = true;
        }
        else if(index == 22) 
        {
            byCoin = false;
            byDiamond = true;
            byReward = false;
        }
        else
        {
            byCoin = true;
            byDiamond = false;
            byReward = false;
        }
        for (int i = 0; i < capSelects.Length; i++)
        {
            capSelects[i].SetActive(false);
        }
        capSelects[index].SetActive(true);
        for(int i = 0; i < capObjects.Length; i++)
        {
            capObjects[i].SetActive(false);
        }
        capObjects[index].SetActive(true);
        buyEquipButton.gameObject.SetActive(true);
        if (Geekplay.Instance.PlayerData.CapEquiped[index])
        {
            buyEquipButton.gameObject.SetActive(false);
        }
        if (Geekplay.Instance.PlayerData.CapBoght[index] == false)
        {
            if (buyEquipButton.interactable == false)
            {
                buyEquipButton.interactable = true;
            }
            if (byCoin)
            {
                if (Geekplay.Instance.PlayerData.Coins < capPrices[index])
                {
                    buyEquipButton.interactable = false;
                }
                buyEquipText.text = capPrices[index].ToString();
                coinIcone.SetActive(true);
                diamondIcone.SetActive(false);
                rewardIcone.SetActive(false);
            }
            if (byDiamond)
            {
                if (Geekplay.Instance.PlayerData.Diamond < capPrices[index])
                {
                    buyEquipButton.interactable = false;
                }
                buyEquipText.text = capPrices[index].ToString();
                coinIcone.SetActive(false);
                diamondIcone.SetActive(true);
                rewardIcone.SetActive(false);
            }
            else if (byReward)
            {
                buyEquipText.text = "AD";
                coinIcone.SetActive(false);
                diamondIcone.SetActive(false);
                rewardIcone.SetActive(true);
            }
            if (!byReward)
            {
                buyEquipButton.onClick.RemoveAllListeners();
                buyEquipButton.onClick.AddListener(() => BuyCapClicked(capPrices[index], index));
            }
            if (byReward)
            {
                buyEquipButton.onClick.RemoveAllListeners();
                buyEquipButton.onClick.AddListener(() => buyEquipButton.onClick.AddListener(() => CapRewardClicked(capRewardNames[index])));
            }
        }

        if (Geekplay.Instance.PlayerData.CapBoght[index] == true)
        {

            coinIcone.SetActive(false);
            diamondIcone.SetActive(false);
            rewardIcone.SetActive(false);
            if (buyEquipButton.interactable == false)
            {
                buyEquipButton.interactable = true;
            }
            if (Geekplay.Instance.PlayerData.CapEquiped[index] == true)
            {
                buyEquipButton.interactable = false;
            }
            if (Geekplay.Instance.language == "en")
            {
                buyEquipText.text = "Equip";
            }
            else if (Geekplay.Instance.language == "ru")
            {
                buyEquipText.text = "Надеть";
            }
            else if (Geekplay.Instance.language == "es")
            {
                buyEquipText.text = "Ponte";
            }
            else if (Geekplay.Instance.language == "tr")
            {
                buyEquipText.text = "Giyin";
            }
            else if (Geekplay.Instance.language == "de")
            {
                buyEquipText.text = "Anlegen";
            }
            else if (Geekplay.Instance.language == "ar")
            {
                buyEquipText.text = "ارتدِ";
            }
            buyEquipButton.onClick.RemoveAllListeners();
            buyEquipButton.onClick.AddListener(() => EquipCapClicked(index));
        }
    }
    public void CapReward4()
    {
        coinIcone.SetActive(false);
        diamondIcone.SetActive(false);
        rewardIcone.SetActive(false);
        Geekplay.Instance.PlayerData.CapBoght[4] = true;
        if (Geekplay.Instance.language == "en")
        {
            buyEquipText.text = "Equip";
        }
        else if (Geekplay.Instance.language == "ru")
        {
            buyEquipText.text = "Надеть";
        }
        else if (Geekplay.Instance.language == "es")
        {
            buyEquipText.text = "Ponte";
        }
        else if (Geekplay.Instance.language == "tr")
        {
            buyEquipText.text = "Giyin";
        }
        else if (Geekplay.Instance.language == "de")
        {
            buyEquipText.text = "Anlegen";
        }
        else if (Geekplay.Instance.language == "ar")
        {
            buyEquipText.text = "ارتدِ";
        }
        if (buyEquipButton.interactable == false)
        {
            buyEquipButton.interactable = true;
        }
        buyEquipButton.onClick.RemoveAllListeners();
        buyEquipButton.onClick.AddListener(() => EquipCapClicked(4));
    }
    public void CapRewardClicked(string rewardName)
    {
        Geekplay.Instance.ShowRewardedAd("CapReward4");
    }
    public void BuyCapClicked(int price, int index)
    {
        if (byCoin)
        {
            if (Geekplay.Instance.PlayerData.Coins >= price)
            {
                coinIcone.SetActive(false);
                diamondIcone.SetActive(false);
                rewardIcone.SetActive(false);
                Geekplay.Instance.PlayerData.CapBoght[index] = true;
                Geekplay.Instance.PlayerData.Coins -= price;
                coinsText.text = Geekplay.Instance.PlayerData.Coins.ToString();
                if (Geekplay.Instance.language == "en")
                {
                    buyEquipText.text = "Equip";
                }
                else if (Geekplay.Instance.language == "ru")
                {
                    buyEquipText.text = "Надеть";
                }
                else if (Geekplay.Instance.language == "es")
                {
                    buyEquipText.text = "Ponte";
                }
                else if (Geekplay.Instance.language == "tr")
                {
                    buyEquipText.text = "Giyin";
                }
                else if (Geekplay.Instance.language == "de")
                {
                    buyEquipText.text = "Anlegen";
                }
                else if (Geekplay.Instance.language == "ar")
                {
                    buyEquipText.text = "ارتدِ";
                }
                if (buyEquipButton.interactable == false)
                {
                    buyEquipButton.interactable = true;
                }
                buyEquipButton.onClick.RemoveAllListeners();
                buyEquipButton.onClick.AddListener(() => EquipCapClicked(index));
            }
        }
        else if (byDiamond)
        {
            if (Geekplay.Instance.PlayerData.Diamond >= price)
            {
                coinIcone.SetActive(false);
                diamondIcone.SetActive(false);
                rewardIcone.SetActive(false);
                Geekplay.Instance.PlayerData.CapBoght[index] = true;
                Geekplay.Instance.PlayerData.Diamond -= price;
                diamondText.text = Geekplay.Instance.PlayerData.Coins.ToString();
                if (Geekplay.Instance.language == "en")
                {
                    buyEquipText.text = "Equip";
                }
                else if (Geekplay.Instance.language == "ru")
                {
                    buyEquipText.text = "Надеть";
                }
                else if (Geekplay.Instance.language == "es")
                {
                    buyEquipText.text = "Ponte";
                }
                else if (Geekplay.Instance.language == "tr")
                {
                    buyEquipText.text = "Giyin";
                }
                else if (Geekplay.Instance.language == "de")
                {
                    buyEquipText.text = "Anlegen";
                }
                else if (Geekplay.Instance.language == "ar")
                {
                    buyEquipText.text = "ارتدِ";
                }
                if (buyEquipButton.interactable == false)
                {
                    buyEquipButton.interactable = true;
                }
                buyEquipButton.onClick.RemoveAllListeners();
                buyEquipButton.onClick.AddListener(() => EquipCapClicked(index));
            }
        }
        Geekplay.Instance.Save();
    }
    public void EquipCapClicked(int index)
    {
        for (int i = 0; i < Geekplay.Instance.PlayerData.CapEquiped.Length; i++)
        {
            Geekplay.Instance.PlayerData.CapEquiped[i] = false;
        }
        Geekplay.Instance.PlayerData.CapEquiped[index] = true;
        buyEquipButton.interactable = false;

        for (int i = 0; i < capObjects.Length; i++) 
        {
            capObjects[i].SetActive(false);
        }
        capObjects[index].SetActive(true);
        Geekplay.Instance.Save();
    }

    public void PresedMaterialButton(int index)
    {
        buyEquipButton.gameObject.SetActive(true);
        for(int i = 0; i <materialSelects.Length; i++)
        {
            materialSelects[i].SetActive(false);
            materialSelects[index].SetActive(true);
        }
        coinIcone.SetActive(true);
        diamondIcone.SetActive(false);
        rewardIcone.SetActive(false);
        if (isHead)
        {

            buyEquipButton.gameObject.SetActive(true);
            if (Geekplay.Instance.PlayerData.HeadEquiped[index])
            {
                buyEquipButton.gameObject.SetActive(false);
            }
            meshMats[0] = materials[index];
            meshMats[4] = materials[index];
            renderer.materials = meshMats;


            if (Geekplay.Instance.PlayerData.HeadBoght[index] == false)
            {
                if (buyEquipButton.interactable == false)
                {
                    buyEquipButton.interactable = true;
                }
                if (Geekplay.Instance.PlayerData.Coins < prices[index])
                {
                    buyEquipButton.interactable = false;
                }
                buyEquipText.text = prices[index].ToString();
                
                buyEquipButton.onClick.RemoveAllListeners();
                buyEquipButton.onClick.AddListener(() => BuyHeadClicked(prices[index], index));
            }

            if (Geekplay.Instance.PlayerData.HeadBoght[index] == true)
            {

                coinIcone.SetActive(false);
                diamondIcone.SetActive(false);
                rewardIcone.SetActive(false);
                if (buyEquipButton.interactable == false)
                {
                    buyEquipButton.interactable = true;
                }
                if (Geekplay.Instance.PlayerData.HeadEquiped[index] == true)
                {
                    buyEquipButton.interactable = false;
                }
                if (Geekplay.Instance.language == "en")
                {
                    buyEquipText.text = "Equip";
                }
                else if (Geekplay.Instance.language == "ru")
                {
                    buyEquipText.text = "Надеть";
                }
                else if (Geekplay.Instance.language == "es")
                {
                    buyEquipText.text = "Ponte";
                }
                else if (Geekplay.Instance.language == "tr")
                {
                    buyEquipText.text = "Giyin";
                }
                else if (Geekplay.Instance.language == "de")
                {
                    buyEquipText.text = "Anlegen";
                }
                else if (Geekplay.Instance.language == "ar")
                {
                    buyEquipText.text = "ارتدِ";
                }
                buyEquipButton.onClick.RemoveAllListeners();
                buyEquipButton.onClick.AddListener(() => EquipHeadClicked(index));
            }
        }
        else if (isBody)
        {
            buyEquipButton.gameObject.SetActive(true);
            if (Geekplay.Instance.PlayerData.BodyEquiped[index])
            {
                buyEquipButton.gameObject.SetActive(false);
            }
            meshMats[1] = materials[index];
            renderer.materials = meshMats;

            if (Geekplay.Instance.PlayerData.BodyBoght[index] == false)
            {
                if (buyEquipButton.interactable == false)
                {
                    buyEquipButton.interactable = true;
                }
                if (Geekplay.Instance.PlayerData.Coins < prices[index])
                {
                    buyEquipButton.interactable = false;
                }
                buyEquipText.text = prices[index].ToString();

                buyEquipButton.onClick.RemoveAllListeners();
                buyEquipButton.onClick.AddListener(() => BuyBodyClicked(prices[index], index));
            }

            if (Geekplay.Instance.PlayerData.BodyBoght[index] == true)
            {

                coinIcone.SetActive(false);
                diamondIcone.SetActive(false);
                rewardIcone.SetActive(false);
                if (buyEquipButton.interactable == false)
                {
                    buyEquipButton.interactable = true;
                }
                if (Geekplay.Instance.PlayerData.BodyEquiped[index] == true)
                {
                    buyEquipButton.interactable = false;
                }
                if (Geekplay.Instance.language == "en")
                {
                    buyEquipText.text = "Equip";
                }
                else if (Geekplay.Instance.language == "ru")
                {
                    buyEquipText.text = "Надеть";
                }
                else if (Geekplay.Instance.language == "es")
                {
                    buyEquipText.text = "Ponte";
                }
                else if (Geekplay.Instance.language == "tr")
                {
                    buyEquipText.text = "Giyin";
                }
                else if (Geekplay.Instance.language == "de")
                {
                    buyEquipText.text = "Anlegen";
                }
                else if (Geekplay.Instance.language == "ar")
                {
                    buyEquipText.text = "ارتدِ";
                }
                buyEquipButton.onClick.RemoveAllListeners();
                buyEquipButton.onClick.AddListener(() => EquipBodyClicked(index));
            }

        }
        else if (isLeg)
        {
            buyEquipButton.gameObject.SetActive(true);
            if (Geekplay.Instance.PlayerData.LegEquiped[index])
            {
                buyEquipButton.gameObject.SetActive(false);
            }
            meshMats[2] = materials[index];
            renderer.materials = meshMats;


            if (Geekplay.Instance.PlayerData.LegBoght[index] == false)
            {
                if (buyEquipButton.interactable == false)
                {
                    buyEquipButton.interactable = true;
                }
                if (Geekplay.Instance.PlayerData.Coins < prices[index])
                {
                    buyEquipButton.interactable = false;
                }
                buyEquipText.text = prices[index].ToString();

                buyEquipButton.onClick.RemoveAllListeners();
                buyEquipButton.onClick.AddListener(() => BuyLegClicked(prices[index], index));
            }

            if (Geekplay.Instance.PlayerData.LegBoght[index] == true)
            {

                coinIcone.SetActive(false);
                diamondIcone.SetActive(false);
                rewardIcone.SetActive(false);
                if (buyEquipButton.interactable == false)
                {
                    buyEquipButton.interactable = true;
                }
                if (Geekplay.Instance.PlayerData.LegEquiped[index] == true)
                {
                    buyEquipButton.interactable = false;
                }
                if (Geekplay.Instance.language == "en")
                {
                    buyEquipText.text = "Equip";
                }
                else if (Geekplay.Instance.language == "ru")
                {
                    buyEquipText.text = "Надеть";
                }
                else if (Geekplay.Instance.language == "es")
                {
                    buyEquipText.text = "Ponte";
                }
                else if (Geekplay.Instance.language == "tr")
                {
                    buyEquipText.text = "Giyin";
                }
                else if (Geekplay.Instance.language == "de")
                {
                    buyEquipText.text = "Anlegen";
                }
                else if (Geekplay.Instance.language == "ar")
                {
                    buyEquipText.text = "ارتدِ";
                }
                buyEquipButton.onClick.RemoveAllListeners();
                buyEquipButton.onClick.AddListener(() => EquipLegClicked(index));
            }
        }
        else if (isFoot)
        {
            buyEquipButton.gameObject.SetActive(true);
            if (Geekplay.Instance.PlayerData.FootEquiped[index])
            {
                buyEquipButton.gameObject.SetActive(false);
            }
            meshMats[3] = materials[index];
            renderer.materials = meshMats;


            if (Geekplay.Instance.PlayerData.FootBoght[index] == false)
            {
                if (buyEquipButton.interactable == false)
                {
                    buyEquipButton.interactable = true;
                }
                if (Geekplay.Instance.PlayerData.Coins < prices[index])
                {
                    buyEquipButton.interactable = false;
                }
                buyEquipText.text = prices[index].ToString();

                buyEquipButton.onClick.RemoveAllListeners();
                buyEquipButton.onClick.AddListener(() => BuyFootClicked(prices[index], index));
            }

            if (Geekplay.Instance.PlayerData.FootBoght[index] == true)
            {

                coinIcone.SetActive(false);
                diamondIcone.SetActive(false);
                rewardIcone.SetActive(false);
                if (buyEquipButton.interactable == false)
                {
                    buyEquipButton.interactable = true;
                }
                if (Geekplay.Instance.PlayerData.FootEquiped[index] == true)
                {
                    buyEquipButton.interactable = false;
                }
                if (Geekplay.Instance.language == "en")
                {
                    buyEquipText.text = "Equip";
                }
                else if (Geekplay.Instance.language == "ru")
                {
                    buyEquipText.text = "Надеть";
                }
                else if (Geekplay.Instance.language == "es")
                {
                    buyEquipText.text = "Ponte";
                }
                else if (Geekplay.Instance.language == "tr")
                {
                    buyEquipText.text = "Giyin";
                }
                else if (Geekplay.Instance.language == "de")
                {
                    buyEquipText.text = "Anlegen";
                }
                else if (Geekplay.Instance.language == "ar")
                {
                    buyEquipText.text = "ارتدِ";
                }
                buyEquipButton.onClick.RemoveAllListeners();
                buyEquipButton.onClick.AddListener(() => EquipFootClicked(index));
            }
        }
    }

    public void BuyHeadClicked(int price, int index)
    {
        if (Geekplay.Instance.PlayerData.Coins >= price)
        {
            Geekplay.Instance.PlayerData.HeadBoght[index] = true;
            Geekplay.Instance.PlayerData.Coins -= price;
            coinsText.text = Geekplay.Instance.PlayerData.Coins.ToString();
            if (Geekplay.Instance.language == "en")
            {
                buyEquipText.text = "Equip";
            }
            else if (Geekplay.Instance.language == "ru")
            {
                buyEquipText.text = "Надеть";
            }
            else if (Geekplay.Instance.language == "es")
            {
                buyEquipText.text = "Ponte";
            }
            else if (Geekplay.Instance.language == "tr")
            {
                buyEquipText.text = "Giyin";
            }
            else if (Geekplay.Instance.language == "de")
            {
                buyEquipText.text = "Anlegen";
            }
            else if (Geekplay.Instance.language == "ar")
            {
                buyEquipText.text = "ارتدِ";
            }
            if (buyEquipButton.interactable == false)
            {
                buyEquipButton.interactable = true;
            }

            coinIcone.SetActive(false);
            buyEquipButton.onClick.RemoveAllListeners();
            buyEquipButton.onClick.AddListener(() => EquipHeadClicked(index));
        }
        Geekplay.Instance.Save();
    }
    public void EquipHeadClicked(int index)
    {
        for (int i = 0; i < Geekplay.Instance.PlayerData.HeadEquiped.Length; i++)
        {
            Geekplay.Instance.PlayerData.HeadEquiped[i] = false;
        }
        Geekplay.Instance.PlayerData.HeadEquiped[index] = true;
        buyEquipButton.interactable = false;

        meshMats[1] = materials[index];
        renderer.materials = meshMats;
        Geekplay.Instance.Save();
    }

    public void BuyBodyClicked(int price, int index)
    {
        if (Geekplay.Instance.PlayerData.Coins >= price)
        {
            Geekplay.Instance.PlayerData.BodyBoght[index] = true;
            Geekplay.Instance.PlayerData.Coins -= price;
            coinsText.text = Geekplay.Instance.PlayerData.Coins.ToString();
            if (Geekplay.Instance.language == "en")
            {
                buyEquipText.text = "Equip";
            }
            else if (Geekplay.Instance.language == "ru")
            {
                buyEquipText.text = "Надеть";
            }
            else if (Geekplay.Instance.language == "es")
            {
                buyEquipText.text = "Ponte";
            }
            else if (Geekplay.Instance.language == "tr")
            {
                buyEquipText.text = "Giyin";
            }
            else if (Geekplay.Instance.language == "de")
            {
                buyEquipText.text = "Anlegen";
            }
            else if (Geekplay.Instance.language == "ar")
            {
                buyEquipText.text = "ارتدِ";
            }
            if (buyEquipButton.interactable == false)
            {
                buyEquipButton.interactable = true;
            }
            coinIcone.SetActive(false);
            buyEquipButton.onClick.RemoveAllListeners();
            buyEquipButton.onClick.AddListener(() => EquipBodyClicked(index));
        }
        Geekplay.Instance.Save();
    }
    public void EquipBodyClicked(int index)
    {
        for (int i = 0; i < Geekplay.Instance.PlayerData.BodyEquiped.Length; i++)
        {
            Geekplay.Instance.PlayerData.BodyEquiped[i] = false;
        }
        Geekplay.Instance.PlayerData.BodyEquiped[index] = true;
        buyEquipButton.interactable = false;

        meshMats[1] = materials[index];
        renderer.materials = meshMats;
        Geekplay.Instance.Save();
    }

    public void BuyLegClicked(int price, int index)
    {
        if (Geekplay.Instance.PlayerData.Coins >= price)
        {
            Geekplay.Instance.PlayerData.LegBoght[index] = true;
            Geekplay.Instance.PlayerData.Coins -= price;
            coinsText.text = Geekplay.Instance.PlayerData.Coins.ToString();
            if (Geekplay.Instance.language == "en")
            {
                buyEquipText.text = "Equip";
            }
            else if (Geekplay.Instance.language == "ru")
            {
                buyEquipText.text = "Надеть";
            }
            else if (Geekplay.Instance.language == "es")
            {
                buyEquipText.text = "Ponte";
            }
            else if (Geekplay.Instance.language == "tr")
            {
                buyEquipText.text = "Giyin";
            }
            else if (Geekplay.Instance.language == "de")
            {
                buyEquipText.text = "Anlegen";
            }
            else if (Geekplay.Instance.language == "ar")
            {
                buyEquipText.text = "ارتدِ";
            }
            if (buyEquipButton.interactable == false)
            {
                buyEquipButton.interactable = true;
            }
            buyEquipButton.onClick.RemoveAllListeners();
            buyEquipButton.onClick.AddListener(() => EquipLegClicked(index));
        }
        coinIcone.SetActive(false);
        Geekplay.Instance.Save();
    }
    public void EquipLegClicked(int index)
    {
        for (int i = 0; i < Geekplay.Instance.PlayerData.LegEquiped.Length; i++)
        {
            Geekplay.Instance.PlayerData.LegEquiped[i] = false;
        }
        Geekplay.Instance.PlayerData.LegEquiped[index] = true;
        buyEquipButton.interactable = false;

        meshMats[2] = materials[index];
        renderer.materials = meshMats;
        Geekplay.Instance.Save();
    }

    public void BuyFootClicked(int price, int index)
    {
        if (Geekplay.Instance.PlayerData.Coins >= price)
        {
            Geekplay.Instance.PlayerData.FootBoght[index] = true;
            Geekplay.Instance.PlayerData.Coins -= price;
            coinsText.text = Geekplay.Instance.PlayerData.Coins.ToString();
            if (Geekplay.Instance.language == "en")
            {
                buyEquipText.text = "Equip";
            }
            else if (Geekplay.Instance.language == "ru")
            {
                buyEquipText.text = "Надеть";
            }
            else if (Geekplay.Instance.language == "es")
            {
                buyEquipText.text = "Ponte";
            }
            else if (Geekplay.Instance.language == "tr")
            {
                buyEquipText.text = "Giyin";
            }
            else if (Geekplay.Instance.language == "de")
            {
                buyEquipText.text = "Anlegen";
            }
            else if (Geekplay.Instance.language == "ar")
            {
                buyEquipText.text = "ارتدِ";
            }
            if (buyEquipButton.interactable == false)
            {
                buyEquipButton.interactable = true;
            }
            coinIcone.SetActive(false);
            buyEquipButton.onClick.RemoveAllListeners();
            buyEquipButton.onClick.AddListener(() => EquipFootClicked(index));
        }
        Geekplay.Instance.Save();
    }
    public void EquipFootClicked(int index)
    {
        for (int i = 0; i < Geekplay.Instance.PlayerData.FootEquiped.Length; i++)
        {
            Geekplay.Instance.PlayerData.FootEquiped[i] = false;
        }
        Geekplay.Instance.PlayerData.FootEquiped[index] = true;
        buyEquipButton.interactable = false;

        meshMats[3] = materials[index];
        renderer.materials = meshMats;
        Geekplay.Instance.Save();
    }
}
