// Egemen Engin 
// https://github.com/egemenengin

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class StarDisplay : MonoBehaviour
{
    [SerializeField] int curStar = 50;
    // Start is called before the first frame update
    TextMeshProUGUI starText;
    void Start()
    {
        starText = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
    }
    public void updateStar(int amountOfStar, bool increase)//If boolean is true, it means it is increasing .If it is false, it means it decreasing.
    {
        if (increase)
        {
            curStar += amountOfStar;
        }
        else
        {
            curStar -= amountOfStar;
        }
        UpdateDisplay();
    }
    public void UpdateDisplay()
    {
        starText.text = curStar.ToString();
    }
    public int getCurStar()
    {
        return curStar;
    }
}
