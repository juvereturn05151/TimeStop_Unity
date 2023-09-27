using UnityEngine;
using UnityEngine.SceneManagement;

namespace JuveProduction.Generic
{
    public class CoreGame : PrefabSingleton<CoreGame>
    {
        public SceneType _currentGameScene { private set; get; }

        public override void OnDestroy()
        {
            base.OnDestroy();
        }

        protected override void Init() 
        {
            base.Init();

            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        public void SetCurrentGameScene(SceneType sceneType) 
        {
            _currentGameScene = sceneType;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.name == "PregameScene")
            {
                _currentGameScene = SceneType.PreGameScene;
            }
            else 
            {
                _currentGameScene = SceneType.GameScene;
            }

            if (_currentGameScene == SceneType.GameScene) 
            {
                
            }
        }
    }
}