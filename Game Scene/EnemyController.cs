using UnityEngine;

namespace Course_Library.Scripts {
    public class EnemyController : MonoBehaviour {
        private GameObject _player;

        private Rigidbody _enemyRb;

        public float enemySpeed;

        public void Init(GameObject player) {
            this._player = player;
        }

        private void Awake() {
            _enemyRb = this.GetComponent<Rigidbody>();
        }

        private void Update() {
            _enemyRb.AddForce((_player.transform.position - this.transform.position).normalized * (enemySpeed * Time.deltaTime),
                             ForceMode.Force);
            
            DestroyPlayerIfOutOfBounds();
        }
        
        private void DestroyPlayerIfOutOfBounds() {
            if (this.transform.position.y < -10) {
                Destroy(this.gameObject);
            }
        }
    }
}