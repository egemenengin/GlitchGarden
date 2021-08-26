// Egemen Engin 
// https://github.com/egemenengin

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DefenderButton : MonoBehaviour
{
    static bool clickedChecker = false;
    [SerializeField] Defender defenderPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //GetComponentInChildren<TextMeshPro>().text = defenderPrefab.getStarCost().ToString();
        transform.GetChild(0).GetComponent<TextMeshPro>().SetText( defenderPrefab.getStarCost().ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        makeDarkAllButton();
        FindObjectOfType<DeleteButton>().setDeleteActive(false);
        clickedChecker = true;
        gameObject.transform.GetComponent<SpriteRenderer>().color = Color.white;
        FindObjectOfType<DefenderSpawner>().setDefender(defenderPrefab);
        /*GameObject temp = GameObject.Find("Core Game Area") ;
        temp.GetComponent<DefenderSpawner>().setDefender(defenderPrefab);*/
        
        
    }
    public void makeDarkAllButton()
    {
        var buttons = FindObjectsOfType<DefenderButton>();
        foreach (DefenderButton button in buttons)
        {
            button.transform.GetComponent<SpriteRenderer>().color = new Color(0.2156863f, 0.2156863f, 0.2156863f, 1f);
        }
    }
   
  
   
}
