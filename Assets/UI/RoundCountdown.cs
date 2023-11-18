using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoundCountdown : MonoBehaviour
{
    Transform textTransform;
    TextMeshPro text;
    GameObject canvas1;

    private void Start()
    {
        canvas1 = this.gameObject;
        textTransform = transform.Find("CountdownText");
        canvas1.SetActive(false);
    }

    public void StartCountdown()
    {
        
        Time.timeScale = 0f;

        canvas1.SetActive(true);

        if (textTransform != null)
        {
            // Get the TextMeshPro component from the child
            text = textTransform.GetComponent<TextMeshPro>();
        }
        else
        {
            Debug.LogError("Child object with name 'ChildTextObject' not found.");
        }

        int countdownTime = 3;

        for (int i = countdownTime; i > 0; i--)
        {
            // Update the text with the countdown value
            if (text != null)
            {
                // Now you can use 'textMeshPro' to manipulate the TextMeshPro component
                text.text = i.ToString();
            }
            else
            {
                Debug.LogError("TextMeshPro component not found on the child object.");
            }



            // Wait for one second
            float elapsedTime = 0f;
            while (elapsedTime < 1f)
            {
                elapsedTime += Time.deltaTime;
                // Use the frame time to wait for one second
            }

            // You can also use WaitForSeconds(1f) instead of the while loop, but this allows more flexibility

        }

    EndCountDown();

       
    }



    public void EndCountDown()
    {
        canvas1.SetActive(false);
        Time.timeScale = 1;
    }

}
