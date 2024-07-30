using UnityEngine;
using UnityEngine.EventSystems;

namespace Core
{
    public interface ITap
    {
        void OnTap(Vector2 vector);
        void OnUntap(Vector2 vector);
        bool IsBlockTap { get; }
    }

    public class TapHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private ITap _currentTap;

        public void OnPointerDown(PointerEventData eventData)
        {
            var tapPosition = GetMouseWorldPosition();
            var taps = Physics2D.RaycastAll(tapPosition, Vector2.zero);

            foreach (var tap in taps)
            {
                if (tap.transform != null && tap.transform.TryGetComponent(out _currentTap))
                {
                    if (_currentTap.IsBlockTap == false)
                        _currentTap.OnTap(GetMouseWorldPosition());
                }
            }

        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _currentTap?.OnUntap(GetMouseWorldPosition());
            _currentTap = null;
        }

        private Vector2 GetMouseWorldPosition()
        {
            return Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}
