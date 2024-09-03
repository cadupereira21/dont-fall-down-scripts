using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Course_Library.Scripts {
    public class PauseMenu : MonoBehaviour {
        [SerializeField] private GameObject pauseMenu;

        private void Awake() {
            pauseMenu.SetActive(false);
        }

        private void Update() {
            if (!Input.GetKeyDown(KeyCode.Escape)) return;
            if (GameStateManager.Instance.CurrentGameState == GameState.Paused) {
                Resume();
            }
            else {
                Pause();
            }
        }

        private void Pause() {
            GameStateManager.Instance.Pause();
            pauseMenu.SetActive(true);
        }

        public void Resume() {
            GameStateManager.Instance.Resume();
            pauseMenu.SetActive(false);
        }

        public void Restart() {
            GameStateManager.Instance.Restart();
        }
    }
}