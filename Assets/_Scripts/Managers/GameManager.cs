using System;
using System.Collections;
using _Scripts.Entities;
using _Scripts.Intermediaries;
using _Scripts.PlayerControls;
using _Scripts.ScriptableObjects;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using Steamworks;

namespace _Scripts.Manager
{
    public class GameManager : MonoBehaviour
    {
        #region Variables

        public static GameManager Instance;

        public GameState GameState
        {
            get => _gameState;
            set
            {
                OnGameStateChange?.Invoke(value);
                _gameState = value;
            }
        }
        private GameState _gameState;

        #endregion

        #region Action Events

        public event Action<GameState> OnGameStateChange;

        #endregion

        #region Unity Callback Functions

        private void Awake()
        {
            Instance = this;
            GameState = GameState.Gameplay;
        }

        #endregion
    }
    
    public enum GameState
    {
        Gameplay,
        UI
    }
}