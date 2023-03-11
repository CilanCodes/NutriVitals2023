using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyObject : MonoBehaviour
{
    private void Awake()
    {
        DontDestroy();
    }

    private void DontDestroy()
    {

        if (FindObjectsOfType(GetType()).Length > 1)
        {

            Destroy(gameObject);

        }
        else
        {

            DontDestroyOnLoad(gameObject);

        }

    }
}
