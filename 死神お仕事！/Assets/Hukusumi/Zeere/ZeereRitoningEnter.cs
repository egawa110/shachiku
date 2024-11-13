using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeereRitoningEnter : MonoBehaviour
{
    [SerializeField] GameObject prefab_A;
    public float x = 0.5f;
    public float y = 20.0f;
    public float rx = 1.0f;
    public float boder = 10.0f;
    bool onoff = false;//‹N“®—p
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            // isCheck‚Ì’l‚ð”½“]‚³‚¹‚é
            onoff = true;
        }
        if (onoff == true)
        {
            Transform myTransform = this.transform;
            Vector2 worldPos = myTransform.position;
            Instantiate(prefab_A, new Vector2(x, y), Quaternion.identity);
            Instantiate(prefab_A, new Vector2(-x, y), Quaternion.identity);
            x += rx;
            if(x>boder)
            {
                onoff = false;
                x = 0.5f;
            }
        }
    }
}
