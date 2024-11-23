using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eCardState {
    drawpile,
    tableau,
    target,
    discard
}

public class CardProspector : Card {
    [Header("Set Dynamically: CardProspector")]
    public eCardState state = eCardState.drawpile;
    public List<CardProspector> hiddenBy = new List<CardProspector>();
    public int layoutID;
    public SlotDef slotDef;

    public override void OnMouseUpAsButton() {
        // Debugging to ensure clicks are detected
        Debug.Log($"Card {name} clicked. State: {state}, FaceUp: {faceUp}, HiddenByCount: {hiddenBy.Count}");

        // Ensure the card is face-up and not hidden
        if (state == eCardState.tableau && faceUp && hiddenBy.Count == 0) {
            Prospector.S.CardClicked(this);
        } else {
            Debug.LogWarning($"Card {name} is not interactable. Check state and visibility.");
        }
        base.OnMouseUpAsButton();
    }
}
