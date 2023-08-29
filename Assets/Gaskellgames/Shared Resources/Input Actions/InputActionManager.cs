using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Code created by Gaskellgames
/// </summary>

namespace Gaskellgames
{
    public class InputActionManager : MonoBehaviour
    {
        #region Variables

        [Tooltip("Automatically enabled and disabled action assets")]
        [SerializeField] private List<InputActionAsset> inputActionAssets;

        #endregion

        //----------------------------------------------------------------------------------------------------

        #region Game loop

        private void OnEnable()
        {
            EnableAllInputActions();
        }

        private void OnDisable()
        {
            DisableAllInputActions();
        }

        #endregion

        //----------------------------------------------------------------------------------------------------

        #region Private Functions

        private void EnableAllInputActions()
        {
            if (inputActionAssets != null)
            {
                foreach (InputActionAsset asset in inputActionAssets)
                {
                    if (asset != null)
                    {
                        asset.Enable();
                    }
                }
            }
        }

        private void DisableAllInputActions()
        {
            if (inputActionAssets != null)
            {
                foreach (InputActionAsset asset in inputActionAssets)
                {
                    if (asset != null)
                    {
                        asset.Disable();
                    }
                }
            }
        }

        #endregion

    } // class end
}