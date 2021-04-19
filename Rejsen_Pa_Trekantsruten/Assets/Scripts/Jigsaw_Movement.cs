using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Jigsaw_Movement : MonoBehaviour
{
    // Puslespilsbrikkernes status
    public string pieceStatus = "idle";
    public bool checkPlacement = false;

    // Brikkernes lydkilde
    AudioSource audioPlaced;

    // Start bliver kaldt f�r f�rste frame
    void Start()
    {
        // Brikkernes lydkilde bliver fundet
        audioPlaced = this.GetComponent<AudioSource>();
    }

    // Update bliver kaldt �n gang per frame
    void Update()
    {
        // Tjekker om brikken er samlet op
        if (pieceStatus == "pickedUp")
        {
            // mousePosition finder x & y koordinatorne for musepillen
            Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            // objPosition overs�tter mousePosition til en position i spillet
            Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            // S�tter positionen af dette objekt til det samme som objPosition
            transform.position = objPosition;
        }
    }

    // OnTriggerStay2D bliver kaldt n�r 2 collidere forbliver kollideret
    private void OnTriggerStay2D(Collider2D other)
    {
        // Tjekker om de to kolliderene objekter har det samme navn og om placeringen skal tjekkes
        if ((other.gameObject.name == gameObject.name) && (checkPlacement == true))
        {
            // Deaktivere boxcollideren p� de to kolliderene objekter
            other.GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            // Flytter puslespilsbrikken hen p� sin l�ste position
            transform.position = other.gameObject.transform.position;
            // Opdatere brikkens status til "L�st"
            pieceStatus = "locked";
        }
        // Tjekker om brikken er l�st, og om placeringen skal tjekkes
        if (pieceStatus == "locked" && checkPlacement == true)
        {
            // Sl�r placeringstjek fra
            checkPlacement = false;
            // Tilf�jer �n til l�ste brikker i Jigsaw_GameManager
            Jigsaw_GameManager.lockedPieces++;
            // Afspiller placeringslyden
            audioPlaced.Play();
        }
    }

    // OnMouseDown bliver kaldt n�r musseknappen trykkes ned
    private void OnMouseDown()
    {
        // Opdatere brikkens status til "Samlet op" og sl�r placeringstjek fra
        pieceStatus = "pickedUp";
        checkPlacement = false;
    }

    // OnMouseUp bliver kaldt n�r musseknappen l�ftes
    private void OnMouseUp()
    {
        // Opdatere brikkens status til "venter" og sl�r placeringstjek til
        pieceStatus = "idle";
        checkPlacement = true;
    }
}
