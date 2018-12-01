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
            Instance.StartCoroutine(Instance.Transition(transitionPoint.NewSceneName, transitionPoint.TransitionDestinationTag));
        }

        public static TransitionDestination GetDestinationFromTag(DestinationTag destinationTag)
        {
            return Instance.GetDestination(destinationTag);
        }

        protected IEnumerator Transition(string newSceneName, DestinationTag destinationTag)
        {
            yield return SceneManager.LoadSceneAsync(newSceneName);
            TransitionDestination entrance = GetDestination(destinationTag);
            SetEnteringGameObjectLocation(entrance);
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

        protected void SetEnteringGameObjectLocation(TransitionDestination entrance)
        {
            if (entrance == null)
            {
                Debug.LogWarning("Entering Transform's location has not been set.");
                return;
            }

            Transform entranceLocation = entrance.transform;
            Transform enteringTransform = entrance.TransitioningGameObject.transform;
            enteringTransform.position = entranceLocation.position;
            enteringTransform.rotation = entranceLocation.rotation;
        }
    }
}