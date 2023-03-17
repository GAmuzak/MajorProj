using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities
{
    public class SingletonMonoBehavior<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;
        private static bool _isLoaded = false;

        public static T Instance
        {
            get
            {
                if (!_isLoaded)
                {
                    _instance = FindObjectOfType<T>();
                    _isLoaded = _instance != null;
                }
                return _instance;
            }
        }

        protected virtual void Awake()
        {
            
            if (FindObjectOfType<T>() != null && FindObjectOfType<T>() != this)
            {
                Destroy(this.gameObject);
            }
            DontDestroyOnLoad(this);
        }
    }
}

