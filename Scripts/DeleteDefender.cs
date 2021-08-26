// Egemen Engin 
// https://github.com/egemenengin

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteDefender : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private Vector2 getSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(clickPos);

        return worldPosition;
    }
    public void findAndDeleteClickedDefender()
    {
        
        foreach(Defender defender in FindObjectsOfType<Defender>())
        {
            if(defender.transform.position.y == Mathf.Round(getSquareClicked().y) && defender.transform.position.x == Mathf.Round(getSquareClicked().x))
            {
                Destroy(defender.gameObject);
                break;
            }
           
        }
        foreach (Defender defender in FindObjectsOfType<Defender>())
        {
            defender.GetComponent<Collider2D>().enabled = true;
        }
        FindObjectOfType<DeleteButton>().setDeleteActive(false);

    }
    private void OnMouseDown()
    {
        if (FindObjectOfType<DeleteButton>().getDeleteActive())
        {
            
            findAndDeleteClickedDefender();
        }
            
    }
}
