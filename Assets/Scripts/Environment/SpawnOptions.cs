using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOptions : MonoBehaviour
{
    
    [SerializeField] GameObject[] optionsObj;
    [SerializeField] float secondSpawn = 1f;
    [SerializeField] float minTras;
    [SerializeField] float maxTras;

    private int stage = 1;
    private float gravity = 0.1f;
    public static SpawnOptions instance;

    void Awake()
    {
        instance = this;
    }

    public static void StartSpawn()
    {
        if (instance != null)
        {
            instance.StartCoroutine(instance.OptionSpawn());
        }
    }

    public IEnumerator OptionSpawn()
    {
        // while (true)
        if(PlayerPrefs.HasKey("CurrentStage")){
            stage = PlayerPrefs.GetInt("CurrentStage");
        }
        gravity = ChangeGravity(stage);

        int counter = 0;
        while(counter < 4)
        {
            var randLoc = Random.Range(minTras, maxTras);
            
            optionsObj[counter].transform.position = new Vector3(randLoc, transform.position.y);

            Rigidbody2D rb2D = optionsObj[counter].GetComponent<Rigidbody2D>();
            rb2D.simulated = true;
            rb2D.gravityScale = gravity;

            yield return new WaitForSeconds(secondSpawn);
            // Destroy(gameObject, 3f);
            counter++;
        }
    }

    private float ChangeGravity(int stage){
        float baseGravity = 0.1f;
        float gravityIncreasePer5Stages = 0.2f;
        int treshold = 16;

        if(stage == 31){
            treshold = 15;
        }

        // Calculate how many 5-stage increments have passed
        int increments = stage / treshold;

        // New gravity based on the increments
        float newGravity = baseGravity + (gravityIncreasePer5Stages * increments);

        return newGravity;
    }
}
