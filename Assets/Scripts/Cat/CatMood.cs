using UnityEngine;
using UnityEngine.UI;

namespace Cat
{
    [CreateAssetMenu(menuName = "Cat Moods/Create")]
    public class CatMood : ScriptableObject
    {
        [SerializeField]
        private CatBehaviour _playBehaviour;
        [SerializeField]
        private CatBehaviour _feedBehaviour;
        [SerializeField]
        private CatBehaviour _petBehaviour;
        [SerializeField]
        private CatBehaviour _kickBehaviour;

        [SerializeField]
        private Color _color;

        [SerializeField]
        private GameObject _imagePrefab;
        
        private CatManager _catManager;

        public void Init(CatManager catManager)
        {
            _catManager = catManager;
        }
        
        public void Play()
        {
            _catManager.SetReaction(_playBehaviour.catReaction);
            _catManager.ChangeMood(_playBehaviour.moodChange);
        }

        public void Feed()
        {
            _catManager.SetReaction(_feedBehaviour.catReaction);
            _catManager.ChangeMood(_feedBehaviour.moodChange);
        }

        public void Pet()
        {
            _catManager.SetReaction(_petBehaviour.catReaction);
            _catManager.ChangeMood(_petBehaviour.moodChange);
        }

        public void Kick()
        {
            _catManager.SetReaction(_kickBehaviour.catReaction);
            _catManager.ChangeMood(_kickBehaviour.moodChange);
        }

        public Color Color => _color;
        public GameObject ImagePrefab => _imagePrefab;
    }
}