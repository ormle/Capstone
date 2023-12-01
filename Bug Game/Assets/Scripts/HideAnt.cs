using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideAnt : MonoBehaviour
{
    public GameObject bugO;

    // Update is called 
    void Update()
    {
        int bug   = PlayerPrefs.GetInt("Ant", 0);
        
        if (bug > 0)
        {
            bugO.SetActive(true);
        }
        else
        {
            bugO.SetActive(false);
        }
    }
}
