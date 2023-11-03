using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public LevelUpEffect lve;
    public void close()
    {
        lve.unactive();
    }
}
