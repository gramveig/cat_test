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
        private Image _image;
        
        private CatManager _catManager;
        private CatReaction _curReaction;

        public void Init(CatManager catManager)
        {
            _catManager = catManager;
        }
        
        public void Play()
        {
            _curReaction = _playBehaviour.catReaction;
            _catManager.ChangeMood(_playBehaviour.moodChange);
        }

        public void Feed()
        {
            _curReaction = _feedBehaviour.catReaction;
            _catManager.ChangeMood(_feedBehaviour.moodChange);
        }

        public void Pet()
        {
            _curReaction = _petBehaviour.catReaction;
            _catManager.ChangeMood(_petBehaviour.moodChange);
        }

        public void Kick()
        {
            _curReaction = _kickBehaviour.catReaction;
            _catManager.ChangeMood(_kickBehaviour.moodChange);
        }

        public CatReaction Reaction => _curReaction;
        public Color Color => _color;
    }
}