using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class EnergyDisplay : MonoBehaviour
{
    [SerializeField] private int energy = 100;
    private TextMeshProUGUI energyText;

    private void Start()
    {
        energyText = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        energyText.text = energy.ToString();
    }

    public bool HaveEnoughEnergy(int amount)
    {
        return energy >= amount;
    }

    public void AddEnergy(int amountToAdd)
    {
        energy += amountToAdd;
        UpdateDisplay();
    }

    public void DecreaseEnergy(int amountToDecrease)
    {
        if (energy >= amountToDecrease)
        {
            energy -= amountToDecrease;
            UpdateDisplay();
        }
    }
}
