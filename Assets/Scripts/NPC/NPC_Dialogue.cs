﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour
{
    public float dialogueRange;
    public LayerMask playerLayer;

    public DialogueSettings dialogue;

    private List<string> sentences = new List<string>();

    bool playerHit;
    // Start is called before the first frame update
    void Start()
    {
        GetNPCInfo();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerHit)
        {
            DialogueControl.instance.Speech(sentences.ToArray());
        }
    }

    void GetNPCInfo()
    {
        for (int i = 0; i < dialogue.dialogues.Count; i++)
        {
            sentences.Add(dialogue.dialogues[i].sentence.portuguese);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        ShowDialogue();
    }
    void ShowDialogue()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, playerLayer);

        if (hit != null)
        {
            // Debug.Log("Player na área, derrubou é penalti");
            playerHit = true;
        }
        else
        {
            playerHit = false;
            DialogueControl.instance.dialogueObj.SetActive(false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, dialogueRange);
    }
}
