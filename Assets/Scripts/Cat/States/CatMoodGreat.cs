namespace Cat.States
{
    public class CatMoodGreat : CatMood
    {
        public CatMoodGreat(Cat cat)
        {
            Cat = cat;
        }
        
        public override void Play()
        {
        }

        public override void Feed()
        {
        }

        public override void Pet()
        {
        }

        public override void Kick()
        {
            Cat.ChangeMoodToWorst();
        }
    }
}