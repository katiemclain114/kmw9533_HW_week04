using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewQuest : MonoBehaviour
{
    public void NewQuestClick()
    {
        Quest tempQuest = new Quest();
        tempQuest.questName = "New Quest";
        tempQuest.completed = 0;
        
        questManager.instance.quests.Add(tempQuest);
        questManager.instance.UpdateFile();
    }
}
