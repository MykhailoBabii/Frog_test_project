using System;
using DG.Tweening;
using Game.Item;
using UnityEngine;

namespace Game.Field
{
    public class FrogMoveController : MonoBehaviour
    {
        [SerializeField] private WalkPlace _walkPlace;
        [SerializeField] private float _moveTimePerUnit;
        private Tweener _tweener;
        private Action _onStartWalk;
        private Action _onEndWalk;
        private Action<bool> _onMoveTopAction;

        void Awake()
        {
            _walkPlace.InitOnTap(OnTapToMove);
        }

        public void InitOnWalkActions(Action onStartWalk, Action onEndWalk)
        {
            _onStartWalk = onStartWalk;
            _onEndWalk = onEndWalk;
        }

        public void InitOnYDirection(Action<bool> onMoveTopAction)
        {
            _onMoveTopAction = onMoveTopAction;
        }

        private void OnTapToMove(Vector2 vector)
        {
            _onStartWalk?.Invoke();
            _onMoveTopAction?.Invoke(vector.y > transform.position.y);
            var difference = Vector2.Distance(transform.position, vector);
            var moveTime = difference * _moveTimePerUnit;
            _tweener = transform.DOMove(vector, moveTime)
            .OnComplete(OnStop);
        }

        private void OnStop()
        {
            _tweener?.Kill();
            _onEndWalk?.Invoke();
            _onMoveTopAction?.Invoke(false);
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent<IReflexed>(out var item))
            {
                item.OnEnter();
                OnStop();
            }
        }

        void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent<IReflexed>(out var item))
            {
                item.OnExit();
            }
        }
    }
}
