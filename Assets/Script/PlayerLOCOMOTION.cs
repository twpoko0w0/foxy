using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLOCOMOTION : MonoBehaviour
{
    public Animator anim;

    

    //float swordchang = 0.0f;
    float velocityx = 0.0f;
    float velocityz = 0.0f;
    public float Acceleration = 0.5f;
    public float Deacceleration = 0.5f;
    int VelocityHashX;
    int VelocityHashZ;
    //int swordComb;

    bool coollight = true;
    bool coollHeavy = true;

    public AudioClip soundATK;

    void Start()
    {
        anim = GetComponent<Animator>();
        

        VelocityHashX = Animator.StringToHash("Velocity X");
        VelocityHashZ = Animator.StringToHash("Velocity Z");
        //swordComb = Animator.StringToHash("SwordCombos");
    }


    void Update()
    {

        bool fowardpressed = Input.GetKey(KeyCode.W);
        bool backwardpressed = Input.GetKey(KeyCode.S);
        bool leftpressed = Input.GetKey(KeyCode.A);
        bool rightpressed = Input.GetKey(KeyCode.D);
        bool attack = Input.GetKeyDown(KeyCode.Mouse0);
        bool heavyattack = Input.GetKeyDown(KeyCode.Mouse1);


        if (fowardpressed && velocityz < 0.5f)               //Forward
        {

            velocityz += Time.deltaTime * Acceleration;

        }
        if (!fowardpressed && velocityz > 0.0f)
        {
            velocityz -= Time.deltaTime * Deacceleration;

        }
        if (backwardpressed && velocityz > -0.5f)     //Backward
        {
            velocityz -= Time.deltaTime * Acceleration;
        }
        if (!backwardpressed && velocityz < 0.0f)
        {
            velocityz += Time.deltaTime * Deacceleration;
        }

        if (rightpressed && velocityx < 0.5f)  //Right
        {
            velocityx += Time.deltaTime * Acceleration;
        }
        if (!rightpressed && velocityx > 0.0f)
        {
            velocityx -= Time.deltaTime * Deacceleration;
        }
        if (leftpressed && velocityx > -0.5f)     //Left
        {
            velocityx -= Time.deltaTime * Acceleration;
        }
        if (!leftpressed && velocityx < 0.0f)
        {
            velocityx += Time.deltaTime * Deacceleration;
        }


        if (attack && coollight == true)
        {
            nointerupt();
            CooldownLightAttack();
        }

        if(heavyattack && coollHeavy == true) 
        {
            anim.SetTrigger("isHeavyAttacking");
            CooldownHeavyAttack();

        }
        void nointerupt()
        {
            //heavy set false then wait 1 sec for set to true
            StartCoroutine(Interupt());

            IEnumerator Interupt()
            {
                AudioSource.PlayClipAtPoint(soundATK, transform.position);
                anim.SetTrigger("isAttacking");
                coollHeavy = false;
                yield return new WaitForSeconds(0.6f);
                coollHeavy = true;

            }
        }

        void CooldownLightAttack()
        {
            

            if (coollight == true)
            {
                StartCoroutine(coroutineA());

                IEnumerator coroutineA()
                {
                    coollight = false;
                    yield return new WaitForSeconds(0.6f);
                    coollight = true;
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






        anim.SetFloat(VelocityHashZ, velocityz);
        anim.SetFloat(VelocityHashX, velocityx);

        //anim.SetFloat(swordComb, swordchang);









    }
}
