using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGenerator : MonoBehaviour
{
    public class Strategy
    {
        protected float m_seed;
        public virtual float GetNextNumber()
        {
            return 0;
        }
    }

    public class SinRandomStrategy: Strategy
    {
        private float m_step;
        private float m_noise;
        private float m_range;
        public SinRandomStrategy(float seed, float step, float noise, float range)
        {
            m_seed = seed;
            m_step = step;
            m_noise = noise;
            m_range = range;
        }
        public override float GetNextNumber()
        {
            float sin = (Mathf.Sin(m_seed * Mathf.Deg2Rad) * m_range);
            float noise = Random.Range(-m_noise, m_noise);
            
            m_seed += m_step;
            return sin + noise;
        }
    }

}
