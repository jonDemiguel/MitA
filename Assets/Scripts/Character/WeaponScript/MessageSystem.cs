using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class MessageSystem : MonoBehaviour
{
    public static MessageSystem instance;

    List<TMPro.TextMeshPro> messagePool;    // List of damage messages that's reusable
    int objectCount = 10;   // Number of damage messages to be stored
    int count;  // Current index of damage message
    [SerializeField] GameObject damageMessage;  // Prefab of damage message

    private void Awake()
    {
        // Singleton
        instance = this;
    }

    private void Start()
    {
        // Initialize the damage message pool
        messagePool = new List<TMPro.TextMeshPro>();
        for (int i = 0; i < objectCount; i++)
        {
            Populate();
        }
    }


    public void Populate()
    {
        // Instantiate the damage message prefab and add it to the pool
        GameObject go = Instantiate(damageMessage, transform);
        messagePool.Add(go.GetComponent<TMPro.TextMeshPro>());
        go.SetActive(false);
    }

    public void PostMessage(string text, Vector3 worldPosition)
    {
        // Post the damage message at the given position
        messagePool[count].gameObject.SetActive(true);
        messagePool[count].transform.position = worldPosition;
        messagePool[count].text = text;
        count++;

        if (count >= objectCount)
        {
            count = 0;
        }
    }
}
