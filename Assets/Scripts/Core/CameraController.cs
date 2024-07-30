using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Core
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private Tilemap _tilemapRenderer;
        [Range(0f, 1f), SerializeField] private float _normalSize = 1f;

        [ContextMenu("Test")]
        void Awake()
        {
            SetCameraWight(_tilemapRenderer.size.x);
        }

        public void SetCameraWight(float spriteWidth)
        {
            float aspectRatio = _camera.aspect; // Співвідношення сторін камери
            float spriteHeight = spriteWidth / aspectRatio;

            _camera.orthographicSize = spriteHeight / 2 * _normalSize;
        }
    }
}
