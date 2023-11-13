using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class MessageSystem : MonoBehaviour
{
    public static MessageSystem instance;

    List<TMPro.TextMeshPro> messagePool;

    private void Awake()
    {
        instance = this;
    }

    int objectCount = 10;
    int count;

    private void Start()
    {
        messagePool = new List<TMPro.TextMeshPro>(); 
        for(int i = 0; i < objectCount; i++)
        {
            Populate();
        }
    }

    public void Populate()
    {
        GameObject go = Instantiate(damageMessage, transform);
        messagePool.Add(go.GetComponent<TMPro.TextMeshPro>());
        go.SetActive(false);
    }

    [SerializeField] GameObject damageMessage;

    public void PostMessage(string text, Vector3 worldPosition)
    {
        messagePool[count].gameObject.SetActive(true);
        messagePool[count].transform.position = worldPosition;
        messagePool[count].text = text;
        count++;

        if (count >= objectCount)
        {
            count = 0;
        }
        // GameObject go = Instantiate(damageMessage, transform);
        // go.transform.position = worldPosition;
        // go.GetComponent<TMPro.TextMeshPro>().text = text;
    }
}
