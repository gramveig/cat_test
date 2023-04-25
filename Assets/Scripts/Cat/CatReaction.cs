using UnityEngine;

namespace Cat
{
    [CreateAssetMenu(menuName = "Cat Reactions/Create")]
    public class CatReaction : ScriptableObject
    {
        [SerializeField]
        private string _reaction;

        public string Reaction => _reaction;
    }
}