using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class uiUpdater : MonoBehaviour
{
    public GameObject player;
    public Image panel;
    public Image qAbilityPanel,eAbilityPanel;
    int hp;
    bool dash;
    bool qAbility,eAbility;
    Weapon curWeapon;

    public TMP_Text hpUI,invUI, qUI, eUI, potionUI;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform){
            if(child.name == "hpUI"){
                hpUI = child.GetComponent<TextMeshProUGUI>();
            }
            if(child.name == "invUI"){
                invUI = child.GetComponent<TextMeshProUGUI>();
            }
            if(child.name == "qUI"){
                qUI = child.GetComponent<TextMeshProUGUI>();
            }
            if(child.name == "eUI"){
                eUI = child.GetComponent<TextMeshProUGUI>();
            }
            if(child.name == "potionUI"){
                potionUI = child.GetComponent<TextMeshProUGUI>();
            }
            
        }
    }
            
    void updatehpUI(){
        characterStats cStats = player.GetComponent<characterStats>();
        hp = cStats.getHp();
        hpUI.text = "HP: " + hp;
    }
    void updatesprintUI(){
        playerMovement mStats = player.GetComponent<playerMovement>();
        dash = mStats.getDashStatus();
        Image img = panel.GetComponent<Image>();
        if(dash){
            img.color = UnityEngine.Color.white;
        }else{
            img.color =   new Color32( 233 , 67 , 67 , 100);
        }
    }
    void updateinvUI(){
        InventoryV3 iStats = player.transform.GetChild(1).gameObject.GetComponent<InventoryV3>();
        curWeapon = iStats.getCurrentWeapon();
        invUI.text = curWeapon.weaponName; 
    }
    void updateqeUI(){
        abilityDirector aStats = player.transform.GetChild(2).gameObject.GetComponent<abilityDirector>();
        qAbility = aStats.getQ();
        Image img2 = qAbilityPanel.GetComponent<Image>();
         if(qAbility){
            img2.color = UnityEngine.Color.white;
        }else{
            img2.color =   new Color32( 233 , 67 , 67 , 100);
        }
        qUI.text = aStats.getCurrentQ().getName();

        Image img3 = eAbilityPanel.GetComponent<Image>();
        eAbility = aStats.getE();
        if(eAbility){
            img3.color = UnityEngine.Color.white;
        }else{
            img3.color =   new Color32( 233 , 67 , 67 , 100);
        }
        eUI.text = aStats.getCurrentE().getName();
        eIcon( aStats.getCurrentE().getName());
    }
    void eIcon(string name){
        if(name == "Fire Ring"){
          transform.Find("eAbilityFrame").transform.Find(name).gameObject.SetActive(true);
        }
    }
    void updatepotionUI(){
        potionUI.text = "Potions";
        InventoryV3 iStats = player.transform.GetChild(1).gameObject.GetComponent<InventoryV3>();
        Dictionary<string, int> potionDictionary = iStats.getpotionDictionary();
        foreach (var kvp in potionDictionary)
        {
            if(kvp.Value > 0){
                potionUI.text += "\n" + kvp.Key + ": " + kvp.Value;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {      
        updatehpUI();
        updatesprintUI();
        updateinvUI();
        updateqeUI();
        updatepotionUI();
        

      
    }
}
