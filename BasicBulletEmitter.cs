using UnityEngine;

public class BasicBulletEmitter : MonoBehaviour {

    public int emissors = 1;
    public int pulse = 0;
    private int shotsSinceLastPause = 0;
    private float angle = Angles.threeQuarters;
    public float speed = 0.25f;
    public float timeBetweenBullets = 0.1f;
    private float pauseTime = 0.5f;
    private float lastPause = 0f;
    private float lastShot = 0f;
    private Vector2 direction;
    private ObjectPool bulletPool;
    public bool rotating = false;
    private int totalShots = 102400;
    private int shotsDone = 0;
    public float rotatingSpeed = Mathf.PI / 16;

    public void Awake() {
        direction = Vector2.down;
        bulletPool = GameState.GetInstance().GetBasicBulletPool();
    }

    public void Rotate(float speed) {
        rotating = true;
        rotatingSpeed = speed;
    }

    public void StopRotating() {
        rotating = true;
        rotatingSpeed = 0f;
    }

    private void Update() {
        if (pulse > 0 && Time.time - lastPause < pauseTime) {
            return;
        }

        if (Time.time - lastShot > timeBetweenBullets && shotsDone < totalShots) {
            lastShot = Time.time;

            var increment = 2 * Mathf.PI / emissors;

            for (var i = 0; i < emissors; i++) {
                var shot = bulletPool.RetrieveNext();
                direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * speed;
                shot.transform.position = transform.position;
                var sb = shot.GetComponent<StraightBullet>();
                sb.speed = speed;
                sb.direction = direction;
                angle += increment;
            }
            
            // One shot per round of emissors.
            shotsDone++;
            if (pulse > 0) {
                shotsSinceLastPause++;
                if (shotsSinceLastPause == pulse) {
                    shotsSinceLastPause = 0;
                    lastPause = Time.time;
                }
            }

            if (rotating) {
                angle += rotatingSpeed;
            }
        }
    }
}
