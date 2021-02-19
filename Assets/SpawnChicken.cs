using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChicken : MonoBehaviour
{
    public GameObject Chicken;
    private int xPos;
    private int zPos;
    private int yPos;
    private int cubeCount = 0;
    public int clone;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CubeSp());
    }

    // Update is called once per frame

    IEnumerator CubeSp()
    {
        while (cubeCount < clone)
        {
            Debug.Log("SpawnAstro");

            xPos = Random.Range(-23, 26);
            zPos = Random.Range(-3, 31);
            yPos = Random.Range(3, 3);
            Instantiate(Chicken, new Vector3(xPos, yPos, zPos), Quaternion.identity);
            yield return new WaitForSeconds(2);
            //Invoke("cubeCount += 1", 10f);
            cubeCount += 1;


        }
    }
}
