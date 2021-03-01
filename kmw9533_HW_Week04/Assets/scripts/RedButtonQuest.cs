using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButtonQuest : MonoBehaviour
{
    private int questNum = 0;//finds the quest in quests list that is the click red button quest

    private void Update()
    {
        //always updating where questNum is in case of change
        GetQuestNum();
        
        //if the quest is completed then the red button is not active
        if (questManager.instance.quests[questNum].completed == 0)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    
    //function to find the int of red button quest in quests
    public void GetQuestNum()
    {
        for (int i = 0; i < questManager.instance.quests.Count; i++)
        {
            if (questManager.instance.quests[i].questName == "Click Red Button")
            {
                questNum = i;
                break;
            }
        }
    }

    //function for when player clicks red button
    public void RedButtonClick()
    {
        questManager.instance.quests[questNum].completed = 1;
        questManager.instance.UpdateFile();
    }
}
