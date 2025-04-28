using UnityEngine;
using UnityEditor;


public class ConvertDBKConcrete : EditorWindow
{
    [MenuItem("Tools/Convert DBK_Concrete to URP")]
    static void ConvertMaterials()
    {
        string[] materialGUIDs = AssetDatabase.FindAssets("t:Material");
        int converted = 0;

        foreach (string guid in materialGUIDs)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            Material mat = AssetDatabase.LoadAssetAtPath<Material>(path);

            if (mat.shader.name == "DBK/Concrete")
            {
                Texture baseMap = mat.GetTexture("_ColorTheme");
                Texture normalMap = mat.GetTexture("_ConcreteNM");

                Shader urpShader = Shader.Find("Universal Render Pipeline/Lit");
                if (urpShader == null)
                {
                    UnityEngine.Debug.LogError("❌ Shader URP Lit introuvable !");
                    return;
                }

                mat.shader = urpShader;

                if (baseMap != null && mat.HasProperty("_BaseMap"))
                    mat.SetTexture("_BaseMap", baseMap);

                if (normalMap != null && mat.HasProperty("_BumpMap"))
                {
                    mat.SetTexture("_BumpMap", normalMap);
                    mat.EnableKeyword("_NORMALMAP");
                }

                // Optionnel : couleur par défaut
                if (mat.HasProperty("_BaseColor"))
                    mat.SetColor("_BaseColor", Color.gray);

                EditorUtility.SetDirty(mat);
                converted++;
            }
        }

        AssetDatabase.SaveAssets();
        UnityEngine.Debug.Log($"✅ Matériaux DBK_Concrete convertis : {converted}");

    }
}
