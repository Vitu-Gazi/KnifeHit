using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ChooseKnife : MonoBehaviour
{
    //Скрипит для сейва купленных и выбранных ножей. В данный момент работает не исправно. В скрипте Reg ругается на входной аргумент. Решение пока что не нашел

    public string Name;
    public int Price;
    public bool Bought, Equip;

    public delegate void RegistareKnife(ChooseKnife knife);
    public static event RegistareKnife Registare;

    private void Start()
    {
        TableOfKnife.Reg();
        Bought = System.Convert.ToBoolean(PlayerPrefs.GetString("Name"));
        if (Bought)
        {
            Equip = System.Convert.ToBoolean(PlayerPrefs.GetString(Name + "Equip"));
        }
        Registare(gameObject.GetComponent<ChooseKnife>());
    }

    private void OnMouseDown()
    {
        if (!Bought)
        {
            if (FindObjectOfType<StartLevel>().AppleNumber == Price || FindObjectOfType<StartLevel>().AppleNumber >= Price)
            {
                Bought = true;
                Equip = true;
                TableOfKnife.CheckKnife(GetComponent<ChooseKnife>());
                PlayerPrefs.SetString(Name, "true");
                PlayerPrefs.SetString(Name + "Equip", "true");
            }
        }
        else
        {
            Equip = true;
            PlayerPrefs.SetString(Name + "Equip", "true");
            TableOfKnife.CheckKnife(GetComponent<ChooseKnife>());
        }
    }
}

public class TableOfKnife
{
    public static List<ChooseKnife> Knifes = new List<ChooseKnife>();
    
    public static void Reg ()
    {
        ChooseKnife.Registare += (k) =>
        {
            Knifes.Add(k);
            if (k.Equip)
            {
                CheckKnife(k);
            }
        };
    }
    public static void CheckKnife (ChooseKnife kn)
    {
        foreach (ChooseKnife knife in Knifes)
        {
            if (knife != kn)
            {
                knife.Equip = false;
                PlayerPrefs.SetString(knife.Name + "Equip", "false");
            }
        }
    }
}
