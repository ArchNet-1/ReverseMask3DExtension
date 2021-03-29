using ArchNet.Extension.Renderer;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ArchNet.Extension.ReverseMask3D
{
    /// <summary>
    /// [EXTENSION] - [ARCH NET] - [REVERSE MASK 3D] Reverse Mask 3D Extension Controller
    /// author : LOUIS PAKEL
    /// </summary>
    public class ReverseMaskController3D : MonoBehaviour, IPointerClickHandler
    {
        #region Serialized Fields 

        [Header("MASKER")]
        [SerializeField] private RectTransform _background;
        [SerializeField] private CanvasGroup _masker;

        [Header("RAYCASTER")]
        [SerializeField] private GraphicRaycaster _raycaster = null;

        #endregion

        #region Private Fields

        private List<Mask3D> _masks = new List<Mask3D>();

        #endregion

        #region Public  Methods

        #region CRUD Mask

        /// <summary>
        /// Description : add mask 
        /// </summary>
        /// <param name="pMask"></param>
        public void AddMask(Mask3D pMask)
        {
            if (_masks.Count == 0)
            {
                _masks.Add(pMask);
            }
            if (false == IsInList(pMask))
            {
                _masks.Add(pMask);
            }
        }

        /// <summary>
        /// Description : remove mask
        /// </summary>
        /// <param name="pMask"></param>
        public void RemoveMask(Mask3D pMask)
        {
            if(true == IsInList(pMask))
            {
                _masks.Remove(pMask);
            }
        }

        /// <summary>
        /// Description : Check if a mask in already in the list
        /// </summary>
        /// <param name="pMask"></param>
        /// <returns></returns>
        public bool IsInList(Mask3D pMask)
        {
            bool lResult = false;

            foreach (Mask3D lMask in _masks)
            {
                if (lMask.GetId() == pMask.GetId())
                {
                    lResult = true;
                }
            }

            return lResult;
        }

        #endregion

        #region Getter

        /// <summary>
        /// Description : return mask from the list
        /// </summary>
        /// <param name="pId"></param>
        /// <returns></returns>
        public Mask3D GetMask(int pId)
        {
            Mask3D lResult = null;

            foreach (Mask3D lMask in _masks)
            {
                if(lMask.GetId() == pId)
                {
                    lResult = lMask;
                }
            }

            return lResult;
        }

        /// <summary>
        /// Description : Hide masker
        /// </summary>
        public void HideMasker()
        {
            GetMasker().alpha = 0f;
            GetMasker().interactable = false;
            GetMasker().blocksRaycasts = false;
        }

        /// <summary>
        /// Description : Show masker
        /// </summary>
        public void ShowMasker()
        {
            GetMasker().alpha = 1f;
            GetMasker().interactable = true;
            GetMasker().blocksRaycasts = true;
        }

        /// <summary>
        /// Description : retrun masker
        /// </summary>
        /// <returns></returns>
        private CanvasGroup GetMasker()
        {
            return _masker;
        }

        #endregion

        public void OnPointerClick(PointerEventData eventData)
        {
            List<RaycastResult> results = new List<RaycastResult>();

            _raycaster.Raycast(eventData, results);

            if (true == IsInMask(eventData))
            {
                foreach (RaycastResult result in results)
                {
                    // DO SOMETHING
                }
            }
        }

        #endregion

        #region Private Methods


        /// <summary>
        /// Description : Check if the event click is on a mask
        /// </summary>
        /// <param name="eventData"></param>
        /// <returns></returns>
        private bool IsInMask(PointerEventData eventData)
        {
            bool lResult = false;

            foreach (Mask3D lMask in _masks)
            {
                if (true == RendererExtension.IsInRectTransform(lMask.GetRect(), eventData.position))
                {
                    lResult = true;
                }
            }

            return lResult;
        }

        #endregion
    }
}
