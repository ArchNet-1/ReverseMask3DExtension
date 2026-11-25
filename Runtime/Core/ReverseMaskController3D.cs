// ArchNet · Reverse Mask 3D Extension
// Darkens the screen with a UI overlay that has "holes" (Mask3D) over 3D objects.
// A click inside a hole reaches the 3D object under it; a click elsewhere is blocked.
// Docs: https://archnet-plateform.fr/#ReverseMask3DExtension

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace ArchNet.Extension
{
    [AddComponentMenu("ArchNet/Reverse Mask 3D Controller")]
    public class ReverseMaskController3D : MonoBehaviour, IPointerClickHandler
    {
        [Tooltip("Full-screen overlay. It must receive clicks (Image with Raycast Target).")]
        [SerializeField] CanvasGroup _masker;
        [Tooltip("Camera that renders the 3D objects. Empty = Camera.main.")]
        [SerializeField] Camera _sceneCamera;
        [Tooltip("Camera of the overlay's canvas. Empty for Screen Space - Overlay.")]
        [SerializeField] Camera _uiCamera;
        [Tooltip("Called with the 3D object clicked through a hole.")]
        [SerializeField] UnityEvent<GameObject> _onObjectClicked = new UnityEvent<GameObject>();

        readonly List<Mask3D> _masks = new List<Mask3D>();

        public UnityEvent<GameObject> OnObjectClicked => _onObjectClicked;
        public IReadOnlyList<Mask3D> Masks => _masks;

        public void AddMask(Mask3D mask)
        {
            if (mask != null && !_masks.Contains(mask)) _masks.Add(mask);
        }

        public void RemoveMask(Mask3D mask) => _masks.Remove(mask);

        public void ShowMasker() => _masker.SetVisible(true);
        public void HideMasker() => _masker.SetVisible(false);

        /// <summary>Forwards a click inside a hole to the 3D object under the pointer.</summary>
        public void OnPointerClick(PointerEventData eventData)
        {
            if (!IsInsideAMask(eventData.position)) return;

            Camera sceneCamera = _sceneCamera != null ? _sceneCamera : Camera.main;
            if (sceneCamera == null || !Physics.Raycast(sceneCamera.ScreenPointToRay(eventData.position), out RaycastHit hit)) return;

            GameObject target = hit.collider.gameObject;
            ExecuteEvents.ExecuteHierarchy(target, eventData, ExecuteEvents.pointerClickHandler);
            _onObjectClicked.Invoke(target);
        }

        bool IsInsideAMask(Vector2 screenPoint)
        {
            foreach (Mask3D mask in _masks)
            {
                if (mask != null && mask.IsVisible && mask.Rect.ContainsScreenPoint(screenPoint, _uiCamera)) return true;
            }
            return false;
        }
    }
}
