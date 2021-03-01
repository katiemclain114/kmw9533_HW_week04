using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class questManager : MonoBehaviour
{
    public static questManager instance;
    private const string FILE_QUESTS = "/quests.csv";
    private string FILE_PATH_QUESTS;

    public Text questNameText;
    public Text questCompletedText;

    public List<Quest> quests = new List<Quest>();

    // private Quest tempQuest = new Quest();
    // private Quest quest = new Quest();
    //
    // public Quest Quest
    // {
    //     get
    //     {
    //
    //         if (File.Exists(FILE_PATH_QUESTS))
    //         {
    //             string[] questData = File.ReadAllText(FILE_PATH_QUESTS).Split(',');
    //             quest.completed = questData[0];
    //             quest.questName = questData[1];
    //         }
    //         else
    //         {
    //             quest.completed = "";
    //             quest.questName = "";
    //         }
    //
    //
    //         return quest;
    //
    //     }
    //     set
    //     {
    //         quest = value;
    //         string fileContents = quest.completed + "," + quest.questName + "\n";
    //         File.WriteAllText(FILE_PATH_QUESTS, fileContents);
    //     }
    // }

    private void Awake()
    {
        instance = this;
        
    }

    private void Start()
    {
        FILE_PATH_QUESTS = Application.dataPath + FILE_QUESTS;
        string[] questData = File.ReadAllText(FILE_PATH_QUESTS).Split('\n');
        for (int i = 0; i < questData.Length - 1; i++)
        {
            string[] row = questData[i].Split(',');
            int rowNum = Int32.Parse(row[1]);
            questNameText.text += row[0] + "\n";
            if (rowNum == 0)
            {
                questCompletedText.text += "Not Complete\n";
            }
            else
            {
                questCompletedText.text += "Complete\n";
            }

            Quest tempQuest = new Quest();
            tempQuest.questName = row[0];
            tempQuest.completed = Int32.Parse(row[1]);
            
            quests.Add(tempQuest);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(quests.Count);
        }
    }

    void FileToText()
    {
        questNameText.text = "";
        questCompletedText.text = "";
        string[] questData = File.ReadAllText(FILE_PATH_QUESTS).Split('\n');
        for (int i = 0; i < questData.Length - 1; i++)
        {
            string[] row = questData[i].Split(',');
            int rowNum = Int32.Parse(row[1]);
            questNameText.text += row[0] + "\n";
            if (rowNum == 0)
            {
                questCompletedText.text += "Not Complete\n";
            }
            else
            {
                questCompletedText.text += "Complete\n";
            }
        }
    }
    public void UpdateFile()
    {
        string questData = "";
        for (int i = 0; i < quests.Count; i++)
        {
            questData += quests[i].questName + "," + quests[i].completed + "\n";
        }
        File.WriteAllText(FILE_PATH_QUESTS, questData);
        FileToText();
    }

    
}
