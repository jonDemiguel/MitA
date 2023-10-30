using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpEffect : MonoBehaviour
{
    // Start is called before the first frame update
    public bool display;
    public GameObject lvEffect;
    public float timeRemain = 10;
    void Start()
    {
        lvEffect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemain > 0)
        {
            timeRemain -= Time.deltaTime;
        }
        else
        {
            unactive();
            timeRemain = 10;
        }
    }
    public void playEffect()
    {
        lvEffect.SetActive(true);

    }

    public void unactive()
    {
        lvEffect.SetActive(false);
    }
}
