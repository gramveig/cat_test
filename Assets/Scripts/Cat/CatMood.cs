namespace Cat
{
    public abstract class CatMood
    {
        public virtual void Start()
        {
        }

        public abstract void Play();
        public abstract void Feed();
        public abstract void Pet();
        public abstract void Kick();
    }
}