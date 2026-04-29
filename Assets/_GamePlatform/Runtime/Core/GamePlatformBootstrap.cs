using UnityEngine;

namespace GamePlatform.Runtime.Core
{
    public sealed class GamePlatformBootstrap : MonoBehaviour
    {
        private static bool bootstrapped;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Bootstrap()
        {
            if (bootstrapped)
                return;

            bootstrapped = true;

            GameObject bootstrapObject = new GameObject(nameof(GamePlatformBootstrap));
            DontDestroyOnLoad(bootstrapObject);
            bootstrapObject.AddComponent<GamePlatformBootstrap>();

            GamePlatform.Initialize();
        }

        private void Awake()
        {
            GamePlatform.Initialize();
        }
    }
}
