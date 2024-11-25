﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuLocalisation : MonoBehaviour
{
    public static MainMenuLocalisation Instance;
    [Header("FirstPanel")]
    [SerializeField] private TextMeshProUGUI runTitle;
    [SerializeField] private TextMeshProUGUI bicycleTitle;
    [SerializeField] private TextMeshProUGUI carTitle;

    [Header("RunGamePanel")]
    [SerializeField] private TextMeshProUGUI runLevel1;
    [SerializeField] private TextMeshProUGUI runLevel2;
    [SerializeField] private TextMeshProUGUI runLevel3;
    [SerializeField] private TextMeshProUGUI runLevel4;
    [SerializeField] private TextMeshProUGUI runDifficulty1;
    [SerializeField] private TextMeshProUGUI runDifficulty2;
    [SerializeField] private TextMeshProUGUI runDifficulty3;
    [SerializeField] private TextMeshProUGUI runDifficulty4;
    [SerializeField] private TextMeshProUGUI runRecord1;
    [SerializeField] private TextMeshProUGUI runRecord2;
    [SerializeField] private TextMeshProUGUI runRecord3;
    [SerializeField] private TextMeshProUGUI runRecord4;
    [SerializeField] private TextMeshProUGUI runSoon3;
    [SerializeField] private TextMeshProUGUI runSoon4;

    [Header("BicycleGamePanel")]
    [SerializeField] private TextMeshProUGUI bicycleLevel1;
    [SerializeField] private TextMeshProUGUI bicycleLevel2;
    [SerializeField] private TextMeshProUGUI bicycleLevel3;
    [SerializeField] private TextMeshProUGUI bicycleLevel4;
    [SerializeField] private TextMeshProUGUI bicycleDifficulty1;
    [SerializeField] private TextMeshProUGUI bicycleDifficulty2;
    [SerializeField] private TextMeshProUGUI bicycleDifficulty3;
    [SerializeField] private TextMeshProUGUI bicycleDifficulty4;
    [SerializeField] private TextMeshProUGUI bicycleRecord1;
    [SerializeField] private TextMeshProUGUI bicycleRecord2;
    [SerializeField] private TextMeshProUGUI bicycleRecord3;
    [SerializeField] private TextMeshProUGUI bicycleRecord4;
    [SerializeField] private TextMeshProUGUI bicycleSoon3;
    [SerializeField] private TextMeshProUGUI bicycleSoon4;

    [Header("CarGamePanel")]
    [SerializeField] private TextMeshProUGUI carLevel1;
    [SerializeField] private TextMeshProUGUI carLevel2;
    [SerializeField] private TextMeshProUGUI carLevel3;
    [SerializeField] private TextMeshProUGUI carLevel4;
    [SerializeField] private TextMeshProUGUI carDifficulty1;
    [SerializeField] private TextMeshProUGUI carDifficulty2;
    [SerializeField] private TextMeshProUGUI carDifficulty3;
    [SerializeField] private TextMeshProUGUI carDifficulty4;
    [SerializeField] private TextMeshProUGUI carRecord1;
    [SerializeField] private TextMeshProUGUI carRecord2;
    [SerializeField] private TextMeshProUGUI carRecord3;
    [SerializeField] private TextMeshProUGUI carRecord4;
    [SerializeField] private TextMeshProUGUI carSoon3;
    [SerializeField] private TextMeshProUGUI carSoon4;

    [Header("RunMenu")]
    [SerializeField] private TextMeshProUGUI runNewGame;
    [SerializeField] private TextMeshProUGUI runContinueGame;

    [Header("BicycleMenu")]
    [SerializeField] private TextMeshProUGUI bicycleNewGame;
    [SerializeField] private TextMeshProUGUI bicycleContinueGame;

    [Header("CarMenu")]
    [SerializeField] private TextMeshProUGUI carNewGame;
    [SerializeField] private TextMeshProUGUI carContinueGame;

    [Header("InApp")]
    [SerializeField] private TextMeshProUGUI[] yans;
    [SerializeField] private int[] prices;

    [Header("Shops")]
    [SerializeField] private TextMeshProUGUI moreGold;
    [SerializeField] private TextMeshProUGUI shop;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        if(Geekplay.Instance.language == "en")
        {
            runTitle.text = "Run";
            bicycleTitle.text = "Bicycle";
            carTitle.text = "Car";
            runLevel1.text = "Level 1";
            runLevel2.text = "Level 2";
            runLevel3.text = "Level 3";
            runLevel4.text = "Level 4";
            runDifficulty1.text = "Difficult: ";
            runDifficulty2.text = "Difficult: ";
            runDifficulty3.text = "Difficult: ";
            runDifficulty4.text = "Difficult: ";
            runRecord1.text = "Record";
            runRecord2.text = "Record";
            runRecord3.text = "Record";
            runRecord4.text = "Record";
            runSoon3.text = "! SOON !";
            runSoon4.text = "! SOON !";
            bicycleLevel1.text = "Level 1";
            bicycleLevel2.text = "Level 2";
            bicycleLevel3.text = "Level 3";
            bicycleLevel4.text = "Level 4";
            bicycleDifficulty1.text = "Difficult: ";
            bicycleDifficulty2.text = "Difficult: ";
            bicycleDifficulty3.text = "Difficult: ";
            bicycleDifficulty4.text = "Difficult: ";
            bicycleRecord1.text = "Record";
            bicycleRecord2.text = "Record";
            bicycleRecord3.text = "Record";
            bicycleRecord4.text = "Record";
            bicycleSoon3.text = "! SOON !";
            bicycleSoon4.text = "! SOON !";
            carLevel1.text = "Level 1";
            carLevel2.text = "Level 2";
            carLevel3.text = "Level 3";
            carLevel4.text = "Level 4";
            carDifficulty1.text = "Difficult: ";
            carDifficulty2.text = "Difficult: ";
            carDifficulty3.text = "Difficult: ";
            carDifficulty4.text = "Difficult: ";
            carRecord1.text = "Record";
            carRecord2.text = "Record";
            carRecord3.text = "Record";
            carRecord4.text = "Record";
            carSoon3.text = "! SOON !";
            carSoon4.text = "! SOON !";
            runNewGame.text = "New Game";
            runContinueGame.text = "Continue";
            bicycleNewGame.text = "New Game";
            bicycleContinueGame.text = "Continue";
            carNewGame.text = "New Game";
            carContinueGame.text = "Continue";
            moreGold.text = "More Gold!";
            shop.text = "Shop";
        }
        else if (Geekplay.Instance.language == "ru")
        {
            runTitle.text = "Бег";
            bicycleTitle.text = "Велосипед";
            carTitle.text = "Машина";
            runLevel1.text = "Уровень 1";
            runLevel2.text = "Уровень 2";
            runLevel3.text = "Уровень 3";
            runLevel4.text = "Уровень 4";
            runDifficulty1.text = "Сложность: ";
            runDifficulty2.text = "Сложность: ";
            runDifficulty3.text = "Сложность: ";
            runDifficulty4.text = "Сложность: ";
            runRecord1.text = "Рекорд";
            runRecord2.text = "Рекорд";
            runRecord3.text = "Рекорд";
            runRecord4.text = "Рекорд";
            runSoon3.text = "! СКОРО !";
            runSoon4.text = "! СКОРО !";
            bicycleLevel1.text = "Уровень 1";
            bicycleLevel2.text = "Уровень 2";
            bicycleLevel3.text = "Уровень 3";
            bicycleLevel4.text = "Уровень 4";
            bicycleDifficulty1.text = "Сложность: ";
            bicycleDifficulty2.text = "Сложность: ";
            bicycleDifficulty3.text = "Сложность: ";
            bicycleDifficulty4.text = "Сложность: ";
            bicycleRecord1.text = "Рекорд";
            bicycleRecord2.text = "Рекорд";
            bicycleRecord3.text = "Рекорд";
            bicycleRecord4.text = "Рекорд";
            bicycleSoon3.text = "! СКОРО !";
            bicycleSoon4.text = "! СКОРО !";
            carLevel1.text = "Уровень 1";
            carLevel2.text = "Уровень 2";
            carLevel3.text = "Уровень 3";
            carLevel4.text = "Уровень 4";
            carDifficulty1.text = "Сложность: ";
            carDifficulty2.text = "Сложность: ";
            carDifficulty3.text = "Сложность: ";
            carDifficulty4.text = "Сложность: ";
            carRecord1.text = "Рекорд";
            carRecord2.text = "Рекорд";
            carRecord3.text = "Рекорд";
            carRecord4.text = "Рекорд";
            carSoon3.text = "! СКОРО !";
            carSoon4.text = "! СКОРО !";
            runNewGame.text = "Новая Игра";
            runContinueGame.text = "Продолжить";
            bicycleNewGame.text = "Новая Игра";
            bicycleContinueGame.text = "Продолжить";
            carNewGame.text = "Новая Игра";
            carContinueGame.text = "Продолжить";
            moreGold.text = "Больше золота!";
            shop.text = "Магазин";
        }
        else if (Geekplay.Instance.language == "tr")
        {
            runTitle.text = "Koşmak";
            bicycleTitle.text = "Bisiklet";
            carTitle.text = "Araba";
            runLevel1.text = "Seviye 1";
            runLevel2.text = "Seviye 2";
            runLevel3.text = "Seviye 3";
            runLevel4.text = "Seviye 4";
            runDifficulty1.text = "Zor: ";
            runDifficulty2.text = "Zor: ";
            runDifficulty3.text = "Zor: ";
            runDifficulty4.text = "Zor: ";
            runRecord1.text = "Rekor";
            runRecord2.text = "Rekor";
            runRecord3.text = "Rekor";
            runRecord4.text = "Rekor";
            runSoon3.text = "! YAKINDA !";
            runSoon4.text = "! YAKINDA !";
            bicycleLevel1.text = "Seviye 1";
            bicycleLevel2.text = "Seviye 2";
            bicycleLevel3.text = "Seviye 3";
            bicycleLevel4.text = "Seviye 4";
            bicycleDifficulty1.text = "Zor: ";
            bicycleDifficulty2.text = "Zor: ";
            bicycleDifficulty3.text = "Zor: ";
            bicycleDifficulty4.text = "Zor: ";
            bicycleRecord1.text = "Rekor";
            bicycleRecord2.text = "Rekor";
            bicycleRecord3.text = "Rekor";
            bicycleRecord4.text = "Rekor";
            bicycleSoon3.text = "! YAKINDA !";
            bicycleSoon4.text = "! YAKINDA !";
            carLevel1.text = "Seviye 1";
            carLevel2.text = "Seviye 2";
            carLevel3.text = "Seviye 3";
            carLevel4.text = "Seviye 4";
            carDifficulty1.text = "Zor: ";
            carDifficulty2.text = "Zor: ";
            carDifficulty3.text = "Zor: ";
            carDifficulty4.text = "Zor: ";
            carRecord1.text = "Rekor";
            carRecord2.text = "Rekor";
            carRecord3.text = "Rekor";
            carRecord4.text = "Rekor";
            carSoon3.text = "! YAKINDA !";
            carSoon4.text = "! YAKINDA !";
            runNewGame.text = "Yeni Oyun";
            runContinueGame.text = "Devam et";
            bicycleNewGame.text = "Yeni Oyun";
            bicycleContinueGame.text = "Devam et";
            carNewGame.text = "Yeni Oyun";
            carContinueGame.text = "Devam et";
            moreGold.text = "Daha fazla Altın!";
            shop.text = "Mağaza";
        }
        else if (Geekplay.Instance.language == "es")
        {
            runTitle.text = "Ejecutar";
            bicycleTitle.text = "Bicicleta";
            carTitle.text = "Coche";
            runLevel1.text = "Nivel 1";
            runLevel2.text = "Nivel 2";
            runLevel3.text = "Nivel 3";
            runLevel4.text = "Nivel 4";
            runDifficulty1.text = "Difícil: ";
            runDifficulty2.text = "Difícil: ";
            runDifficulty3.text = "Difícil: ";
            runDifficulty4.text = "Difícil: ";
            runRecord1.text = "Registro";
            runRecord2.text = "Registro";
            runRecord3.text = "Registro";
            runRecord4.text = "Registro";
            runSoon3.text = "! PRONTO !";
            runSoon4.text = "! PRONTO !";
            bicycleLevel1.text = "Nivel 1";
            bicycleLevel2.text = "Nivel 2";
            bicycleLevel3.text = "Nivel 3";
            bicycleLevel4.text = "Nivel 4";
            bicycleDifficulty1.text = "Difícil: ";
            bicycleDifficulty2.text = "Difícil: ";
            bicycleDifficulty3.text = "Difícil: ";
            bicycleDifficulty4.text = "Difícil: ";
            bicycleRecord1.text = "Registro";
            bicycleRecord2.text = "Registro";
            bicycleRecord3.text = "Registro";
            bicycleRecord4.text = "Registro";
            bicycleSoon3.text = "! PRONTO !";
            bicycleSoon4.text = "! PRONTO !";
            carLevel1.text = "Nivel 1";
            carLevel2.text = "Nivel 2";
            carLevel3.text = "Nivel 3";
            carLevel4.text = "Nivel 4";
            carDifficulty1.text = "Difícil: ";
            carDifficulty2.text = "Difícil: ";
            carDifficulty3.text = "Difícil: ";
            carDifficulty4.text = "Difícil: ";
            carRecord1.text = "Registro";
            carRecord2.text = "Registro";
            carRecord3.text = "Registro";
            carRecord4.text = "Registro";
            carSoon3.text = "! PRONTO !";
            carSoon4.text = "! PRONTO !";
            runNewGame.text = "Nuevo juego";
            runContinueGame.text = "Continúe en";
            bicycleNewGame.text = "Nuevo juego";
            bicycleContinueGame.text = "Continúe en";
            carNewGame.text = "Nuevo juego";
            carContinueGame.text = "Continúe en";
            moreGold.text = "¡Más oro!";
            shop.text = "Comercio";
        }
        else if (Geekplay.Instance.language == "de")
        {
            runTitle.text = "Laufen";
            bicycleTitle.text = "Fahrrad";
            carTitle.text = "Wagen";
            runLevel1.text = "Ebene 1";
            runLevel2.text = "Ebene 2";
            runLevel3.text = "Ebene 3";
            runLevel4.text = "Ebene 4";
            runDifficulty1.text = "Schwierig: ";
            runDifficulty2.text = "Schwierig: ";
            runDifficulty3.text = "Schwierig: ";
            runDifficulty4.text = "Schwierig: ";
            runRecord1.text = "Datensatz";
            runRecord2.text = "Datensatz";
            runRecord3.text = "Datensatz";
            runRecord4.text = "Datensatz";
            runSoon3.text = "! SOON !";
            runSoon4.text = "! SOON !";
            bicycleLevel1.text = "Ebene 1";
            bicycleLevel2.text = "Ebene 2";
            bicycleLevel3.text = "Ebene 3";
            bicycleLevel4.text = "Ebene 4";
            bicycleDifficulty1.text = "Schwierig: ";
            bicycleDifficulty2.text = "Schwierig: ";
            bicycleDifficulty3.text = "Schwierig: ";
            bicycleDifficulty4.text = "Schwierig: ";
            bicycleRecord1.text = "Datensatz";
            bicycleRecord2.text = "Datensatz";
            bicycleRecord3.text = "Datensatz";
            bicycleRecord4.text = "Datensatz";
            bicycleSoon3.text = "! SOON !";
            bicycleSoon4.text = "! SOON !";
            carLevel1.text = "Ebene 1";
            carLevel2.text = "Ebene 2";
            carLevel3.text = "Ebene 3";
            carLevel4.text = "Ebene 4";
            carDifficulty1.text = "Schwierig: ";
            carDifficulty2.text = "Schwierig: ";
            carDifficulty3.text = "Schwierig: ";
            carDifficulty4.text = "Schwierig: ";
            carRecord1.text = "Datensatz";
            carRecord2.text = "Datensatz";
            carRecord3.text = "Datensatz";
            carRecord4.text = "Datensatz";
            carSoon3.text = "! SOON !";
            carSoon4.text = "! SOON !";
            runNewGame.text = "Neues Spiel";
            runContinueGame.text = "Weiter";
            bicycleNewGame.text = "Neues Spiel";
            bicycleContinueGame.text = "Weiter";
            carNewGame.text = "Neues Spiel";
            carContinueGame.text = "Weiter";
            moreGold.text = "Mehr Gold!";
            shop.text = "Geschäft";
        }
        else if (Geekplay.Instance.language == "ar")
        {
            runTitle.text = "تشغيل";
            bicycleTitle.text = "دراجة هوائية";
            carTitle.text = "سيارة";
            runLevel1.text = "المستوى 1";
            runLevel2.text = "المستوى 2";
            runLevel3.text = "المستوى 3";
            runLevel4.text = "المستوى 4";
            runDifficulty1.text = "صعب: ";
            runDifficulty2.text = "صعب: ";
            runDifficulty3.text = "صعب: ";
            runDifficulty4.text = "صعب: ";
            runRecord1.text = "السجل";
            runRecord2.text = "السجل";
            runRecord3.text = "السجل";
            runRecord4.text = "السجل";
            runSoon3.text = "! قريباً !";
            runSoon4.text = "! قريباً !";
            bicycleLevel1.text = "المستوى 1";
            bicycleLevel2.text = "المستوى 2";
            bicycleLevel3.text = "المستوى 3";
            bicycleLevel4.text = "المستوى 4";
            bicycleDifficulty1.text = "صعب: ";
            bicycleDifficulty2.text = "صعب: ";
            bicycleDifficulty3.text = "صعب: ";
            bicycleDifficulty4.text = "صعب: ";
            bicycleRecord1.text = "السجل";
            bicycleRecord2.text = "السجل";
            bicycleRecord3.text = "السجل";
            bicycleRecord4.text = "السجل";
            bicycleSoon3.text = "! قريباً !";
            bicycleSoon4.text = "! قريباً !";
            carLevel1.text = "المستوى 1";
            carLevel2.text = "المستوى 2";
            carLevel3.text = "المستوى 3";
            carLevel4.text = "المستوى 4";
            carDifficulty1.text = "صعب: ";
            carDifficulty2.text = "صعب: ";
            carDifficulty3.text = "صعب: ";
            carDifficulty4.text = "صعب: ";
            carRecord1.text = "السجل";
            carRecord2.text = "السجل";
            carRecord3.text = "السجل";
            carRecord4.text = "السجل";
            carSoon3.text = "! قريباً !";
            carSoon4.text = "! قريباً !";
            runNewGame.text = "لعبة جديدة";
            runContinueGame.text = "تابع";
            bicycleNewGame.text = "لعبة جديدة";
            bicycleContinueGame.text = "تابع";
            carNewGame.text = "لعبة جديدة";
            carContinueGame.text = "تابع";
            moreGold.text = "المزيد من الذهب!";
            shop.text = "محل";
        }
    }
    public void ChangeYan()
    {
        for (int i = 0; i < yans.Length; i++)
        {
            yans[i].text = prices[i].ToString() + " " + Geekplay.Instance.YanValueType;
        }
    }
}
