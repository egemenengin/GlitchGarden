// Egemen Engin 
// https://github.com/egemenengin

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteButton : MonoBehaviour
{
    bool deleterActive = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
        FindObjectOfType<DefenderSpawner>().setDefender(null);
   
        gameObject.transform.GetComponent<SpriteRenderer>().color = Color.white;
        //Make dark all buttons until deletion.
        FindObjectOfType<DefenderButton>().makeDarkAllButton();
        
        //Make disabled all colliders of active defenders to click.
        foreach (Defender defender in FindObjectsOfType<Defender>())
        {
            defender.GetComponent<Collider2D>().enabled = false;
        }
        deleterActive = true;
    }
    public bool getDeleteActive()
    {
        return deleterActive;
    }
    public void setDeleteActive(bool activation)
    {
       gameObject.transform.GetComponent<SpriteRenderer>().color = new Color(0.2156863f, 0.2156863f, 0.2156863f, 1f);

        deleterActive = activation;
    }
}
