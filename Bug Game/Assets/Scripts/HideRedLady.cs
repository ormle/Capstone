using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideRedLady : MonoBehaviour
{
    public GameObject ladybugGameObject;

    // Update is called 
    void Update()
    {
        int lady   = PlayerPrefs.GetInt("Lady", 0);
        
        if (lady > 0)
        {
            ladybugGameObject.SetActive(false);
        }
        else
        {
            ladybugGameObject.SetActive(true);
        }
    }
}
