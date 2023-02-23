using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_CINE_APPLI
{
    public class filmClass

    {
        private int nofilm, nopublic;
        private string titre, realisateurs, acteurs, time, synopsis, infofilm, imgaffiche;

        public filmClass(int unNoFilm, string unTitre, string unRealisateur, string desActeurs, string uneHeure, string unSynopsis,
            string uneInfo, string uneAffiche, int unNoPublic)
        {
            nofilm= unNoFilm;
            titre = unTitre;
            realisateurs= unRealisateur;
            acteurs = desActeurs;
            time = uneHeure;
            synopsis = unSynopsis;
            infofilm = uneInfo;
            imgaffiche= uneAffiche;
            nopublic= unNoPublic;
        }

        public int getNofilm() { return nofilm; }
        public string getTitre() { return titre; }
        public string getRealisateurs() { return realisateurs; }
        public string getActeurs() { return acteurs; }
        public string getSynopsis() { return synopsis; }
        public string getInfofilm() { return infofilm; }
        public string getImgaffiche() { return imgaffiche; }
        public int getNoPublic() { return nopublic; }

    }
}
