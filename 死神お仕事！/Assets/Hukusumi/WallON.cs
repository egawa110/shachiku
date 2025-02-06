using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallON : MonoBehaviour
{
    public void ON()
    {
        GetComponent<BoxCollider2D>().enabled = true;
    }
}
