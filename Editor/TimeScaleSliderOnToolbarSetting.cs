using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Kogane.Internal
{
    [FilePath( "UserSettings/Kogane/TimeScaleSliderOnToolbarSetting.asset", FilePathAttribute.Location.ProjectFolder )]
    internal sealed class TimeScaleSliderOnToolbarSetting : ScriptableSingleton<TimeScaleSliderOnToolbarSetting>
    {
        [SerializeField] private bool    m_isEnable;
        [SerializeField] private float[] m_timeScaleArray = { 0, 0.25f, 0.5f, 1, 2, 4, 8 };

        public bool                 IsEnable       => m_isEnable;
        public IReadOnlyList<float> TimeScaleArray => m_timeScaleArray;

        public void Save()
        {
            Save( true );
        }
    }
}