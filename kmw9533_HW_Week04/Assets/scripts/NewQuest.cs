using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewQuest : MonoBehaviour
{
    //adds new quest to the quests list and file
    public void NewQuestClick()
    {
        Quest tempQuest = new Quest();
        tempQuest.questName = "New Quest";
        tempQuest.completed = 0;
        
        questManager.instance.quests.Add(tempQuest);
        questManager.instance.UpdateFile();
    }
}
