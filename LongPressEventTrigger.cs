using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class LongPressEventTrigger : UIBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    [Tooltip("How often events should be triggered when the button is pressed (The lower the value, the more often; the higher the value, the less often)")]
    public float tact = 0.062f;

    [Space(10)]

    public UnityEvent onLongPress = new UnityEvent();

    private bool isPointerDown;

    protected override void Start()
    {
        base.Start();
        StartCoroutine(EventUpdate());
    }

    private IEnumerator EventUpdate()
    {
        if (isPointerDown) onLongPress.Invoke();

        yield return new WaitForSeconds(tact);
        StartCoroutine(EventUpdate());
    }

    public void OnPointerDown(PointerEventData eventData) => isPointerDown = true;

    public void OnPointerUp(PointerEventData eventData) => isPointerDown = false;

    public void OnPointerExit(PointerEventData eventData) => isPointerDown = false;
}
