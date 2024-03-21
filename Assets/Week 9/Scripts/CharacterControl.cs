using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //don't forget TMPro here
using UnityEngine.UI; //took long enough to remember this one too

public class CharacterControl : MonoBehaviour
{
    public TextMeshProUGUI currentSelection;
    public static CharacterControl Instance; //
    public static Villager SelectedVillager { get; private set; }
    public TMP_Dropdown dropdown;
    public Villager archer;
    public Villager thief;
    public Villager merchant;
    public Slider slider;
    public Transform tfMerchant;
    public Transform tfArcher;
    public Transform tfThief;
    public int bagOfIndex;

    public static void SetSelectedVillager(Villager villager)
    {
        if(SelectedVillager != null)
        {
            SelectedVillager.Selected(false);
        }
        SelectedVillager = villager;
        SelectedVillager.Selected(true);
        Instance.currentSelection.text = villager.ToString();
        //Instance.currentSelection.text = villager.GetType().ToString(); // if I do villager.ToString, it'll say
        //Archer(Archer) or Bob(Archer) but if I do this instead, just Archer
    }
    private void Start()
    {
        Instance = this;
    }
    public void dropDownMenu(int index)
    {
        Debug.Log(index);
        if (index == 0)
        {
            SetSelectedVillager(merchant);
            bagOfIndex = 0;
            Debug.Log(index);
        }
        if (index == 1)
        {
            SetSelectedVillager(archer);
            bagOfIndex = 1;
            Debug.Log(index);
        }
        if (index == 2)
        {
            SetSelectedVillager(thief);
            bagOfIndex = 2;
            Debug.Log(index);
        }
    }

    public void villagerSizeSlider(Single scale)
    {
        if (bagOfIndex ==0)
        {
            tfMerchant.transform.localScale = new Vector3(scale, scale, 0);
        }
        if (bagOfIndex == 1)
        {
            tfArcher.transform.localScale = new Vector3(scale, scale, 0);
        }
        if (bagOfIndex == 2)
        {
            tfThief.transform.localScale = new Vector3(scale, scale, 0);
        }
    }

    private void Update()
    {
        //if(SelectedVillager != null)
        //{
        //    currentSelection.text = SelectedVillager.GetType().ToString();
        //}
    }
}
