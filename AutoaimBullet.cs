using UnityEngine;

public class AutoaimBullet : MonoBehaviour {

    public GameObject target;
    public float speed;
    [HideInInspector]
    public Vector2 direction;
    public bool active = true;
    private SpriteRenderer sr;

    private void Awake() {
        sr = GetComponent<SpriteRenderer>();
        direction = Vector2.up;
    }

    private void FixedUpdate() {
        if (!target || !target.activeSelf) {
            return;
        }
        if (active && target) {
            direction = (target.transform.position - transform.position).normalized;
        }
        transform.Translate(direction * speed);
    }

    private void Update() {
        if (!sr.isVisible) {
            active = false;
            GameState.GetInstance().GetBasicBulletPool().ReturnToPool(gameObject);
        }
    }

    // The level player, game state, player control, etc. should set the target.
    // How to achieve that is up to you.
    private void SetTarget(GameObject target) {
        target = target;
    }
}
