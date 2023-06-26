using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TVP
{
    public class MonoSinglethon<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        #region Properties 
        public static T CurrentGame
        {
            get
            {
                if (_instance != null)
                    return _instance;
                else
                {
                    T[] findedObjects = FindObjectsOfType<T>();

                    // Create singleton.
                    if (findedObjects.Length == 0)
                        return _instance = new GameObject(string.Format("{0}", typeof(T).ToString())).AddComponent<T>();

                    // Return singleton.
                    if (findedObjects.Length == 1)
                        return _instance = findedObjects[0];

                    throw new System.Exception($"Scene have more than one components of <{typeof(T)}> type");
                }
            }
        }
        #endregion

        protected virtual void Awake() => _instance = GetComponent<T>();
    }
}