using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ChickenAI : MonoBehaviour
{
    public Animator animator;

    private NavMeshAgent _agent;
    public GameObject Player;
    public float ChickenDistanceRun = 4f;

    public float current_health = 100;
    public GameObject DieEffect;

    public AudioClip soundDie;
    // Start is called before the first frame update
    void Start()
    {
        //animator.SetBool("isRunning", true);
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isRunning", false);
        float distance = Vector3.Distance(transform.position, Player.transform.position);
        
        //Debug.Log("Distance:" + distance);
        
        if (distance < ChickenDistanceRun)
        {
            //animator.SetTrigger("isRunning");
            animator.SetBool("isRunning",true);
            Vector3 dirToPlayer = transform.position - Player.transform.position;

            Vector3 newPos = transform.position + dirToPlayer;
            
            _agent.SetDestination(newPos);

         
        }
        if (transform.position.y < 1)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
    }
    public void TakeDamage(float amt)
    {
        current_health -= amt;

        if (current_health <= 0)
        {
            current_health = 0;
            Die();
        }
    }

    void Die()
    {

        if (gameObject.tag == "Chicken")
        {
            Score.scoreValue += 1;
            Destroy(gameObject);
            Instantiate(DieEffect, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(soundDie, transform.position);
        }
    }
}
