using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// <para> Handles simple event cases that can be linked </para>
/// </summary>
public class PublicStaticEvents : MonoBehaviour
{

    public UnityEvent onClickEvents;
    public bool canOnlyInvokeOnce;
    private bool wasInvoked;
    

    private void PublicInvoke()
    {
        if (canOnlyInvokeOnce && wasInvoked)
            return;

        wasInvoked = true;
        onClickEvents.Invoke();
    }
}
