using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawCards : MonoBehaviour
{
    public GameObject Card;
    public GameObject PlayerArea;
    public GameObject EnemyArea;
    List<GameObject> karten = new List<GameObject>();
    Object[] allCards;
    private string[] cards = { "rot1", "rot2", "rot3", "grün1", "grün2", "grün3" };


    // Start is called before the first frame update
    void Start()
    {
        /*allCards = Resources.LoadAll("CardImages");
        Debug.Log("Anzahl der Karten" + allCards.Length);
        foreach (var obj in allCards)
        {
            Debug.Log("OBject" + obj.name);
            GameObject newCard = Instantiate(Card);
            newCard.GetComponent<Image>().sprite = obj as Sprite;
        }*/
        string[] colors = { "Black", "Red", "Yellow", "Blue" };
        foreach (var color in colors)
        {
            for (int i = 1; i < 14; i++)
            {
                GameObject newCard = Instantiate(Card);
                string cardPath = "CardImages/SK_" + color + "_" + i;
                Debug.Log("Karte: " + cardPath);
                Sprite img = Resources.Load<Sprite>(cardPath);
                newCard.GetComponent<Image>().sprite = img;
                newCard.name = color + i;
                karten.Add(newCard);
                Debug.Log("KarteAnzahl: " + karten.Count);
            }
        }
        string[] specialCards = { "Escape", "SkullKing", "Pirate_BadeyeJoe", "Pirate_BettyBrave", "Pirate_EvilEmmy", "Pirate_HarryTheGiant", "Pirate_TortugaJack", "Mermaid", "Mermaid", "Escape", "Escape", "Escape", "Escape", "Escape" };
        foreach (var special in specialCards)
        {
            GameObject newCard = Instantiate(Card);
            string cardPath = "CardImages/SK_" + special;
            Debug.Log("Karte: " + cardPath);
            Sprite img = Resources.Load<Sprite>(cardPath);
            newCard.GetComponent<Image>().sprite = img;
            newCard.name = special;
            karten.Add(newCard);
            Debug.Log("KarteAnzahl: " + karten.Count);
        }
        Debug.Log("KarteAnzahlENDE: " + karten.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        if (karten.Count > 0 )
        {
            GameObject drawedCard = karten[Random.Range(0, karten.Count)];
            karten.Remove(drawedCard);
            GameObject playerCard = Instantiate(drawedCard, new Vector3(0, 0, 0), Quaternion.identity);
            playerCard.transform.SetParent(PlayerArea.transform, false);
            Debug.Log("Gezogene karte: " + playerCard.name);
        }
        else
        {
            Debug.Log("Keine Karten mehr im Stapel");
        }
        
    }
}
