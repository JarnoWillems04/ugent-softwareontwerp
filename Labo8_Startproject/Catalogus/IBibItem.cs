using System;
using System.Collections.Generic;


namespace Catalogus
{
    public interface IBibItem
    {
        // unieke identificatie
         string Id { get; set; }
        // ouder waartoe het item (bv. artikel, afdeling, ...) behoort of null
        IBibItem Ouder { get; set; }
        // item toevoegen aan dit item 
        void VoegToe(IBibItem bibItem);
        // item verwijderen uit dit item 
        void Verwijder(IBibItem bibItem);
        // een item zoeken op basis van id
        IBibItem Zoek(string id);        
        // een item zoeken op basis van een trefwoord
       
        void VerplaatsNaar(IBibItem bibItem);
        // item weergeven als string met een aantal karakters als indentatie
        string Toon(int insprong);
    }
}
