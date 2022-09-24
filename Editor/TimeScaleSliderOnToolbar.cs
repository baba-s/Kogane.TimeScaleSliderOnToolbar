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
            var setting = TimeScaleSliderOnToolbarSetting.instance;

            if ( !setting.IsEnable ) return;

            using ( new EditorGUILayout.HorizontalScope( GUILayout.Width( 224 ) ) )
            {
                EditorGUILayout.LabelField( "Time Scale", GUILayout.Width( 70 ) );

                foreach ( var timeScale in setting.TimeScaleArray )
                {
                    var text = $"{timeScale:0.##}";

                    if ( !GUILayout.Button( text, EditorStyles.toolbarButton ) ) continue;

                    Time.timeScale = timeScale;
                    Debug.Log( $"Time Scale: {text}" );
                }
            }
        }
    }
}