namespace Cat.States
{
    public class CatMoodGood : CatMood
    {
        public CatMoodGood(Cat cat)
        {
            Cat = cat;
        }
        
        public override void Play()
        {
            Cat.ChangeMoodToBetter();
        }

        public override void Feed()
        {
            Cat.ChangeMoodToBetter();
        }

        public override void Pet()
        {
            Cat.ChangeMoodToBetter();
        }

        public override void Kick()
        {
            Cat.ChangeMoodToWorst();
        }
    }
}