using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CheckCollision : MonoBehaviour
{
    public string childTag = "OptionText";
    public QuestionManager questionManager;

    void Start()
    {
        questionManager = FindObjectOfType<QuestionManager>();
    }

    void OnCollisionEnter2D(Collision2D collision){
        // Debug.Log(collision.gameObject.tag + " starts colliding");

        if(collision.gameObject.tag == "Option" || collision.gameObject.tag == "LastOption"){
            // Find all child objects with the specified tag
            Transform childTransform = FindChildWithTag(collision.gameObject.transform, childTag);

            if (childTransform != null)
            {
                // Get the TextMeshPro component from the child object
                TextMeshPro textMeshPro = childTransform.GetComponent<TextMeshPro>();

                if (textMeshPro != null)
                {
                    // Access the text value
                    string playerAnswer = textMeshPro.text;
                    //Debug.Log("Player Answer: " + playerAnswer);

                    // Call Question Manager Class
                    if (questionManager != null)
                    {
                        questionManager.OnPlayerAnswer(playerAnswer);
                    }
                    else
                    {
                        Debug.LogError("QuestionManager reference is not set.");
                    }
                }
                else
                {
                    Debug.LogError("TextMeshPro component not found on the child object.");
                }
            }
            else
            {
                Debug.LogError("Child object with tag not found.");
            }
        }
    }

    // Method to find a child object with a specific tag
    Transform FindChildWithTag(Transform parent, string tag)
    {
        foreach (Transform child in parent)
        {
            if (child.CompareTag(tag))
            {
                return child;
            }
        }
        return null; // Return null if no child with the specified tag is found
    }
}
