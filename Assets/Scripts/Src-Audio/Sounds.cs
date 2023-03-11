using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    void Awake()
    {
        AudioSource = GetComponent<AudioSource>();
        DontDestroy();
    }

    public AudioSource AudioSource { get; set; }

    
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
