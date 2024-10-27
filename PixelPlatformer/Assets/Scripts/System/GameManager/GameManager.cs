using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace PixelPlatformer
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField, ReadOnly] private GameState _gameState;

        private readonly List<IGameListener>       _gameListeners = new();
        private readonly List<IGameUpdateListener> _gameUpdateListeners = new();

        private void Awake()
        {
            _gameState = GameState.Off;
            
            IGameListener.onRegister += AddListener;
        }

        private void OnDestroy()
        {
            _gameState = GameState.Finish;
            IGameListener.onRegister -= AddListener;
        }
        
        private void Update()
        {
            if (_gameState != GameState.Start)
            {
                return;
            }

            var deltaTime = Time.deltaTime;
            for (var i = 0; i < _gameUpdateListeners.Count; i++)
            {
                _gameUpdateListeners[i].OnUpdate(deltaTime);
            }
        }

        private void AddListener(IGameListener gameListener)
        {
            _gameListeners.Add(gameListener);
            
            if (gameListener is IGameUpdateListener gameUpdateListener)
            {
                _gameUpdateListeners.Add(gameUpdateListener);
            }
        }
        
        [Button]
        public void StartGame()
        {
            foreach (var gameListener in _gameListeners)
            {
                if (gameListener is IGameStartListener gameStartListener)
                {
                    gameStartListener.OnStartGame();
                }
            }

            _gameState = GameState.Start;
            Debug.Log("OnStartGame");
        }
        
        [Button]
        public void FinishGame()
        {
            foreach (var gameListener in _gameListeners)
            {
                if (gameListener is IGameFinishListener gameFinishListener)
                {
                    gameFinishListener.OnFinishGame();
                }
            }
            
            _gameState = GameState.Finish;
            Debug.Log("OnFinishGame");
        }
        
        [Button]
        public void PauseGame()
        {
            foreach (var gameListener in _gameListeners)
            {
                if (gameListener is IGamePauseListener gamePauseListener)
                {
                    gamePauseListener.OnPauseGame();
                }
            }
            
            _gameState = GameState.Pause;
            Debug.Log("OnPauseGame");
        }   
        
        [Button]
        public void ResumeGame()
        {
            foreach (var gameListener in _gameListeners)
            {
                if (gameListener is IGameResumeListener gameResumeListener)
                {
                    gameResumeListener.OnResumeGame();
                }
            }
            _gameState = GameState.Resume;
            Debug.Log("OnResumeGame");
        }
    }
}