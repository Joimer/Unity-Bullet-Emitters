using UnityEngine;

public class AimedBulletShooter : MonoBehaviour {

    private ObjectPool bulletPool;
    private GameObject target;
    private bool active = false;
    private float speed = 0.06f;
    private float timeBetweenBullets = 0.33f;
    private float lastShot = 0f;
    private const float radians = 5 * Mathf.Deg2Rad;

    private void Awake() {
        bulletPool = GameState.GetInstance().GetBasicBulletPool();
        Activate();
    }

    public void Activate() {
        active = true;
    }

    private void Update() {
        if (active && Time.time - lastShot > timeBetweenBullets) {
            lastShot = Time.time;

            var direction = Vector2.down;
            if (target != null) {
                direction = (target.transform.position - transform.position).normalized;
            }
            var degreesUp = new Vector2(
                direction.x * Mathf.Cos(radians) - direction.y * Mathf.Sin(radians),
                direction.x * Mathf.Sin(radians) + direction.y * Mathf.Cos(radians)
            );
            var degreesDown = new Vector2(
                direction.x * Mathf.Cos(-radians) - direction.y * Mathf.Sin(-radians),
                direction.x * Mathf.Sin(-radians) + direction.y * Mathf.Cos(-radians)
            );
            ShootBulletTowards(direction);
            ShootBulletTowards(degreesUp);
            ShootBulletTowards(degreesDown);
        }
    }

    private void ShootBulletTowards(Vector2 direction) {
        var shot = bulletPool.RetrieveNext();
        shot.transform.position = transform.position;
        var sb = shot.GetComponent<StraightBullet>();
        sb.speed = speed;
        sb.direction = direction;
    }
}
