using System.Collections.Generic;
using Cat.States;
using UnityEngine;

namespace Cat
{
    public class Cat
    {
        private CatMood _mood;
        private CatMood _moodBad;
        private CatMood _moodGood;
        private CatMood _moodGreat;
        private List<CatMood> _moodSeq;
        
        private void Awake()
        {
            _moodBad = new CatMoodBad(this);
            _moodGood = new CatMoodGood(this);
            _moodGreat = new CatMoodGreat(this);
            _moodSeq = new List<CatMood> { _moodBad, _moodGood, _moodGreat };

            _mood = _moodBad;
        }

        public void Play()
        {
            _mood.Play();
        }

        public void Feed()
        {
            _mood.Feed();
        }

        public void Pet()
        {
            _mood.Pet();
        }

        public void Kick()
        {
            _mood.Kick();
        }

        public void ChangeMoodToBetter()
        {
            int curMoodIdx = _moodSeq.IndexOf(_mood);
            if (curMoodIdx > _moodSeq.Count - 2)
            {
                Debug.LogError("Cat is already in the best mood");
                return;
            }

            ChangeMood(_moodSeq[curMoodIdx + 1]);
        }

        public void ChangeMoodToWorst()
        {
            ChangeMood(_moodSeq[0]);
        }

        private void ChangeMood(CatMood newMood)
        {
            _mood = newMood;
        }
    }
}