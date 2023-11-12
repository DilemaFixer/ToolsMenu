using System.IO;
using UnityEditor;
using UnityEngine;

namespace Dilemma
{
    public static class ToolsMenu
    {
        [MenuItem("Tools/Setup/Create Default Folders")]
        public static void CreateToolsMenu()
        {
            Directory.CreateDirectory(Path.Combine(Application.dataPath, "_Project"));
            AssetDatabase.Refresh();
            Dir("_Project", "[0]Source", "[1]Resources", "[2]Unity Assets", "[3]Temporary");
            AssetDatabase.Refresh();
            Dir("_Project/[1]Resources", "Prefabs", "Scenes", "Models", "Textures");
            AssetDatabase.Refresh();
            Dir("_Project/[0]Source", "Editor" , "Game");
            CreateAssemblyDefinition(Path.Combine(Application.dataPath, "_Project/[0]Source/Editor") , "Editor")
            CreateAssemblyDefinition(Path.Combine(Application.dataPath, "_Project/[0]Source/Game") , "Game")
            AssetDatabase.Refresh();
        }

        private static void Dir(string root, params string[] paths)
        {
            string fullPath = Path.Combine(Application.dataPath, root);
            foreach (var path in paths)
                Directory.CreateDirectory(Path.Combine(fullPath, path));
        }

        private static void CreateAssemblyDefinition(string path , string nameOfAssemblyDefinition)
        {
            System.IO.File.WriteAllText(path, GetDefaultAssemblyDefinitionContent(nameOfAssemblyDefinition));
        }

        private string GetDefaultAssemblyDefinitionContent(string name)
        {
            return @"{
            ""name"": ""Assembly-CSharp"",
            ""references"": [],
            ""includePlatforms"": [],
            ""excludePlatforms"": [],
            ""allowUnsafeCode"": false,
            ""overrideReferences"": false,
            ""precompiledReferences"": [],
            ""autoReferenced"": true,
            ""defineConstraints"": [],
            ""versionDefines"": [],
            ""noEngineReferences"": false
        }";
        }
    }
}


