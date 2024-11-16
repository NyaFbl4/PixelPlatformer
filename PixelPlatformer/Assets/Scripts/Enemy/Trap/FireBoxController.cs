using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace PixelPlatformer
{ 
    public class FireBoxController : MonoBehaviour
    {
        [SerializeField] private GameObject _fire;
        [SerializeField] private Animator _animator;

        private enum FireState  { Off, On}
        private FireState _currentState = FireState.Off;
        private float _fireDuration = 2f;
        private float _fireTimer;

        private void Start()
        {
            _animator = GetComponentInChildren<Animator>();
            SetFireState(FireState.Off);
        }

        private void Update()
        {
            if (_currentState == FireState.On)
            {
                _fireTimer -= Time.deltaTime;

                if (_fireTimer <= 0)
                {
                    SetFireState(FireState.Off);
                }
            }
        }

        [Button]
        public void TurnOnFire()
        {
            if (_currentState == FireState.Off)
            {
                SetFireState(FireState.On);
            }
            
            Debug.Log("+++");
        }

        private void SetFireState(FireState state)
        {
            _currentState = state;

            switch (state)
            {
                case FireState.Off:
                    _fire.SetActive(false);
                    _animator.SetBool("IsFire", false); // Предполагается, что в аниматоре есть этот параметр
                    break;

                case FireState.On:
                    _fire.SetActive(true);
                    _animator.SetBool("IsFire", true); // Включаем анимацию
                    _fireTimer = _fireDuration; // Сбрасываем таймер
                    break;
            }
        }
    }
}