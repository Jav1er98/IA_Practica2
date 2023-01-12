using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotGuardAIController : MonoBehaviour
{
    public Transform player;
    Animator anim;
    public float maxHealth = 100.0f;
    float health;
    
    public float visibleRange = 80.0f;
    public float halfVisionConeAngle = 45.0f;
    public float shotRange = 40.0f;
    public float safeHealth = 40.0f;
    public float rotSpeed = 10.0f;

    void Start()
    {
        InvokeRepeating("UpdateHealth", 5, 0.5f);

        health = maxHealth;
        anim = this.GetComponent<Animator>();
    }

    void Update()
    {
        //Vector3 healthBarPos = Camera.main.WorldToScreenPoint(this.transform.position);
        //healthBar.value = (int)health;
        //healthBar.transform.position = Camera.main.WorldToScreenPoint(this.transform.position  + new Vector3(0, 1.2f, 0));
        
        //Update Animator flags
        Vector3 distance = player.transform.position - this.transform.position;
        anim.SetBool("IsPlayerInSight", DoesSeePlayer());
        anim.SetBool("IsPlayerInAttackRange", distance.magnitude <= shotRange);
        anim.SetBool("IsHealthSafe", health >= safeHealth);
    }

    void UpdateHealth()
    {
        if (health < maxHealth)
            health++;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "bullet")
        {
            health -= 10;
        }
    }
    bool DoesSeePlayer()
    {
        Vector3 distance = player.transform.position - this.transform.position;
        
        RaycastHit hit;
        if (Physics.Raycast(this.transform.position, distance, out hit))
        {
            if (hit.collider.gameObject.tag == "hide")
            {
                return false;
            }
        }

        return distance.magnitude <= visibleRange &&
               Vector3.Angle(this.transform.forward, distance) <= halfVisionConeAngle;
    }
}

