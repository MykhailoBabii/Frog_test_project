using System;
using Core;
using UnityEngine;

namespace Game.Field
{
    public class WalkPlace : MonoBehaviour, ITap
    {
        public bool IsBlockTap { get; private set; }
        private Action<Vector2> _onTapAction;


        public void InitOnTap(Action<Vector2> action)
        {
            _onTapAction = action;
        }

        public void OnTap(Vector2 vector)
        {
            _onTapAction?.Invoke(vector);
        }

        public void OnUntap(Vector2 vector)
        {

        }
    }
}
