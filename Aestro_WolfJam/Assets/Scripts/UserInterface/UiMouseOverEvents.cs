using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UiMouseOverEvents : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    //public AudioSource aSource_Sfx;
    //public AudioClip aClip_MouseOver;
    //public AudioClip aClip_MouseExit;

    public UnityEvent mouseOverEvent;
    public UnityEvent mouseExitEvent;

    public bool useMouseOffCode = false;

    private bool mouse_over = false;
    void Update()
    {
        if (mouse_over)
        {
            //Debug.Log("Mouse Over");
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouse_over = true;
        //Debug.Log("Mouse enter");
        mouseOverEvent.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (useMouseOffCode)
        {
            mouse_over = false;
            //Debug.Log("Mouse exit");
            mouseExitEvent.Invoke();
        }
        
    }
}