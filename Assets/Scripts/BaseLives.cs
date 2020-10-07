using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BaseLives : MonoBehaviour
{
   [SerializeField] private float totalLives = 5;
   [SerializeField] private int amountOfLivesToDecrease = 1;
   public float playerLives = 5;
   private TextMeshProUGUI baseLivesText;

   private void Start()
   {
      playerLives = totalLives - PlayerPrefsManager.GetDifficulty();
      baseLivesText = GetComponent<TextMeshProUGUI>();
      UpdateDisplay();
   }
   
   private void UpdateDisplay()
   {
      baseLivesText.text = playerLives.ToString();
   }
   
   public void DecreaseLife()
   {
         playerLives -= amountOfLivesToDecrease;
         UpdateDisplay();

         if (playerLives <= 0)
         {
            FindObjectOfType<LevelController>().HandleLoseCondition();
         }
   }
}
