// Egemen Engin 
// https://github.com/egemenengin

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    
    [SerializeField] int starCost = 25;
    [SerializeField] float healthOfDefender = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int getStarCost()
    {
        return starCost;
    }
    public void increaseStar(int amountOfStar)
    {
        FindObjectOfType<StarDisplay>().updateStar(amountOfStar, true);
    }
    public void dealDamage(float damage)
    {
        healthOfDefender -= damage;
        if (healthOfDefender <= 0)
        {
            Destroy(gameObject);
        }
    }
}
