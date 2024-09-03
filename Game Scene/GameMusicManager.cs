using System;
using UnityEngine;

namespace Course_Library.Scripts.Game_Scene {
    public class GameMusicManager : MonoBehaviour {
        [SerializeField] private AudioSource cameraAudioSource;

        private void Update() {
            if (GameStateManager.Instance.CurrentGameState == GameState.GameOver) {
                if (cameraAudioSource.isPlaying) cameraAudioSource.Stop();
            }
            else {
                if (!cameraAudioSource.isPlaying) cameraAudioSource.Play();
            }
        }
    }
}
