// Egemen Engin 
// https://github.com/egemenengin

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;
    GameObject defenderParent;
    const string DEFENDER_PARENT_NAME = "Defenders";
    private void Start()
    {
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);

        }
        
    }

    public void setDefender(Defender defenderPrefab)
    {
        defender = defenderPrefab;
    }
    private void OnMouseDown()
    {
       
        spawnDefender();
    }
    private Vector2 getSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(clickPos);
        

        return worldPosition;
    }
    private void spawnDefender()
    {
        int currentStar = FindObjectOfType<StarDisplay>().getCurStar();
        if (defender)
        {
            if (currentStar - defender.getStarCost() >= 0)
            {
                Vector2 position = new Vector2(Mathf.Round(getSquareClicked().x), Mathf.RoundToInt(getSquareClicked().y));
                Defender newDefender = Instantiate(defender, position, Quaternion.identity) as Defender;
                newDefender.transform.parent = defenderParent.transform;
                FindObjectOfType<StarDisplay>().updateStar(newDefender.getStarCost(), false);
            }
        }
    }
}
