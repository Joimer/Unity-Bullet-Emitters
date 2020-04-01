using UnityEngine;

public class StraightBullet : MonoBehaviour {

    public float speed;
    [HideInInspector]
    public Vector2 direction;
    public bool active = true;
    private SpriteRenderer sr;

    private void Awake() {
        sr = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate() {
        if (active) {
            transform.Translate(direction * speed);
        }
    }

    private void Update() {
        if (!sr.isVisible) {
            active = false;
            GameState.GetInstance().GetBasicBulletPool().ReturnToPool(gameObject);
        }
    }
}
