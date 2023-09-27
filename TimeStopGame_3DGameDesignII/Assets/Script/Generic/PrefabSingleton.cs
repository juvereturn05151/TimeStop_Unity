using UnityEngine;

namespace JuveProduction.Generic
{
    // Not encourage to use this class, try to use MonoSingleton instead
    public abstract class PrefabSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance => GetInstance();

        public static bool HasInstance => _instance != null;

        private static bool _isQuitting = false;

        private static T _instance = null;

        private const string _assetPathFormat = "Prefabs/MonoSingletons/{0}";

        public virtual void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }

            _instance = GetComponent<T>();

            DontDestroyOnLoad(this);
            _isQuitting = false;
            Init();
        }

        public virtual void OnDestroy()
        {
            if (_instance == this)
            {
                _instance = null;
                _isQuitting = true;
            }
        }

        private static T GetInstance()
        {
            if (_isQuitting)
            {
                return null;
            }

            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<T>();

                if (FindObjectsOfType(typeof(T)).Length > 1)
                {
                    return _instance;
                }

                if (_instance == null)
                {
                    Debug.Assert(Application.isPlaying, $"This must be call on runtime only !!!");

                    string className = typeof(T).ToString();
                    string path = string.Format(_assetPathFormat, className);
                    Debug.LogAssertion($"{typeof(T)} not exist, try load from [{path}]");

                    T singleton = Instantiate(Resources.Load<T>(path));
                    Debug.Assert(singleton != null, $"prefab {typeof(T)} not found");

                    _instance = singleton;
                    singleton.name = _instance.GetType().Name;
                }
            }

            return _instance;
        }

        protected virtual void Init() { }
    }
}