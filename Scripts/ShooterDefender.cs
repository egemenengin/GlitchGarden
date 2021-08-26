// Egemen Engin 
// https://github.com/egemenengin

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterDefender : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    
    GameObject gun;
    AttackerSpawner myLaneSpawner;
    Animator anim;
    GameObject projectilesParent;

    // Start is called before the first frame update
    void Start()
    {
        findProjectiles();

        anim = GetComponent<Animator>();
        setLane();
        gun = gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttackerInMyLane())
        {
            anim.SetBool("isAttacking", true);
        }
        else
        {
            anim.SetBool("isAttacking", false);
        }
       
    }

    public void fire(float damageOfShoot)
    {
       
        GameObject newProjectile = Instantiate(projectile, gun.transform.position, transform.rotation) as GameObject;
        newProjectile.transform.parent = projectilesParent.transform;
        
    }
    private bool isAttackerInMyLane()
    {
        if (myLaneSpawner.transform.childCount == 0)
        {
            return false;
        }
        else{
            return true;
        }
        
    }
    private void setLane()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawners)
        {
            //bool isCloseEnogh = (spawner.transform.position.y == transform.position.y);

            bool isCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            if (isCloseEnough)
            {
                myLaneSpawner = spawner;
            }        

        }
    }
    private void findProjectiles()
    {
        projectilesParent = GameObject.Find("Projectiles");
        if (!projectilesParent)
        {
            projectilesParent = new GameObject("Projectiles");

        }
    }
}
