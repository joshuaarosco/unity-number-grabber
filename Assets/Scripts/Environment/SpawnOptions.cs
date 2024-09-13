using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOptions : MonoBehaviour
{
    [SerializeField] GameObject[] optionsObj;
    [SerializeField] float secondSpawn = 1f;
    [SerializeField] float minTras;
    [SerializeField] float maxTras;
    [SerializeField] float minDistanceBetweenOptions = 0.5f; // Minimum distance between spawned options

    private int stage = 1;
    private float gravity = 0.1f;
    public static SpawnOptions instance;

    private List<Vector3> spawnedPositions = new List<Vector3>(); // List to store spawned positions

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
        if (PlayerPrefs.HasKey("CurrentStage"))
        {
            stage = PlayerPrefs.GetInt("CurrentStage");
        }
        gravity = ChangeGravity(stage);

        int counter = 0;
        spawnedPositions.Clear(); // Clear the list before starting a new spawn cycle

        while (counter < 4)
        {
            Vector3 newSpawnPosition;
            bool positionIsValid = false;

            // Find a valid spawn position
            do
            {
                float randLoc = Random.Range(minTras, maxTras);
                newSpawnPosition = new Vector3(randLoc, transform.position.y, 0);

                // Check if the new position is far enough from all previously spawned positions
                positionIsValid = true;
                foreach (Vector3 pos in spawnedPositions)
                {
                    if (Vector3.Distance(newSpawnPosition, pos) < minDistanceBetweenOptions)
                    {
                        positionIsValid = false;
                        break;
                    }
                }
            }
            while (!positionIsValid); // Repeat until a valid position is found

            // Spawn the option at the valid position
            optionsObj[counter].transform.position = newSpawnPosition;

            Rigidbody2D rb2D = optionsObj[counter].GetComponent<Rigidbody2D>();
            rb2D.simulated = true;
            rb2D.gravityScale = gravity;

            // Store the position of the spawned option
            spawnedPositions.Add(newSpawnPosition);

            yield return new WaitForSeconds(secondSpawn);
            counter++;
        }
    }

    private float ChangeGravity(int stage)
    {
        float newGravity;
        float baseGravity = 0.1f;
        float gravityIncreasePer5Stages = 0.2f;
        int treshold = 16;

        if (stage == 31)
        {
            treshold = 15;
        }

        // Calculate how many 5-stage increments have passed
        int increments = stage / treshold;

        string gameCategory = StaticData.gameCategory;
        
        switch (gameCategory)
        {
            case "ip_address":
                newGravity = baseGravity;
                break;
            default:
                // New gravity based on the increments
                newGravity = baseGravity + (gravityIncreasePer5Stages * increments);
                break;
        }
        
        return newGravity;
    }
}
