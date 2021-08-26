// Egemen Engin 
// https://github.com/egemenengin

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject target = collision.gameObject;
        if(target.tag.Equals("Gravestone"))
        {
            GetComponent<Animator>().SetTrigger("jumpTrigger");
        }
        else if (target.GetComponent<Defender>())
        {
            
            GetComponent<Attacker>().targetLocated(target);
        }
    }
}
