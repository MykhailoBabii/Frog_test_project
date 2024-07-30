using System.Collections.Generic;
using Game.Field;
using UnityEngine;

namespace Game.Frog
{
    public class FrogView : MonoBehaviour
    {
        [SerializeField] private FrogMoveController _frogMoveController;
        [SerializeField] private List<GameObject> _frontLiyers;
        [SerializeField] private List<GameObject> _backLiyers;

        void Awake()
        {
            _frogMoveController.InitOnYDirection(ResolveViewState);
        }

        private void ResolveViewState(bool isMoveTopDirection)
        {
            if(isMoveTopDirection)
            {
                SetBackView();
            }

            else
            {
                SetFrontView();
            }
        }

        [ContextMenu("ShowFront")]
        public void SetFrontView()
        {
            _frontLiyers.ForEach(obj => obj.SetActive(true));
            _backLiyers.ForEach(obj => obj.SetActive(false));
        }
        
        [ContextMenu("ShowBack")]
        public void SetBackView()
        {
            _backLiyers.ForEach(obj => obj.SetActive(true));
            _frontLiyers.ForEach(obj => obj.SetActive(false));
        }
    }
}


