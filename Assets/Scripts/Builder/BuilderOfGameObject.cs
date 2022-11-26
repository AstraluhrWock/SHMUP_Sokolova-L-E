using UnityEngine;

namespace SHRUM.Builder
{
    internal class BuilderOfGameObject 
    {
        protected GameObject _gameObject;

        public BuilderOfGameObject() => _gameObject = new GameObject();
        protected BuilderOfGameObject(GameObject gameObject) => _gameObject = gameObject;

        public GameObjectVisualBuilder Visual => new GameObjectVisualBuilder(_gameObject);
        public GameObjectPhysicsBuilder Physics => new GameObjectPhysicsBuilder(_gameObject);

        public static implicit operator GameObject(BuilderOfGameObject builder)
        {
            return builder._gameObject;
        }
    }
}