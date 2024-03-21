using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //don't forget TMPro here

public class CharacterControl : MonoBehaviour
{
    public TextMeshProUGUI currentSelection;
    public static CharacterControl Instance; //
    public static Villager SelectedVillager { get; private set; }
    public TMP_Dropdown dropdown;
    public Villager archer;
    public Villager thief;
    public Villager merchant;

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
            Debug.Log(index);
        }
        if (index == 1)
        {
            SetSelectedVillager(archer);
            Debug.Log(index);
        }
        if (index == 2)
        {
            SetSelectedVillager(thief);
            Debug.Log(index);
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
