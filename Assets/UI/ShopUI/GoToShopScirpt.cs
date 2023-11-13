using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoToShopScirpt : MonoBehaviour
{
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Trigger Entered");
        if(other.tag == "Player")
        {
            SceneManager.LoadScene("ShopPage");
        }
    }
}
