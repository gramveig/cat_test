using UniRx;

namespace Cat
{
    public class CatModel
    {
        public ReactiveProperty<int> Mood;
        public int MaxMood { get; internal set; }
        public ReactiveProperty<string> Reaction;

        public CatModel(int curMood, int maxMood)
        {
            MaxMood = maxMood;
            Mood = new ReactiveProperty<int>(curMood);
            Reaction = new ReactiveProperty<string>(string.Empty);
        }
    }
}