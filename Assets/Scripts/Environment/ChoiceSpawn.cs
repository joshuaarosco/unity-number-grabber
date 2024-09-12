using System.Collections;
using UnityEngine;
using TMPro;

public class ChoiceSpawn : MonoBehaviour
{
    [SerializeField] GameObject[] choicePrefabs;
    [SerializeField] float secondSpawn = 0.5f;
    [SerializeField] float minTras;
    [SerializeField] float maxTras;

    void Start()
    {
        StartCoroutine(ChoicesSpawn());
    }

    IEnumerator ChoicesSpawn()
    {
        // while (true)
        int counter = 0;
        while(counter < 4)
        {
            var randLoc = Random.Range(minTras, maxTras);
            var position = new Vector3(randLoc, transform.position.y);

            GameObject choice = choicePrefabs[Random.Range(0, choicePrefabs.Length)];
            GameObject gameObject = Instantiate(choice, position, Quaternion.identity);

            yield return new WaitForSeconds(secondSpawn);
            Destroy(gameObject, 3f);
            counter++;
        }
    }

}
