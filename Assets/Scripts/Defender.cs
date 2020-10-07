using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
   [SerializeField] private int energyCost = 100;


   public void AddEnergy(int amountToAdd)
   {
      FindObjectOfType<EnergyDisplay>().AddEnergy(amountToAdd);
   }

   public int EnergyCost()
   {
      return energyCost;
   }
}
