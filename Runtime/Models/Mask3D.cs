// ArchNet · Reverse Mask 3D Extension — hole
// A transparent area of the overlay: clicks inside it go through to the 3D scene.
// Register it with ReverseMaskController3D.AddMask.
// Docs: https://archnet-plateform.fr/#ReverseMask3DExtension

using UnityEngine;

namespace ArchNet.Extension
{
    [RequireComponent(typeof(RectTransform))]
    [AddComponentMenu("ArchNet/Reverse Mask 3D")]
    public class Mask3D : MonoBehaviour
    {
        [SerializeField] CanvasGroup _canvas;
        [SerializeField] RectTransform _rect;

        public RectTransform Rect => _rect != null ? _rect : _rect = (RectTransform)transform;
        public CanvasGroup Group => _canvas != null ? _canvas : _canvas = GetOrAddGroup();
        public bool IsVisible => Group.alpha > 0f;

        public void Show() => Group.SetVisible(true);
        public void Hide() => Group.SetVisible(false);

        CanvasGroup GetOrAddGroup() => TryGetComponent(out CanvasGroup group) ? group : gameObject.AddComponent<CanvasGroup>();
    }
}
