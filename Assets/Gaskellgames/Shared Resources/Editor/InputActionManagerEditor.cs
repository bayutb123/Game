#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

/// <summary>
/// Code created by Gaskellgames
/// </summary>

namespace Gaskellgames
{
    [CustomEditor(typeof(InputActionManager))]
    public class InputActionManagerEditor : Editor
    {
        #region Serialized Properties / OnEnable

        SerializedProperty inputActionAssets;

        private void OnEnable()
        {
            inputActionAssets = serializedObject.FindProperty("inputActionAssets");
        }

        #endregion

        //----------------------------------------------------------------------------------------------------

        #region OnInspectorGUI

        public override void OnInspectorGUI()
        {
            // get & update references
            InputActionManager inputActionManager = (InputActionManager)target;
            serializedObject.Update();

            // banner
            Texture banner = (Texture)AssetDatabase.LoadAssetAtPath("Assets/Gaskellgames/Shared Resources/Icons/inspectorBanner_InputSystem.png", typeof(Texture));
            GUILayout.Box(banner, GUILayout.ExpandWidth(true), GUILayout.Height(Screen.width / 7.5f));

            // custom inspector
            EditorGUILayout.PropertyField(inputActionAssets);

            // apply reference changes
            serializedObject.ApplyModifiedProperties();
        }

        #endregion

    } // class end
}

#endif
