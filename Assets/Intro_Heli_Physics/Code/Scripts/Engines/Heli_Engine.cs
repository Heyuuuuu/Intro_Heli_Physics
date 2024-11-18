using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heli_Engine : MonoBehaviour
{
    #region Variables
    public float m_MaxHP = 140f;
    public float m_MaxRPM = 2700f;
    public AnimationCurve m_PowerCurve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1, 1));
    public float m_PowerDelay = 2f;
    #endregion

    #region Properties
    private float m_currentHP;
    public float CurrentHP
    {
        get => m_currentHP;
    }

    private float m_currentRPM;
    public float CurrentRPM
    {
        get => m_currentRPM;
    }
    #endregion

    #region Builtin Methods
    #endregion

    #region Custom Methods
    public void UpdateEngine(float throttleInput)
    {
        float wantedHP = m_PowerCurve.Evaluate(throttleInput) * m_MaxHP;
        m_currentHP = Mathf.Lerp(m_currentHP, wantedHP, Time.deltaTime * m_PowerDelay);

        float wantedRPM = throttleInput * m_MaxRPM;
        m_currentRPM = Mathf.Lerp(m_currentRPM, wantedRPM, Time.deltaTime * m_PowerDelay);
        //Debug.Log(m_currentRPM);
    }

    #endregion
}
