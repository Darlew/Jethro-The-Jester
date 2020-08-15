using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notification : MonoBehaviour
{
    public Text notifText;
    public Image background;

    //Disable notification background as game starts to hide until needed
    private void Start()
    {
        background.enabled = false;    
    }

    //Display notification containing input text.
    public void updateText(string newText)
    {
        notifText.text = newText;
        background.enabled = true;
        StartCoroutine(RemoveAfterSeconds(2));
    }

    //Make notification disappear after 2 seconds
    IEnumerator RemoveAfterSeconds(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        background.enabled = false;
        notifText.text = "";
    }
}
