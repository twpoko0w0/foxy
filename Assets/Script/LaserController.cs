using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    
    
    
    private Transform latestSelection;
    private int opendoorwithkey;
    bool cool = true;
    bool coollHeavy = true;

    public int Damage = 25;
    public int DamageHeavy = 40;


    void Start()
    {

        
        
    }


    void Update()
    {
        bool attack = Input.GetKeyDown(KeyCode.Mouse0);
        bool heavyattack = Input.GetKeyDown(KeyCode.Mouse1);




        if (latestSelection != null)
        {
            var selectionRenderer = latestSelection.GetComponent<Renderer>();


        }
        Ray ray = Camera.main.ScreenPointToRay(transform.position);
        RaycastHit hitData;
        Debug.DrawRay(ray.origin, ray.direction, Color.red, 45);

        if (Physics.Raycast(ray, out hitData, 5))
        {
            var selection = hitData.transform;
            
            if (selection.gameObject.tag == "Chicken" && attack && cool == true)
            {
                selection.gameObject.SendMessage("TakeDamage", Damage);

                

                Debug.Log("Hello");
            }
            if (selection.gameObject.tag == "Chicken" && heavyattack && coollHeavy == true)
            {
                selection.gameObject.SendMessage("TakeDamage", DamageHeavy);
                Debug.Log("HelloHeavy");
            }
           


        }






        if (attack && cool == true)
        {
            nointerupt();

            Cooldown();
        }
        if (heavyattack && coollHeavy == true)
        {
            
            CooldownHeavyAttack();

        }
        void nointerupt()
        {
            //heavy set false then wait 1 sec for set to true
            StartCoroutine(Interupt());

            IEnumerator Interupt()
            {
                
                coollHeavy = false;
                yield return new WaitForSeconds(0.6f);
                coollHeavy = true;

            }
        }

        void Cooldown()
        {


            if (cool == true)
            {
                StartCoroutine(coroutineA());

                IEnumerator coroutineA()
                {
                    cool = false;
                    yield return new WaitForSeconds(0.6f);
                    cool = true;
                }
            }

        }
        void CooldownHeavyAttack()
        {


            if (coollHeavy == true)
            {
                StartCoroutine(coroutineA());

                IEnumerator coroutineA()
                {
                    coollHeavy = false;
                    yield return new WaitForSeconds(1.5f);
                    coollHeavy = true;
                }
            }
        }
    }
    
}
