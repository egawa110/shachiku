using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageNum_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            //PlayerPrefs��SCORE��3�Ƃ����l������
            PlayerPrefs.SetInt("SCORE", 3);
            //PlayerPrefs���Z�[�u����
            PlayerPrefs.Save();
        }
    }
}
