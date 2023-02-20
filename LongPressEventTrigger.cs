using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace System
{
    public class LongPressEventTrigger : UIBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
    {
        [Tooltip("How often events should be triggered when the button is pressed (The lower the value, the more often; the higher the value, the less often)")]
        public float tact = 0.062f;

        [Space(10)]

        public UnityEvent onLongPress = new UnityEvent();

        private bool _isPointerDown;
        
        protected override void OnEnable()
        {
            base.OnEnable();
            StartCoroutine(EventUpdate());
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            StopCoroutine(EventUpdate());
        }

        private IEnumerator EventUpdate()
        {
            if (_isPointerDown) onLongPress.Invoke();

            yield return new WaitForSeconds(tact);
            StartCoroutine(EventUpdate());
        }

        public void OnPointerDown(PointerEventData eventData) => _isPointerDown = true;

        public void OnPointerUp(PointerEventData eventData) => _isPointerDown = false;

        public void OnPointerExit(PointerEventData eventData) => _isPointerDown = false;
    }
}
