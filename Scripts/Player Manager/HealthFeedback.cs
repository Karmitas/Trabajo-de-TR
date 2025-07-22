using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class HealthFeedback : MonoBehaviour
{
    [Header("Scripts")]
    public PlayerHealth playerHealth;

    [Header("Health Feedback")]
    public float maxHealth;
    public float currentHealth;

    [Header("Game Objects")]
    public List<GameObject> healthFeedbackObjects = new List<GameObject>();


    void Start()
    {
        if (playerHealth == null)
        {
            playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        }
    }

    void Update()
    {
        maxHealth = playerHealth.maxHealth;
        currentHealth = playerHealth.currentHealth;

        float healthPercent = (currentHealth / maxHealth) * 100f;

        for (int i = 0; i < healthFeedbackObjects.Count; i++)
        {
            float threshold = 100f - ((i + 1) * 10f);
            if (healthPercent <= threshold)
            {
                if (healthFeedbackObjects[i].activeSelf)
                    healthFeedbackObjects[i].SetActive(false);
            }
            else
            {
                if (!healthFeedbackObjects[i].activeSelf)
                    healthFeedbackObjects[i].SetActive(true);
            }
        }
    }
}
