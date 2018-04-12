using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL.Exo1
{
    public class JeuScore
    {
        public List<Tuple<int,int>> Scores { get; private set; }

        public int NbMaxManche { get; private set; } 


        public JeuScore(int nbMaxManche)
        {
            NbMaxManche = nbMaxManche;
            Scores = new List<Tuple<int, int>>(NbMaxManche);
        }

        public JeuScore(List<Tuple<int,int>> score, int nbMaxManche)
        {
            Scores = score;
            NbMaxManche = nbMaxManche;
        }

        public int GetSomme()
        {
            if (Scores == null)
                throw new ArgumentNullException("The parameter is null", nameof(Scores));

            bool isStrike = false;
            bool isSpare = false;

            int somme = 0;
            for (int i = 0; i < Scores.Count; ++i)
            {
                if(i < NbMaxManche)
                {
                    somme += Scores[i].Item1 + Scores[i].Item2;
                    isStrike = Scores[i].Item1 == 10;
                    isSpare = Scores[i].Item1 + Scores[i].Item2 == 10 && !isStrike;

                    if (isStrike && i + 1 < Scores.Count)
                    {
                        somme += Scores[i + 1].Item1;
                        if (IsStrike(Scores[i + 1]) && i + 2 < Scores.Count)
                            somme += Scores[i + 2].Item1;
                        else if (Scores[i + 1].Item2 != 0)
                            somme += Scores[i + 1].Item2;

                    }
                    else if (isSpare && i + 1 < Scores.Count)
                    {
                        somme += Scores[i + 1].Item1;
                    }
                }
               
            }
                
            return somme;
        }

        public bool Add(Tuple<int,int> score)
        {
            if (score.Item1 + score.Item2 < 0)
                return false;
            if (score.Item1 + score.Item2 > 10)
                return false;
            if (Scores.Count == NbMaxManche)
            {
                Tuple<int, int> last = Scores.Last();
                if (IsStrike(last))
                {
                    Scores.Add(score);
                    return true;
                }
                else if (IsSpare(last))
                {
                    if (score.Item2 == 0)
                    {
                        Scores.Add(score);
                        return true;
                    }
                    else
                        return false;

                }
                return false;

            }
            else if (Scores.Count == NbMaxManche + 1)
            {
                Tuple<int, int> last = Scores.Last();
                if (IsStrike(last))
                {
                    Scores.Add(score);
                    return true;
                }
                else
                    return false;
            }
            else if (Scores.Count > NbMaxManche + 2)
                return false;

            Scores.Add(score);
            return true;
        }

        private bool IsStrike(Tuple<int,int> coup)
        {
            return (coup.Item1 == 10 && coup.Item2 == 0) ;
        }
        private bool IsSpare(Tuple<int, int> coup)
        {
            return (coup.Item1 + coup.Item2 == 10 && !IsStrike(coup));
        }



    }
}
