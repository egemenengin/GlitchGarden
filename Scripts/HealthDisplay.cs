// Egemen Engin 
// https://github.com/egemenengin

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HealthDisplay : MonoBehaviour
{
    int curHealth = 5;
    TextMeshProUGUI HealthText;
 
    // Start is called before the first frame update
    void Start()
    {
        HealthText = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }
    public void UpdateDisplay()
    {
        HealthText.text = curHealth.ToString();
    }
    public void updateHealth()//If boolean is true, it means it is increasing .If it is false, it means it decreasing.
    {
        curHealth -= 1;
        UpdateDisplay();
        if (curHealth <= 0)
        {
            FindObjectOfType<LevelController>().HandleWithLoseCondition();
        }
       
    }
    public void setCurrentHealth(int difficulty)
    {
        curHealth -= difficulty;
    }
   
   
}
