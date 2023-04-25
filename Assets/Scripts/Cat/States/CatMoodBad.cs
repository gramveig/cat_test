namespace Cat.States
{
    public class CatMoodBad : CatMood
    {
        public CatMoodBad(Cat cat)
        {
            Cat = cat;
        }
        
        public override void Play()
        {
        }

        public override void Feed()
        {
            Cat.ChangeMoodToBetter();
        }

        public override void Pet()
        {
        }

        public override void Kick()
        {
        }
    }
}