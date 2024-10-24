using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using UnityEditor;
using UnityEngine;

public class UIIDGenerator : EditorWindow
{
    [MenuItem("Tools/Generate UIID")]
    public static void ShowWindow()
    {
        GetWindow<UIIDGenerator>("UIID Generator");
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Generate UIID"))
        {
            GenerateUIID();
        }
    }

    private void GenerateUIID()
    {
        string[] uxmlFiles = Directory.GetFiles(Application.dataPath, "*.uxml", SearchOption.AllDirectories);
        HashSet<string> uniqueNames = new HashSet<string>();
        foreach (string file in uxmlFiles)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(file);
            ExtractNames(doc.DocumentElement, uniqueNames);
        }
        GenerateUIIDClass(uniqueNames);
    }

    private void ExtractNames(XmlNode node, HashSet<string> names)
    {
        if (node.Attributes != null && node.Attributes["name"] != null)
        {
            names.Add(node.Attributes["name"].Value);
        }
        foreach (XmlNode child in node.ChildNodes)
        {
            ExtractNames(child, names);
        }
    }

    private void GenerateUIIDClass(HashSet<string> names)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("using UnityEngine.UIElements;");
        sb.AppendLine();
        sb.AppendLine("public static class UIID");
        sb.AppendLine("{");
        sb.AppendLine("    public static class id");
        sb.AppendLine("    {");
        foreach (string name in names.OrderBy(n => n))
        {
            string safeName = name.Replace("-", "_");
            sb.AppendLine($"        public const string {safeName} = \"{name}\";");
        }
        sb.AppendLine("    }");
        sb.AppendLine("}");

        string path = Path.Combine(Application.dataPath, "Scripts", "UIID.cs");
        File.WriteAllText(path, sb.ToString());
        AssetDatabase.Refresh();
        Debug.Log($"UIID class generated at {path}");
    }
}