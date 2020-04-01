using UnityEngine;

public class GameState : MonoBehaviour {

    // Game values
    public int score;
    private static GameState instance;

    // One big object pool for bullets.
    private ObjectPool basicBulletPool;

    // Music value
    public static float sfxVolume = 1f;
    public static float musicVolume = 1f;

    // Other stuff
    public static bool isGameLocked = false;

    public static GameState GetInstance() {
        if (instance == null) {
            instance = new GameObject("Game State Manager").AddComponent<GameState>();
            // This would be a 2D game object that has a triggered hitbox.
            var bullet = Resources.Load<GameObject>("Prefabs/Fireball");
            instance.basicBulletPool = new ObjectPool(bullet, 4196);
        }
        return instance;
    }

    public ObjectPool GetBasicBulletPool() {
        return basicBulletPool;
    }
}
