using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VbButterfly : MonoBehaviour
{
    public GameObject bug;

    void Start()
    {
        int bugVisibility = PlayerPrefs.GetInt("Butterfly", 0);

        if (bugVisibility > 0)
        {
            // Set bug visibility to true
            bug.SetActive(true);
        }
        else
        {
            // Set bug visibility to false
            bug.SetActive(false);
        }
    }
}
