using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButtonQuest : MonoBehaviour
{
    private int questNum = 0;
    private void Start()
    {
        
    }

    private void Update()
    {
        GetQuestNum();
        if (questManager.instance.quests[questNum].completed == 0)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

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

    public void RedButtonClick()
    {
        questManager.instance.quests[questNum].completed = 1;
        questManager.instance.UpdateFile();
    }
}
