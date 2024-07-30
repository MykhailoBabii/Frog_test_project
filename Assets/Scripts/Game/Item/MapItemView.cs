using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;

namespace Game.Item
{
    public interface IReflexed
    {
        void OnEnter();
        void OnExit();
    }

    public class MapItemView : MonoBehaviour, IReflexed, ITap
    {
        [SerializeField] private ParticleSystem _glowEffect;
        [SerializeField] private ParticleSystem _openEffect;
        [SerializeField] private GameObject _openItem;

        public bool IsBlockTap { get; private set; }

        public void OnEnter()
        {
            ShowEffect();
        }

        public void OnExit()
        {
            HideEffect();
        }

        public void SetOpenItem()
        {
            _openEffect.Play();
            _openItem.SetActive(true);
            IsBlockTap = true;
        }

        private void ShowEffect()
        {
            _glowEffect.Play();
        }

        private void HideEffect()
        {
            _glowEffect.Stop();
        }

        public void OnTap(Vector2 vector)
        {
            SetOpenItem();
        }

        public void OnUntap(Vector2 vector)
        {

        }
    }
}
