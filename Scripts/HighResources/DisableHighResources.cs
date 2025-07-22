using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class DisableHighResources : MonoBehaviour
{
    [Header("Disable High Resources")]
    public bool disableHighResources = false;

    [HideInInspector]
    public List<GameObject> highResourceObjects;
    public List<GameObject> treesRotatative;

    private Data data;

    void Start()
    {
        data = GameObject.FindGameObjectWithTag("Data").GetComponent<Data>();
        if (data == null)
        {
            disableHighResources = false;
        }
        else
        {
            disableHighResources = data.lowQuality;
        }

        if (disableHighResources)
        {
            highResourceObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("HighResources"));

            foreach (GameObject obj in highResourceObjects)
            {
                if (obj != null)
                {
                    Destroy(obj);
                }
            }

            highResourceObjects.Clear();
        }

        treesRotatative = new List<GameObject>(GameObject.FindGameObjectsWithTag("Tree"));
        foreach (GameObject tree in treesRotatative)
        {
            if (tree != null)
            {
                float randomY = Random.Range(0f, 360f);
                tree.transform.rotation = Quaternion.Euler(0f, randomY, 0f);
            }
        }
    }
}
