using System;
using System.Collections.Generic;
using UnityEngine;

namespace Cat
{
    public class CatManager : MonoBehaviour
    {
        [SerializeField]
        private List<CatMood> _moodSeq;

        [SerializeField]
        private CatMood _startMood;

        private CatMood _curMood;

        private void Awake()
        {
            _curMood = _startMood;
            foreach (var mood in _moodSeq)
            {
                mood.Init(this);
            }
        }

        public void Play()
        {
            _curMood.Play();
        }

        public void Feed()
        {
            _curMood.Feed();
        }

        public void Pet()
        {
            _curMood.Pet();
        }

        public void Kick()
        {
            _curMood.Kick();
        }

        public void ChangeMood(CatMoodChange moodChange)
        {
            switch (moodChange)
            {
                case CatMoodChange.None: break;
                case CatMoodChange.ToWorst: ChangeMoodToWorst();
                    break;
                case CatMoodChange.ToWorse: ChangeMoodToWorse();
                    break;
                case CatMoodChange.ToBetter: ChangeMoodToBetter();
                    break;
                case CatMoodChange.ToBest: ChangeMoodToBest();
                    break;
                default: throw new Exception("Unknown mood change");
            }
        }

        private void ChangeMoodToWorst()
        {
            _curMood = _moodSeq[0];
        }

        private void ChangeMoodToWorse()
        {
            int curMoodIdx = _moodSeq.IndexOf(_curMood);
            if (curMoodIdx == 0)
            {
                return;
            }

            _curMood = _moodSeq[curMoodIdx - 1];
        }
        
        private void ChangeMoodToBetter()
        {
            int curMoodIdx = _moodSeq.IndexOf(_curMood);
            if (curMoodIdx > _moodSeq.Count - 2)
            {
                return;
            }

            _curMood = _moodSeq[curMoodIdx + 1];
        }

        private void ChangeMoodToBest()
        {
            _curMood = _moodSeq[^1];
        }
    }
}