using UnityEngine;

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
        
        private Cat _cat;
        private CatReaction _curReaction;

        public void Init(Cat cat)
        {
            _cat = cat;
        }
        
        public void Play()
        {
            _curReaction = _playBehaviour.catReaction;
            _cat.ChangeMood(_playBehaviour.moodChange);
        }

        public void Feed()
        {
            _curReaction = _feedBehaviour.catReaction;
            _cat.ChangeMood(_feedBehaviour.moodChange);
        }

        public void Pet()
        {
            _curReaction = _petBehaviour.catReaction;
            _cat.ChangeMood(_petBehaviour.moodChange);
        }

        public void Kick()
        {
            _curReaction = _kickBehaviour.catReaction;
            _cat.ChangeMood(_kickBehaviour.moodChange);
        }

        public CatReaction Reaction => _curReaction;
        public Color Color => _color;
    }
}