using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for Briefing
/// </summary>
namespace Testhoekje.App_Code.Briefing
{
    public class Briefing
    {


        public Dictionary<string, string> GetBerichtProperties(string fileContent)
        {

            Dictionary<string, string> berichtProperties = new Dictionary<string, string>();

            berichtProperties["id"] = "??";
            berichtProperties["rollen"] = "??";
            berichtProperties["titel"] = "??";
            berichtProperties["geldigheidVan"] = "??";
            berichtProperties["geldigheidTot"] = "??";
            //berichtProperties["mcn"] = "false";
            //berichtProperties["hc"] = "false";
            //berichtProperties["wal"] = "false";
            //berichtProperties["vs"] = "false";
            //berichtProperties["hcInt"] = "false";
            //berichtProperties["mcnInt"] = "false";

            berichtProperties["Machinist-NSR"] = "false";
            berichtProperties["Hoofdconducteur-NSR"] = "false";
            berichtProperties["Servicemedewerker"] = "false";
            berichtProperties["Procesleider-Perron"] = "false";
            berichtProperties["Veiligheid-en-service"] = "false";
            berichtProperties["Trainmanager-ICBrussel"] = "false";
            berichtProperties["Trainmanager-ICE"] = "false";
            berichtProperties["Trainmanager-Thalys"] = "false";
            berichtProperties["Machinist-ICE"] = "false";
            berichtProperties["Machinist-ICBrussel"] = "false";
            berichtProperties["Machinist-Thalys"] = "false";



            //get parameters
            string[] par = Regex.Split(fileContent, "\"");
            for (int i = 3; i < par.Length; i++)
            {
                //bepaal id
                if (par[i - 1].Contains("content=") && par[i - 2] == "id" && par[i - 3].Contains("name="))
                {
                    berichtProperties["id"] = par[i];
                }

                //bepaal rollen
                if (par[i - 1].Contains("content=") && par[i - 2] == "functie" && par[i - 3].Contains("name="))
                {
                    berichtProperties["rollen"] = par[i];
                    string t = par[i].ToLower();
                    t = t.Replace(" ", "");
                    string[] list_t = t.Split(',');


                    if (Array.Exists(list_t, element => element == "mcn") || Array.Exists(list_t, element => element == "mcnm")) 
                        berichtProperties["Machinist-NSR"] = "true";

                    if (Array.Exists(list_t, element => element == "hc") || Array.Exists(list_t, element => element == "hcm"))
                        berichtProperties["Hoofdconducteur-NSR"] = "true";

                    if (Array.Exists(list_t, element => element == "smw"))
                        berichtProperties["Servicemedewerker"] = "true";

                    if (Array.Exists(list_t, element => element == "plp"))
                        berichtProperties["Procesleider-Perron"] = "true";

                    if (Array.Exists(list_t, element => element == "hc") || Array.Exists(list_t, element => element == "tsv"))
                        berichtProperties["Veiligheid-en-service"] = "true";

                    if (Array.Exists(list_t, element => element == "hcb"))
                        berichtProperties["Trainmanager-ICBrussel"] = "true";

                    if (Array.Exists(list_t, element => element == "hci"))
                        berichtProperties["Trainmanager-ICE"] = "true";

                    if (Array.Exists(list_t, element => element == "hct"))
                        berichtProperties["Trainmanager-Thalys"] = "true";

                    if (Array.Exists(list_t, element => element == "mcni"))
                        berichtProperties["Machinist-ICE"] = "true";

                    if (Array.Exists(list_t, element => element == "mcnb"))
                        berichtProperties["Machinist-ICBrussel"] = "true";

                    if (Array.Exists(list_t, element => element == "mcnt"))
                        berichtProperties["Machinist-Thalys"] = "true";
            
                }



                //bepaal geldigheid
                if (par[i - 1].Contains("content=") && par[i - 2] == "geldigheid" && par[i - 3].Contains("name="))
                {
                    string[] p = Regex.Split(par[i], "-");
                    if (p.Length == 6)
                    {
                        berichtProperties["geldigheidVan"] = p[0] + "-" + p[1] + "-" + p[2];
                        berichtProperties["geldigheidTot"] = p[3] + "-" + p[4] + "-" + p[5];
                    }
                    else
                    {
                        berichtProperties["geldigheidVan"] = "Onbekend";
                        berichtProperties["geldigheidTot"] = "Onbekend";
                    }

                }




            }

            //get titel en body
            string titel = Regex.Match(fileContent, "<title>(.*?)</title>").ToString();
            titel = titel.Replace("<title>", "");
            titel = titel.Replace("</title>", "");

            berichtProperties["titel"] = titel;






            return berichtProperties;

        }
    }
}