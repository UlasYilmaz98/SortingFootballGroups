using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 *****SITUATUION*****

 TEAM GROUPING WORKS (  %99 TESTED )

 2 TEAMS SORTING WORKS (  %45 TESTED )
     
 3 TEAMS SORTING WORKS ( %60 TESTED )    
 
     */



namespace SortingFootballGroup
{
    public class Team
    {
        public string Name { get; set; }

        public int GroupWins { get; set; }

        public int GroupsDraws { get; set; }

        public int GroupGoals { get; set; }

        public int GroupOwnGoals { get; set; }

        

    }

    public class Match
    {
        public bool isPlayed { get; set; }

        public string team1Name { get; set; }

        public string team2Name { get; set; }

        public int team1Score { get; set; }

        public int team2Score { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("///// BU UYGULAMA, ŞAVŞAT KÖYLER ARASI FUTBOL TURNUVASI İÇİN OLUŞTURULMUŞ , TAKIMLARIN GRUP İÇİNDEKİ DURUMLARINI SONUCU OLUŞAN PUAN DURUMUNU SİMÜLE EDEN BİR TEST UYGULAMASIDIR.");
            Team teamA = new Team()
            {
                Name = "Austria",
                GroupWins = 3,
                GroupsDraws = 1,
                GroupGoals = 3,
                GroupOwnGoals = 1                
            };
            Team teamB = new Team()
            {
                Name = "Belgium",
                GroupWins = 3,
                GroupsDraws = 1,
                GroupGoals = 4,
                GroupOwnGoals = 1
            };
            Team teamC = new Team()
            {
                Name = "Crotia",
                GroupWins = 2,
                GroupsDraws = 1,
                GroupGoals = 3,
                GroupOwnGoals = 1
            };
            Team teamD = new Team()
            {
                Name = "Denmark",
                GroupWins = 2,
                GroupsDraws = 1,
                GroupGoals = 5,
                GroupOwnGoals = 1
            };
            Team teamE = new Team()
            {
                Name = "England",
                GroupWins = 2,
                GroupsDraws = 1,
                GroupGoals = 6,
                GroupOwnGoals = 1
            };
            Team teamF = new Team()
            {
                Name = "France",
                GroupWins = 1,
                GroupsDraws = 3,
                GroupGoals = 5,
                GroupOwnGoals = 1
            };

            



            Dictionary<Team, int> HighPoints = new Dictionary<Team, int>();
            Dictionary<Team, int> MediumPoints = new Dictionary<Team, int>();
            Dictionary<Team, int> LowPoints = new Dictionary<Team, int>();

            List<Team> Checked = new List<Team>();
            List<Team> teamList = new List<Team>() { teamA, teamB, teamC, teamD, teamE, teamF };
         
            List<Team> teamListRef = new List<Team>();
            foreach (Team team in teamList)
            {
                teamListRef.Add(team);
            }


            foreach (Team team in teamListRef)
            {

                

                int exTeamPoint = team.GroupWins * 3 + team.GroupsDraws;
                if (HighPoints.Keys.Contains(team) || MediumPoints.Keys.Contains(team) || LowPoints.Keys.Contains(team) || Checked.Contains(team))
                {
                    Checked.Add(team);
                    //teamListRef.Remove(team);
                    continue;
                }
                foreach (Team team1 in teamListRef)
                {
                    int inTeamPoint = team1.GroupWins * 3 + team1.GroupsDraws;
                    if (team != team1 && exTeamPoint == inTeamPoint)
                    {
                        if (HighPoints.Count == 0)  //HIGHPOINTSE BAK.
                        {
                            HighPoints.Add(team, teamList.IndexOf(team));
                            HighPoints.Add(team1, teamList.IndexOf(team1));
                        }
                        else
                        {
                            if (HighPoints.ContainsKey(team) && !HighPoints.ContainsKey(team1))
                            {
                                HighPoints.Add(team1, teamList.IndexOf(team1));
                            }
                            else if (!HighPoints.ContainsKey(team1) && !HighPoints.ContainsKey(team))
                            {
                                if (MediumPoints.Count == 0) // MEDIUMPOINTSE BAK.
                                {
                                    MediumPoints.Add(team, teamList.IndexOf(team));
                                    MediumPoints.Add(team1, teamList.IndexOf(team1));
                                }
                                else
                                {
                                    if (MediumPoints.ContainsKey(team) && !MediumPoints.ContainsKey(team1))
                                    {
                                        MediumPoints.Add(team1, teamList.IndexOf(team1));
                                    }
                                    else if (!MediumPoints.ContainsKey(team1) && !MediumPoints.ContainsKey(team))
                                    {
                                        if (LowPoints.Count == 0) // MEDIUMPOINTSE BAK.
                                        {
                                            LowPoints.Add(team, teamList.IndexOf(team));
                                            LowPoints.Add(team1, teamList.IndexOf(team1));
                                        }
                                        else
                                        {
                                            if (LowPoints.ContainsKey(team) && !LowPoints.ContainsKey(team1))
                                            {
                                                LowPoints.Add(team1, teamList.IndexOf(team1));
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                //teamListRef.Remove(team);
                Checked.Add(team);

            }
            foreach ( KeyValuePair<Team,int> team in HighPoints )
            {
                Console.WriteLine("High//" + team.Key.Name + " : " + (team.Key.GroupWins * 3 + team.Key.GroupsDraws).ToString());
            }
            foreach (KeyValuePair<Team, int> team in MediumPoints)
            {
                Console.WriteLine("Medium//" + team.Key.Name + " : " + (team.Key.GroupWins * 3 + team.Key.GroupsDraws).ToString());
            }
            foreach (KeyValuePair<Team, int> team in LowPoints)
            {
                Console.WriteLine("Low//" + team.Key.Name + " : " + (team.Key.GroupWins * 3 + team.Key.GroupsDraws).ToString());
            }
            Console.WriteLine("Press any key to continue..");
            Console.ReadKey();



            List<Team> newSortingList = new List<Team>();
            if ( HighPoints.Keys.Count==2)
            {
                Dictionary<Team, int> referenceOfHighPoints = HighPoints;
                HighPoints = Sort2Teams(HighPoints);
                teamList[referenceOfHighPoints.ElementAt(0).Value] = HighPoints.ElementAt(0).Key; // İLK BAŞTA OLUŞTURDUĞUMUZ REFERANS SÖZLÜĞÜNDEKİ İLK TAKIMIN SIRASINI,DÜZENLENMİŞ SÖZLÜKTEKİ İLE DEĞİŞTİK.
                teamList[referenceOfHighPoints.ElementAt(1).Value] = HighPoints.ElementAt(1).Key; // İLK BAŞTA OLUŞTURDUĞUMUZ REFERANS SÖZLÜĞÜNDEKİ İLK TAKIMIN SIRASINI,DÜZENLENMİŞ SÖZLÜKTEKİ İLE DEĞİŞTİK.

            }
            else if (HighPoints.Keys.Count == 3)
            {
                Dictionary<Team, int> referenceOfHighPoints = HighPoints;
                HighPoints = Sort3Teams(HighPoints);
                teamList[referenceOfHighPoints.ElementAt(0).Value] = HighPoints.ElementAt(0).Key; // İLK BAŞTA OLUŞTURDUĞUMUZ REFERANS SÖZLÜĞÜNDEKİ İLK TAKIMIN SIRASINI,DÜZENLENMİŞ SÖZLÜKTEKİ İLE DEĞİŞTİK.
                teamList[referenceOfHighPoints.ElementAt(1).Value] = HighPoints.ElementAt(1).Key; // İLK BAŞTA OLUŞTURDUĞUMUZ REFERANS SÖZLÜĞÜNDEKİ İLK TAKIMIN SIRASINI,DÜZENLENMİŞ SÖZLÜKTEKİ İLE DEĞİŞTİK.
                teamList[referenceOfHighPoints.ElementAt(2).Value] = HighPoints.ElementAt(2).Key; // İLK BAŞTA OLUŞTURDUĞUMUZ REFERANS SÖZLÜĞÜNDEKİ İLK TAKIMIN SIRASINI,DÜZENLENMİŞ SÖZLÜKTEKİ İLE DEĞİŞTİK.
            }
            else if (HighPoints.Keys.Count > 3)
            {
                //SortMoreTeams(HighPoints); 
            }
            // /////////////////
            if (MediumPoints.Keys.Count == 2)
            {
                Dictionary<Team, int> referenceOfMediumPoints = MediumPoints;
                MediumPoints = Sort2Teams(MediumPoints);
                teamList[referenceOfMediumPoints.ElementAt(0).Value] = MediumPoints.ElementAt(0).Key; // İLK BAŞTA OLUŞTURDUĞUMUZ REFERANS SÖZLÜĞÜNDEKİ İLK TAKIMIN SIRASINI,DÜZENLENMİŞ SÖZLÜKTEKİ İLE DEĞİŞTİK.
                teamList[referenceOfMediumPoints.ElementAt(1).Value] = MediumPoints.ElementAt(1).Key; // İLK BAŞTA OLUŞTURDUĞUMUZ REFERANS SÖZLÜĞÜNDEKİ İLK TAKIMIN SIRASINI,DÜZENLENMİŞ SÖZLÜKTEKİ İLE DEĞİŞTİK.
            }
            else if (MediumPoints.Keys.Count == 3)
            {
                Dictionary<Team, int> referenceOfMediumPoints = MediumPoints;
                MediumPoints = Sort3Teams(MediumPoints);
                teamList[referenceOfMediumPoints.ElementAt(0).Value] = MediumPoints.ElementAt(0).Key; // İLK BAŞTA OLUŞTURDUĞUMUZ REFERANS SÖZLÜĞÜNDEKİ İLK TAKIMIN SIRASINI,DÜZENLENMİŞ SÖZLÜKTEKİ İLE DEĞİŞTİK.
                teamList[referenceOfMediumPoints.ElementAt(1).Value] = MediumPoints.ElementAt(1).Key; // İLK BAŞTA OLUŞTURDUĞUMUZ REFERANS SÖZLÜĞÜNDEKİ İLK TAKIMIN SIRASINI,DÜZENLENMİŞ SÖZLÜKTEKİ İLE DEĞİŞTİK.
                teamList[referenceOfMediumPoints.ElementAt(2).Value] = MediumPoints.ElementAt(2).Key; // İLK BAŞTA OLUŞTURDUĞUMUZ REFERANS SÖZLÜĞÜNDEKİ İLK TAKIMIN SIRASINI,DÜZENLENMİŞ SÖZLÜKTEKİ İLE DEĞİŞTİK.
            }
            else if (MediumPoints.Keys.Count > 3)
            {
                //SortMoreTeams(MediumPoints);
            }
            // ////////////////////
            if (LowPoints.Keys.Count == 2)
            {
                Dictionary<Team, int> referenceOfLowPoints = LowPoints;
                LowPoints = Sort2Teams(LowPoints);
                teamList[referenceOfLowPoints.ElementAt(0).Value] = LowPoints.ElementAt(0).Key; // İLK BAŞTA OLUŞTURDUĞUMUZ REFERANS SÖZLÜĞÜNDEKİ İLK TAKIMIN SIRASINI,DÜZENLENMİŞ SÖZLÜKTEKİ İLE DEĞİŞTİK.
                teamList[referenceOfLowPoints.ElementAt(1).Value] = LowPoints.ElementAt(1).Key; // İLK BAŞTA OLUŞTURDUĞUMUZ REFERANS SÖZLÜĞÜNDEKİ İLK TAKIMIN SIRASINI,DÜZENLENMİŞ SÖZLÜKTEKİ İLE DEĞİŞTİK.
            }
            else if (LowPoints.Keys.Count == 3)
            {
                Dictionary<Team, int> referenceOfLowPoints = LowPoints;
                LowPoints = Sort3Teams(LowPoints);
                teamList[referenceOfLowPoints.ElementAt(0).Value] = LowPoints.ElementAt(0).Key; // İLK BAŞTA OLUŞTURDUĞUMUZ REFERANS SÖZLÜĞÜNDEKİ İLK TAKIMIN SIRASINI,DÜZENLENMİŞ SÖZLÜKTEKİ İLE DEĞİŞTİK.
                teamList[referenceOfLowPoints.ElementAt(1).Value] = LowPoints.ElementAt(1).Key; // İLK BAŞTA OLUŞTURDUĞUMUZ REFERANS SÖZLÜĞÜNDEKİ İLK TAKIMIN SIRASINI,DÜZENLENMİŞ SÖZLÜKTEKİ İLE DEĞİŞTİK.
                teamList[referenceOfLowPoints.ElementAt(2).Value] = LowPoints.ElementAt(2).Key; // İLK BAŞTA OLUŞTURDUĞUMUZ REFERANS SÖZLÜĞÜNDEKİ İLK TAKIMIN SIRASINI,DÜZENLENMİŞ SÖZLÜKTEKİ İLE DEĞİŞTİK.
            }
            else if (LowPoints.Keys.Count > 3) 
            {
                //SortMoreTeams(LowPoints);
            }

            int place = 0;
            foreach ( Team team in teamList)
            {
                place++;
                Console.WriteLine("{0}-{1}:{2}", place.ToString(), team.Name, (team.GroupWins * 3 + team.GroupsDraws).ToString());
            }
            Console.ReadKey();

        }


        // ---------------------------------2 TAKIMI SIRALA----------------------------------------------------------------------//
        static Dictionary<Team,int> Sort2Teams(Dictionary<Team,int> dict)
        {
            int index0Goal = 0;
            int index1Goal = 0;
            bool isMatchFound = false;
           

            Match AvsB = new Match()
            {
                isPlayed = true,
                team1Name = "Austria",
                team2Name = "Belgium",
                team1Score = 2,
                team2Score = 2

            };

            Match CvsD = new Match()
            {
                isPlayed = true,
                team1Name = "Crotia",
                team2Name = "Denmark",
                team1Score = 1,
                team2Score = 2

            };

            List<Match> matchList = new List<Match>() { AvsB, CvsD };


            foreach (Match match in matchList)
            {
                if ((match.team1Name == dict.ElementAt(0).Key.Name && match.team2Name == dict.ElementAt(1).Key.Name) || (match.team1Name == dict.ElementAt(1).Key.Name && match.team2Name == dict.ElementAt(0).Key.Name))
                {
                    isMatchFound = true;
                    if ( match.team1Name == dict.ElementAt(0).Key.Name)
                    {
                        index0Goal += match.team1Score;
                        index1Goal += match.team2Score;
                    }
                    else if ( match.team1Name == dict.ElementAt(1).Key.Name )
                    {
                        index0Goal += match.team2Score;
                        index1Goal += match.team1Score;

                    }
                }
            }

            if ( index0Goal > index1Goal )
            {
                return dict;
            }
            else if ( index0Goal < index1Goal )  // KEYLERİN YERİ DEĞİŞİYOR ANCAK VALUELER AYNI KALIYOR ÇÜNKÜ SIRALAMALAR DEĞİŞİYOR.
            {

                Dictionary<Team, int> newDict = new Dictionary<Team, int>();
                newDict.Add(dict.ElementAt(1).Key, dict.ElementAt(0).Value);
                newDict.Add(dict.ElementAt(0).Key, dict.ElementAt(1).Value);
                return newDict;
            }
            else  // AVERAJLAR HESAPLANIYOR INDEXGOAL 1 INDEX 2 DEN BÜYÜK İSE GERİYE SIRALAMANIN TERSİ DÖNÜYOR.
            {
                int index0Average = dict.ElementAt(0).Key.GroupGoals - dict.ElementAt(0).Key.GroupOwnGoals;
                int index1Average = dict.ElementAt(1).Key.GroupGoals - dict.ElementAt(1).Key.GroupOwnGoals;

                if (index0Average >= index1Average)
                    return dict;
                else
                {
                    Dictionary<Team, int> newDict = new Dictionary<Team, int>();
                    newDict.Add(dict.ElementAt(1).Key, dict.ElementAt(0).Value);
                    newDict.Add(dict.ElementAt(0).Key, dict.ElementAt(1).Value);
                    return newDict;
                }
            }


        }


        // ---------------------------------3 TAKIMI SIRALA----------------------------------------------------------------------//
        static Dictionary<Team, int> Sort3Teams(Dictionary<Team, int> dict)
        {
            int index0Goal = 0;
            int index1Goal = 0;
            int index2Goal = 0;
            int index0OwnGoal = 0;
            int index1OwnGoal = 0;
            int index2OwnGoal = 0;
            int index0Average = 0;
            int index1Average = 0;
            int index2Average = 0;

            string team0Name = dict.ElementAt(0).Key.Name;
            string team1Name = dict.ElementAt(1).Key.Name;
            string team2Name = dict.ElementAt(2).Key.Name;

            Match AvsB = new Match()
            {
                isPlayed = true,
                team1Name = "Austria",
                team2Name = "Belgium",
                team1Score = 2,
                team2Score = 2

            };

            Match CvsD = new Match()
            {
                isPlayed = true,
                team1Name = "Crotia",
                team2Name = "Denmark",
                team1Score = 1,
                team2Score = 1

            };

            Match CvsE = new Match()
            {
                isPlayed = true,
                team1Name = "Crotia",
                team2Name = "England",
                team1Score = 1,
                team2Score = 1

            };

            Match EvsD = new Match()
            {
                isPlayed = true,
                team1Name = "England",
                team2Name = "Denmark",
                team1Score = 1,
                team2Score = 1

            };

            List<Match> matchList = new List<Match>() { AvsB, CvsD, CvsE,EvsD };

            foreach ( Match match in matchList)
            {
                if ( match.team1Name == team0Name && match.team2Name == team1Name )
                {
                    index0Goal += match.team1Score;
                    index0OwnGoal += match.team2Score;
                    index1Goal += match.team2Score;
                    index1OwnGoal += match.team1Score;
                }
                else if (match.team1Name == team1Name && match.team2Name == team0Name)
                {
                    index0Goal += match.team2Score;
                    index0OwnGoal += match.team1Score;
                    index1Goal += match.team1Score;
                    index1OwnGoal += match.team2Score;
                }
                else if (match.team1Name == team0Name && match.team2Name == team2Name)
                {
                    index0Goal += match.team1Score;
                    index0OwnGoal += match.team2Score;
                    index2Goal += match.team2Score;
                    index2OwnGoal += match.team1Score;
                }
                else if (match.team1Name == team2Name && match.team2Name == team0Name)
                {
                    index0Goal += match.team2Score;
                    index0OwnGoal += match.team1Score;
                    index2Goal += match.team1Score;
                    index2OwnGoal += match.team2Score;
                }
                else if (match.team1Name == team1Name && match.team2Name == team2Name)
                {
                    index1Goal += match.team1Score;
                    index1OwnGoal += match.team2Score;
                    index2Goal += match.team2Score;
                    index2OwnGoal += match.team1Score;
                }
                else if (match.team1Name == team2Name && match.team2Name == team1Name)
                {
                    index1Goal += match.team2Score;
                    index1OwnGoal += match.team1Score;
                    index2Goal += match.team1Score;
                    index2OwnGoal += match.team2Score;
                }

                
            }
            Dictionary<Team, int> newDict = new Dictionary<Team, int>();
            index0Average = index0Goal - index0OwnGoal;
            index1Average = index1Goal - index1OwnGoal;
            index2Average = index2Goal - index2OwnGoal;

            if (index0Average >= index1Average && index0Average >= index2Average && index1Average >= index2Average)
            {
                newDict.Add(dict.ElementAt(0).Key, dict.ElementAt(0).Value);
                newDict.Add(dict.ElementAt(1).Key, dict.ElementAt(1).Value);
                newDict.Add(dict.ElementAt(2).Key, dict.ElementAt(2).Value);
            }
            else if (index0Average >= index1Average && index0Average >= index2Average && index2Average >= index1Average)
            {
                newDict.Add(dict.ElementAt(0).Key, dict.ElementAt(0).Value);
                newDict.Add(dict.ElementAt(2).Key, dict.ElementAt(1).Value);
                newDict.Add(dict.ElementAt(1).Key, dict.ElementAt(2).Value);
            }
            else if (index1Average >= index0Average && index1Average >= index2Average && index0Average >= index2Average)
            {
                newDict.Add(dict.ElementAt(1).Key, dict.ElementAt(0).Value);
                newDict.Add(dict.ElementAt(0).Key, dict.ElementAt(1).Value);
                newDict.Add(dict.ElementAt(2).Key, dict.ElementAt(2).Value);
            }
            else if (index1Average >= index0Average && index1Average >= index2Average && index2Average >= index0Average)
            {
                newDict.Add(dict.ElementAt(1).Key, dict.ElementAt(0).Value);
                newDict.Add(dict.ElementAt(2).Key, dict.ElementAt(1).Value);
                newDict.Add(dict.ElementAt(0).Key, dict.ElementAt(2).Value);
            }
            else if (index2Average >= index0Average && index2Average >= index1Average && index0Average >= index1Average)
            {
                newDict.Add(dict.ElementAt(2).Key, dict.ElementAt(0).Value);
                newDict.Add(dict.ElementAt(0).Key, dict.ElementAt(1).Value);
                newDict.Add(dict.ElementAt(1).Key, dict.ElementAt(2).Value);
            }
            else if (index2Average >= index0Average && index2Average >= index1Average && index1Average >= index0Average)
            {

                newDict.Add(dict.ElementAt(2).Key, dict.ElementAt(0).Value);
                newDict.Add(dict.ElementAt(1).Key, dict.ElementAt(1).Value);
                newDict.Add(dict.ElementAt(0).Key, dict.ElementAt(2).Value);
            }
            return newDict;
        }

        static Dictionary<Team,int> SortMoreTeams(Dictionary<Team,int> dict)
        {
            return dict;

        }
    }
}
