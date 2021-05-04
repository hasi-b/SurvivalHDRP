using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


namespace Qubitech
{
    [CustomEditor(typeof(IP_Base_Airplane_Input))]
    public class IP_BaseAirplaneInput_Editor : Editor
    {

        #region variable

        private IP_Base_Airplane_Input targetInput;


        #endregion

        #region builtin Methods

        private void OnEnable()
        {
            targetInput = (IP_Base_Airplane_Input)target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            string debugInfo = "";
            debugInfo += "Pitch: " + targetInput.Pitch + "\n";
            debugInfo += "Roll: " + targetInput.Roll + "\n";
            debugInfo += "Yaw: " + targetInput.Yaw + "\n";
            debugInfo += "Throttle: " + targetInput.Throttle + "\n";
            debugInfo += "Brake: " + targetInput.Brake + "\n";
            debugInfo += "flap: " + targetInput.Flap + "\n";
            //custom editor code
            GUILayout.Space(20);
            EditorGUILayout.TextArea(debugInfo,GUILayout.Height(200));
            GUILayout.Space(20);
            Repaint();

        }


        #endregion
    }
}