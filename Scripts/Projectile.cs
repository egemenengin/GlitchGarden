// Egemen Engin 
// https://github.com/egemenengin

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{   
    [Header("SPEED")]
    [SerializeField] float speed = 1f;
    [SerializeField] float speedOfSpin = -1f;
    [SerializeField] float damage = 50f;
    // Start is called before the first frame update
    void Start()
    {
    }

  

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime,Space.World);
        //transform.Rotate(Vector2.right * Time.deltaTime);
        transform.Rotate(0f,0f,speedOfSpin,Space.Self);
       // transform.Rotate(-Vector3.forward * 300f * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        var attacker = collision.GetComponent<Attacker>();
        //reduce health
       
        if (attacker && this.gameObject) {
            attacker.dealDamage(damage);
            Destroy(gameObject);
        }
            
    }
    
}
