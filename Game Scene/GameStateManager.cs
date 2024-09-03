using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Course_Library.Scripts {
    public enum GameState {
        Playing,
        Paused,
        GameOver
    }

    public class GameStateManager : MonoBehaviour {
        public static GameStateManager Instance { get; private set; }

        public void Awake() {
            Instance = this;
            Time.timeScale = 1;
        }

        public GameState CurrentGameState { get; private set; } = GameState.Playing;

        public void Pause() {
            if (CurrentGameState != GameState.Playing) return;
            Time.timeScale = 0;
            CurrentGameState = GameState.Paused;
        }

        public void Resume() {
            if (CurrentGameState != GameState.Paused) return;
            Time.timeScale = 1;
            CurrentGameState = GameState.Playing;
        }

        public void Restart() {
            if (CurrentGameState is not (GameState.Paused or GameState.GameOver)) return;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            CurrentGameState = GameState.Playing;
            Time.timeScale = 1;
        }

        public void GameOver() {
            if (CurrentGameState != GameState.Playing) return;
            Time.timeScale = 0;
            CurrentGameState = GameState.GameOver;
        }
    }
}