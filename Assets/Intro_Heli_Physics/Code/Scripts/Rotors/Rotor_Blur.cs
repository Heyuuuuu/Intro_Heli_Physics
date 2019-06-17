using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Intro_Heli_Physics
{
    public class Rotor_Blur : MonoBehaviour, IHeliRotor
    {
        #region Variables
        public float m_Maxdps = 1000f;
        public List<GameObject> m_Blads = new List<GameObject>();
        public List<Texture> m_BlurTextures = new List<Texture>();
        public Material m_BlurMat;
        #endregion

        #region Builtin Method
        #endregion

        #region Interface Method
        public void UpdateRotor(float dps, Input_Controller input)
        {
            float normalizeDps = Mathf.InverseLerp(0, m_Maxdps, dps);
            int textureIndex = Mathf.FloorToInt(normalizeDps * (m_BlurTextures.Count - 1));
            if (m_BlurTextures.Count > 0 && m_BlurMat)
            {
                m_BlurMat.SetTexture("_MainTex", m_BlurTextures[textureIndex]);
            }

            if (textureIndex > 4)
            {
                HandleGeoBladesViz(false);
            }
            else
            {
                HandleGeoBladesViz(true);
            }

        }
        #endregion

        #region Custom Methods
        private void HandleGeoBladesViz(bool viz)
        {
            if (m_Blads.Count == 0)
                return;
            foreach (var Blad in m_Blads)
            {
                Blad.SetActive(viz);
            }
        }
        #endregion
    }
}
