using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNI_TPmoyennes
{
    class Classe
    {
        public const int MaxEleves = 30;
        public const int MaxMatieres = 10;
        public string nomClasse { get; private set; }
        public List<Eleve> eleves { get; private set; }
        public List<string> matieres { get; private set; }

        public Classe(string nomClasse)
        {
            this.nomClasse = nomClasse;
            eleves = new List<Eleve>();
            matieres = new List<string>();
        }
        public bool ajouterEleve(string prenom, string nom)
        {
            if (eleves.Count >= MaxEleves)
                return false;
            eleves.Add(new Eleve(prenom, nom));
            return true;
        }
        public bool ajouterMatiere(string nomMatiere)
        {
            if (matieres.Count >= MaxMatieres)
                return false;
            matieres.Add(nomMatiere);
            return true;
        }
        public float moyenneMatiere(int matiere)
        {
            if (eleves.Count == 0)
                return 0;
            float somme = 0;
            foreach(Eleve e in eleves)
            {
                somme += e.moyenneMatiere(matiere);
            }
            return Outils.Tronquer(somme / eleves.Count);
        }
        public float moyenneGeneral()
        {
            if (matieres.Count == 0)
                return 0;
            float somme = 0;
            for(int m = 0 ; m < matieres.Count; m++)
            {
                somme += moyenneMatiere(m);
            }
            return Outils.Tronquer(somme / matieres.Count);
        }
    }
}
