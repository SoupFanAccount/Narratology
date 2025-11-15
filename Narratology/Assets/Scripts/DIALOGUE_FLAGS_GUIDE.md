# Dialogue Flag System - Quick Guide

## Setup (One-time)

1. **Create a DialogueFlags GameObject:**
   - In your scene hierarchy, create an empty GameObject
   - Name it "DialogueFlags"
   - Add the `DialogueFlags` script component to it
   - This object will persist across scenes

## Using Flags with NPCs

### Example: Clerk with changing dialogue

**Setup the Clerk NPC:**
1. Select your Clerk GameObject
2. In the `Interactable` component, you'll see:
   - **Default Dialogue** - First-time dialogue
   - **Conditional Dialogues** - Dialogue that shows when flags are set

**Configure like this:**
```
Default Dialogue:
  [0] "Welcome! Would you like some chips?"
  [1] "They're on the shelf over there."

Conditional Dialogues:
  Element 0:
    Required Flag: "picked_up_chips"
    Dialogue Lines:
      [0] "Hope you're enjoying those chips!"
      [1] "Come back anytime!"
```

## Setting Flags

### Method 1: Using FlagSetter Component (Easy)
1. Select your "Chips" GameObject
2. Add the `FlagSetter` component
3. Set `Flag To Set` to: "picked_up_chips"
4. Enable `Set On Trigger Enter`
5. Enable `Destroy After Setting` (if you want chips to disappear)

### Method 2: From Code
```csharp
// In any script where player picks up chips:
DialogueFlags.instance.SetFlag("picked_up_chips");
```

### Method 3: Set flag after dialogue ends
In `DialogueManager.cs`, modify `EndDialogue()`:
```csharp
public void EndDialogue()
{
    // Set a flag when dialogue ends
    if (interactable.gameObject.name == "Clerk")
    {
        DialogueFlags.instance.SetFlag("talked_to_clerk");
    }
    
    dialogueController.enabled = false; 
    interactable.enabled = true; 
    currentDialogueLines = null;
    interactable = null;
}
```

## Common Flag Names (Examples)
- "talked_to_clerk"
- "picked_up_chips"
- "completed_quest_1"
- "found_secret_room"
- "met_shopkeeper"

## Multiple Conditions Example

You can chain multiple dialogue changes:

```
Default Dialogue: "Hello stranger."

Conditional Dialogues:
  Element 0:
    Required Flag: "talked_to_clerk"
    Dialogue: "Hello again."
  
  Element 1:
    Required Flag: "picked_up_chips"
    Dialogue: "Enjoying the chips?"
  
  Element 2:
    Required Flag: "returned_with_chips"
    Dialogue: "Back for more chips I see!"
```

**Note:** The system checks from bottom to top, so put the most recent/specific dialogue at the bottom.

## Debugging

Check if a flag is set:
```csharp
if (DialogueFlags.instance.HasFlag("picked_up_chips"))
{
    Debug.Log("Player has chips!");
}
```

Clear a flag (for testing):
```csharp
DialogueFlags.instance.ClearFlag("picked_up_chips");
```

