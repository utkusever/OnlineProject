using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using ProjectTreeGenerator;
using UnityEditor;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityToolbarExtender;

static class ToolbarStyles
{
    public static readonly GUIStyle commandButtonStyle;

    static ToolbarStyles()
    {
        commandButtonStyle = new GUIStyle("Command")
        {
            fontSize = 16,
            alignment = TextAnchor.MiddleCenter,
            imagePosition = ImagePosition.ImageAbove,
            fontStyle = FontStyle.Bold
        };
    }
}

[InitializeOnLoad]
public class BuildRunEditor : MonoBehaviour
{
    static BuildRunEditor()
    {
        ToolbarExtender.LeftToolbarGUI.Add(OnToolbarGUI);
    }

    static void OnToolbarGUI()
    {
        GUILayout.FlexibleSpace();

        if (GUILayout.Button(new GUIContent("B", "Build"), ToolbarStyles.commandButtonStyle))
        {
            ScriptBatch.BuildGame(false, 1920, 1080);
        }

        if (GUILayout.Button(new GUIContent("B&R", "Build and Run"), ToolbarStyles.commandButtonStyle))
        {
            ScriptBatch.BuildGame(true, 1920, 1080);
        }

        if (GUILayout.Button(new GUIContent("EXE", "EXE"), ToolbarStyles.commandButtonStyle))
        {
            ShowPopupExample.Init();
        }
        if (GUILayout.Button(new GUIContent("F", "Folder Structure Generator"), ToolbarStyles.commandButtonStyle))
        {
            CreateProjectTree.Execute();
        }
    }
}

public class ShowPopupExample : EditorWindow
{
    private int width;
    private int height;
    private int count;

    public static void Init()
    {
        ShowPopupExample window = ScriptableObject.CreateInstance<ShowPopupExample>();
        window.position = new Rect(Screen.width / 2, Screen.height / 2, 250, 180);
        window.ShowPopup();
    }

    [System.Obsolete]
    void OnGUI()
    {
        GUILayout.Label("Base Settings", EditorStyles.boldLabel);
        GUILayout.Space(10);
        EditorGUILayout.LabelField("Resolution", EditorStyles.wordWrappedLabel);
        // myString = EditorGUILayout.TextField("X", myString);
        // myString2 = EditorGUILayout.TextField("Y", myString);
        width = EditorGUILayout.IntField("X", width);
        height = EditorGUILayout.IntField("Y", height);
        GUILayout.Space(10);
        EditorGUILayout.LabelField("CountOfExes", EditorStyles.wordWrappedLabel);
        count = EditorGUILayout.IntField("Count", count);

        if (GUILayout.Button("Apply!"))
        {
            this.Close();
            SetRes();
            for (int i = 0; i < count; i++)
            {
                //ScriptBatch.BuildGame(true, width, height);
                BuildExe.CreateExe(i);
            }
        }
    }

    private void SetRes()
    {
        PlayerSettings.defaultScreenWidth = width;
        PlayerSettings.defaultScreenHeight = height;
    }
}

public class BuildExe
{
    public static void CreateExe(int i)
    {
        string exeFile = "BuiltGame" + i + ".exe";
        string saveLocation= "C:/Users/Utku/Desktop/Builds";
        string[] levels = new string[] { "Assets/Game/Scenes/SampleScene.unity" };
        BuildPipeline.BuildPlayer(levels,saveLocation+exeFile, BuildTarget.StandaloneWindows, BuildOptions.None);
        Process proc = new Process();
        proc.StartInfo.FileName = "C:/Users/Utku/Desktop/Builds"+exeFile;
        proc.Start();
    }
}

public class ScriptBatch
{
    [MenuItem("MyTools/Windows Build With Postprocess")]
    public static void BuildGame(bool isRun, int width, int height)
    {
        // Get filename.
        string path = EditorUtility.SaveFolderPanel("Choose Location of Built Game", "", "");
        string[] levels = new string[] { "Assets/Game/Scenes/SampleScene.unity" };

        // Build player.
        BuildPipeline.BuildPlayer(levels, path + "/BuiltGame.exe", BuildTarget.StandaloneWindows, BuildOptions.None);

        // Copy a file from the project folder to the build folder, alongside the built game.
        //FileUtil.CopyFileOrDirectory("Assets/Templates/Readme.txt", path + "Readme.txt");

        if (isRun)
        {
            // Run the game (Process class from System.Diagnostics).
            Process proc = new Process();
            proc.StartInfo.FileName = path + "/BuiltGame.exe";
            proc.Start();
        }
    }
}