using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneTransition
{
    /// <summary>
    /// This class is used to transition between scenes. This includes triggering all the things that need to happen on transition such as data persistence.
    /// </summary>
    public class SceneController : MonoBehaviour
    {
        public static SceneController Instance
        {
            get
            {
                if (_instance != null)
                    return _instance;

                _instance = FindObjectOfType<SceneController>();

                if (_instance != null)
                    return _instance;

                Create();

                return _instance;
            }
        }

        private static SceneController _instance;

        public static SceneController Create()
        {
            GameObject sceneControllerGameObject = new GameObject("SceneController");
            _instance = sceneControllerGameObject.AddComponent<SceneController>();

            return _instance;
        }

        void Awake()
        {
            if (Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);
        }

        public static void TransitionToScene(TransitionPoint transitionPoint)
        {
            Instance.StartCoroutine(Instance.Transition(transitionPoint));
        }

        protected IEnumerator Transition(TransitionPoint transitionPoint)
        {
            Scene currentScene = SceneManager.GetActiveScene();

            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(transitionPoint.NewSceneName, LoadSceneMode.Additive);
            while (!asyncLoad.isDone)
            {
                Debug.Log("Loading scene " + " [][] Progress: " + asyncLoad.progress);
                yield return null;
            }

            GameObject player = GameObject.Find("Player");
            SceneManager.MoveGameObjectToScene(player, SceneManager.GetSceneByName(transitionPoint.NewSceneName));
            Transform entranceLocation = GetDestination(transitionPoint.TransitionDestinationTag).transform;
            Transform enteringTransform = player.transform;
            enteringTransform.position = entranceLocation.position;
            enteringTransform.rotation = entranceLocation.rotation;
            SceneManager.UnloadSceneAsync(currentScene);
            
//            if(entrance != null)
//                entrance.OnReachDestination.Invoke();
        }

        protected TransitionDestination GetDestination(DestinationTag destinationTag)
        {
            TransitionDestination[] entrances = FindObjectsOfType<TransitionDestination>();
            for (int i = 0; i < entrances.Length; i++)
            {
                if (entrances[i].DestinationTag == destinationTag)
                    return entrances[i];
            }

            Debug.LogWarning("No entrance was found with the " + destinationTag + " tag.");
            return null;
        }
    }
}