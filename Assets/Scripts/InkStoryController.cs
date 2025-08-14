using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ink.Runtime;
using System.Collections.Generic;

public class InkStoryController : MonoBehaviour
{
    public TextMeshProUGUI storyTextUI;
    public TextMeshProUGUI locationTextUI;

    public GameObject choiceButtonPrefab;
    public Transform choiceContainer;

    public TextAsset inkJSONAsset;

    private Story story;

    void Start()
    {
        story = new Story(inkJSONAsset.text);
        RefreshView();
    }

    void RefreshView()
    {
        ClearUI();

        // Show all new content
        while (story.canContinue)
        {
            string text = story.Continue().Trim();
            storyTextUI.text += text + "\n\n";

            // Check for # tags like location updates
            foreach (string tag in story.currentTags)
            {
                if (tag.StartsWith("location:"))
                {
                    string locationName = tag.Substring("location:".Length).Trim();
                    locationTextUI.text = locationName;
                }
            }
        }

        // Create a button for each choice
        foreach (Choice choice in story.currentChoices)
        {
            GameObject buttonGO = Instantiate(choiceButtonPrefab, choiceContainer);
            TextMeshProUGUI buttonText = buttonGO.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = choice.text.Trim();

            Button button = buttonGO.GetComponent<Button>();
            button.onClick.AddListener(() => OnClickChoice(choice));
        }
    }

    void OnClickChoice(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
        RefreshView();
    }

    void ClearUI()
    {
        storyTextUI.text = "";

        foreach (Transform child in choiceContainer)
        {
            Destroy(child.gameObject);
        }
    }
}
