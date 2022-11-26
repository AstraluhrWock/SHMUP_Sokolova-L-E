using System.Collections.Generic;
using UnityEngine;


namespace SHRUM.ServiceLocator
{
    public static class ServiceLocatorMonoBehaviour 
    {
        private static readonly Dictionary<object, object> _serviceContainer;

        static ServiceLocatorMonoBehaviour()
        {
            _serviceContainer = new Dictionary<object, object>();
        }

        public static T GetService<T>(bool createObjectIfNotFound = true) where T : Object
        {
            if (!_serviceContainer.ContainsKey(typeof(T)))
            {
                return FindService<T>(createObjectIfNotFound);
            }

            var service = (T)_serviceContainer[typeof(T)];
            if (service != null)
            {
                return service;
            }
            _serviceContainer.Remove(typeof(T));
            return FindService<T>(createObjectIfNotFound);
        }

        private static T FindService<T>(bool createObjectIfNotFound = true) where T : Object
        {
            T type = Object.FindObjectOfType<T>();
            if (type != null)
            {
                _serviceContainer.Add(typeof(T), type);
            }
            else if (createObjectIfNotFound)
            {
                var go = new GameObject(typeof(T).Name, typeof(T));
                _serviceContainer.Add(typeof(T), go.GetComponent<T>());
            }
            return (T)_serviceContainer[typeof(T)];
        }
    }
}
