using UnityEngine;

namespace ArchNet.Extension.ReverseMask3D
{
    /// <summary>
    /// [EXTENSION] - [ARCH NET] - [REVERSE MASK 3D] Mask 3D Model for Reverse Mask 3D Extension
    /// author : LOUIS PAKEL
    /// </summary>
    public class Mask3D : MonoBehaviour
    {
        #region Serialized Fields 

        [SerializeField] private CanvasGroup _canvas;
        [SerializeField] private RectTransform _rect = null;

        #endregion

        #region Private Fields

        private int _id;
        private bool _isCopy = false;

        #endregion


        #region Public Methods

        /// <summary>
        /// Description : Hide mask
        /// </summary>
        public void Hide()
        {
            _canvas.alpha = 0f;
            _canvas.interactable = false;
            _canvas.blocksRaycasts = false;
        }

        /// <summary>
        /// Description : Show mask
        /// </summary>
        public void Show()
        {
            _canvas.alpha = 1f;
            _canvas.interactable = true;
            _canvas.blocksRaycasts = true;
        }

        #endregion

        #region Getter

        /// <summary>
        /// Description : get rect
        /// </summary>
        public RectTransform GetRect()
        {
            return _rect;
        }

        /// <summary>
        /// Description : get canvas group
        /// </summary>
        public CanvasGroup GetCanvas()
        {
            return _canvas;
        }

        public int GetId()
        {
            return _id;
        }

        public bool IsACopy()
        {
            return _isCopy;
        }

        #endregion

        #region Setter

        public void SetIsACopy(bool pCopy)
        {
            _isCopy = pCopy;
        }

        public void SetId(int pId)
        {
            _id = pId;
        }

        #endregion


        #region Private Methods

        /// <summary>
        /// Description : Init Mask
        /// </summary>
        public void InitMask()
        {
            if(GetComponent<CanvasGroup>() == null)
            {
                gameObject.AddComponent<CanvasGroup>();
            }

            if (_canvas == null)
            {
                _canvas = GetComponent<CanvasGroup>();
            }

            if (_rect == null)
            {
                _rect = GetComponent<RectTransform>();
            }
        }

        #endregion
    }
}