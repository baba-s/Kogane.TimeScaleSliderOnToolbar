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

            var timeScaleArray = setting.TimeScaleArray;
            var count          = timeScaleArray.Count;

            EditorGUILayout.LabelField( "Time Scale", GUILayout.Width( 70 ) );

            for ( var i = 0; i < count; i++ )
            {
                var timeScale = timeScaleArray[ i ];
                //
                // var guiStyle = i == 0 ? new GUIStyle( EditorStyles.miniButtonLeft )
                //         : i == count  ? new GUIStyle( EditorStyles.miniButtonRight )
                //                         : new GUIStyle( EditorStyles.miniButtonMid )
                //     ;

                if ( GUILayout.Button( $"{timeScale:0.##}" ) )
                {
                    Time.timeScale = timeScale;
                }
            }

            // var currentIndex   = Array.IndexOf( timeScaleArray, Time.timeScale );
            //
            // var newIndex = EditorGUILayout.IntSlider
            // (
            //     label: "Time Scale",
            //     value: currentIndex,
            //     leftValue: 0,
            //     rightValue: timeScaleArray.Length - 1
            // );
            //
            // if ( currentIndex != newIndex )
            // {
            //     Time.timeScale = timeScaleArray[ newIndex ];
            // }

            GUILayout.FlexibleSpace();
        }
    }
}