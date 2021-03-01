using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class questManager : MonoBehaviour
{
    public static questManager instance; //instance for singleton 
    
    //file and file path
    private const string FILE_QUESTS = "/quests.csv";
    private string FILE_PATH_QUESTS;

    //text variables
    public Text questNameText;
    public Text questCompletedText;

    //list of all quests
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
        //set instance (only one scene so no loadonscene stuff
        instance = this;
        
    }

    private void Start()
    {
        //set up file path
        FILE_PATH_QUESTS = Application.dataPath + FILE_QUESTS;
        
        //set the initial ui text and fill in quest list from file
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

    //called to update the UI text to make it match the information in quests
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
    
    //updates the csv file with correct information on quests
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
