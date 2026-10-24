using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNI_TPmoyennes
{
    class Eleve
    {
        public const int MaxNotes = 200; 
        public string prenom { get; private set; }
        public string nom { get; private set; }
        private List<Note> notes;

        public Eleve(string prenom, string nom)
        {
            this.prenom = prenom;
            this.nom = nom;
            notes = new List<Note>();
        }
        public bool ajouterNote(Note note)
        {
            if (notes.Count >= MaxNotes)
                return false;
            notes.Add(note);
            return true;
        }
        public float moyenneMatiere(int matiere)
        {
            float somme = 0;
            int compteur = 0;

            foreach(Note n in notes)
            {
                if(n.matiere == matiere)
                {
                    somme += n.note;
                    compteur++;
                }
            }
            if (compteur == 0)
                return 0;

            return Outils.Tronquer(somme / compteur);
        }
        public float moyenneGeneral()
        {
            List<int> matieres = new List<int>();
            foreach (Note n in notes)
            {
                if (!matieres.Contains(n.matiere))
                    matieres.Add(n.matiere);
            }

            if (matieres.Count == 0)
                return 0;
            float somme = 0;
            foreach(int m in matieres)
            {
                somme += moyenneMatiere(m);
            }
            return Outils.Tronquer(somme / matieres.Count);
        }
    }
}
