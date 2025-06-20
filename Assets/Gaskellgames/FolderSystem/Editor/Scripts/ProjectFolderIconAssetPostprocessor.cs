#if UNITY_EDITOR
#if GASKELLGAMES
using System.Collections.Generic;
using System.IO;
using Gaskellgames.EditorOnly;
using UnityEditor;
using UnityEngine;

namespace Gaskellgames.FolderSystem.EditorOnly
{
    /// <summary>
    /// Code updated by Gaskellgames
    /// </summary>
    
    public class ProjectFolderIconAssetPostprocessor : AssetPostprocessor
    {
        #region Variables
        
        private const string packageRefName = "FolderSystem";
        private const string relativePath = "/Editor/Textures/";
        
        internal static Dictionary<string, Texture> autoGeneratedIconDictionary;

        #endregion

        //----------------------------------------------------------------------------------------------------

        #region OnEvents

        private static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
        {
            if (IconAssetExists(importedAssets) && IconAssetExists(deletedAssets) && IconAssetExists(movedAssets) && IconAssetExists(movedFromAssetPaths))
            {
                AutoGenerateIconDictionary();
            }
        }

        #endregion

        //----------------------------------------------------------------------------------------------------

        #region Private Functions

        private static bool IconAssetExists(string[] assets)
        {
            if (!GgPackageRef.TryGetFullFilePath(packageRefName, relativePath, out string filePath)) { return false; }
            
            foreach (string asset in assets)
            {
                if (FixStringSeparators(Path.GetDirectoryName(asset)) == filePath) { return true; }
            }
            return false;
        }

        private static string FixStringSeparators(string path)
        {
            return path.Replace("\\", "/");
        }

        #endregion

        //----------------------------------------------------------------------------------------------------

        #region Internal Functions
        
        /// <summary>
        /// create a dictionary list of all icons searchable by their name
        /// </summary>
        internal static void AutoGenerateIconDictionary()
        {
            if (!GgPackageRef.TryGetFullFilePath(packageRefName, relativePath, out string filePath)) { return; }
            
            // get all custom icons
            Dictionary<string, Texture> dictionary = new Dictionary<string, Texture>();
            List<Texture> fileIcons = EditorExtensions.GetAllAssetsByType<Texture>(new []{ filePath });
            foreach (Texture fileIcon in fileIcons)
            {
                dictionary.Add(Path.GetFileNameWithoutExtension(fileIcon.name), fileIcon);
            }
            
            autoGeneratedIconDictionary = dictionary;
        }

        #endregion
        
    } // class end
}
        
#endif
#endif