using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

namespace Intro_Heli_Physics
{
    [CustomEditor(typeof(KeyboardHeli_Input))]
    public class KeyboardHeli_InputEditor : Editor
    {
        KeyboardHeli_Input m_heli_Input;

        private void OnEnable()
        {
            m_heli_Input = target as KeyboardHeli_Input;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            DrawDebugUI();
            Repaint();
        }

        private void DrawDebugUI()
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            EditorGUILayout.Space();

            EditorGUI.indentLevel++;
            EditorGUILayout.LabelField("Throttle: " + m_heli_Input.RawThrottleInput.ToString("0.00"), EditorStyles.boldLabel);
            EditorGUILayout.LabelField("StickThrottle: " + m_heli_Input.StickThrottle.ToString("0.00"), EditorStyles.boldLabel);
            EditorGUILayout.LabelField("Collective: " + m_heli_Input.CollectiveInput.ToString("0.00"), EditorStyles.boldLabel);
            EditorGUILayout.LabelField("StickCollective: " + m_heli_Input.StickThrottle.ToString("0.00"), EditorStyles.boldLabel);
            EditorGUILayout.LabelField("Cyclic: " + m_heli_Input.CyclicInput.ToString("0.00"), EditorStyles.boldLabel);
            EditorGUILayout.LabelField("Pedal: " + m_heli_Input.PedalInput.ToString("0.00"), EditorStyles.boldLabel);
            EditorGUI.indentLevel--;

            EditorGUILayout.Space();
            EditorGUILayout.EndVertical();
        }

        
    }
}
