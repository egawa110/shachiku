using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectController : MonoBehaviour
{
    private EventSystem ev;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (gameObject.activeSelf == true)
        //{
        //    ev = EventSystem.current;
        //    ev.SetSelectedGameObject(gameObject);
        //}
    }

    void Select_Obj(BaseEventData data)
    {
        if (this.gameObject.activeSelf == true)
        {
            ev = EventSystem.current;
            ev.SetSelectedGameObject(this.gameObject,data);
        }
    }
}