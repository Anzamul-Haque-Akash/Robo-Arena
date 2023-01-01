using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Arean
{
    public class LuluDelete : MonoBehaviour
    {
        private MeshRenderer _renderer;
        private MaterialPropertyBlock _block;
        private static readonly int Alpha = Shader.PropertyToID("_Alpha");

        private void Awake()
        {
            _renderer = GetComponent<MeshRenderer>();
            _block = new MaterialPropertyBlock();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                StartFading();
            }
        }

        private void StartFading()
        {
            DOVirtual.Float(1f, 0f, 1f, delegate(float value)
            {
                _renderer.GetPropertyBlock(_block);
                _block.SetFloat(Alpha, value);
                _renderer.SetPropertyBlock(_block);
            }).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
        }
    }
}
