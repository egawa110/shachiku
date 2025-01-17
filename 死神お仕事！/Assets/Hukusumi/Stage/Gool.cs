using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // ÉRÉåèdóv

public class Gool : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ClearCount clearcount = GetComponent<ClearCount>();
            if (SceneManager.GetActiveScene().name == "Stage1")
            {
                clearcount.S1C();
            }

        }
    }
}
