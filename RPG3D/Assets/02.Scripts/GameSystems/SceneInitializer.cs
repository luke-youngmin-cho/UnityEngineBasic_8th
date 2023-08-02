using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RPG.GameSystems
{
    public class SceneInitializer : MonoBehaviour
    {
        public static bool isInitialized;
        [SerializeField] private List<GameObject> _needToBeAwaken;

        private void Awake()
        {
            foreach (var item in _needToBeAwaken)
            {
                if (item.activeSelf == false)
                {
                    item.SetActive(true);
                    item.SetActive(false);
                }
            }

            SceneManager.sceneUnloaded -= ResetFlag;
            SceneManager.sceneUnloaded += ResetFlag;
            isInitialized = true;
        }

        private void ResetFlag(Scene scene)
        {
            isInitialized = false;
        }

    }
}