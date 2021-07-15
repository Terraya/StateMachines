using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Script to Load Additional Scenes on Scene Load, only in EDITOR! Doesnt work in build mode
/// </summary>
public class EditorInitializationLoader : MonoBehaviour
{
#if UNITY_EDITOR
    public GameSceneSO[] scenesToLoad;

    private void Start()
    {
        for (int i = 0; i < SceneManager.sceneCount; ++i)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            for (int j = 0; j < scenesToLoad.Length; ++j)
                if (scene.path == scenesToLoad[j].scenePath)
                {
                    return;
                }
                else
                {
                    SceneManager.LoadSceneAsync(scenesToLoad[j].scenePath, LoadSceneMode.Additive);
                }
        }
    }
#endif
}