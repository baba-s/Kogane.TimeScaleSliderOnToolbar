using UnityEditor;
using UnityEngine;
using UnityToolbarExtender;

namespace Kogane.Internal
{
    [InitializeOnLoad]
    internal static class TimeScaleSliderOnToolbar
    {
        static TimeScaleSliderOnToolbar()
        {
            ToolbarExtender.LeftToolbarGUI.Remove( OnToolbarGUI );
            ToolbarExtender.LeftToolbarGUI.Add( OnToolbarGUI );
        }

        private static void OnToolbarGUI()
        {
            var oldLabelWidth = EditorGUIUtility.labelWidth;
            EditorGUIUtility.labelWidth = 80;

            try
            {
                Time.timeScale = EditorGUILayout.Slider
                (
                    label: "Time Scale",
                    value: Time.timeScale,
                    leftValue: 0,
                    rightValue: 4
                );

                GUILayout.FlexibleSpace();
            }
            finally
            {
                EditorGUIUtility.labelWidth = oldLabelWidth;
            }
        }
    }
}