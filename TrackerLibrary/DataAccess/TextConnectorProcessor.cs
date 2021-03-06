﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess.TextHelpers
{
    public static class TextConnectorProcessor
    {
        public static string GetFullPath(this string fileName) //Prizes.csv
        {
            return $"{ConfigurationManager.AppSettings["filePath"]}\\{fileName}";
        }

        public static List<string> LoadFile(this string fullPath)
        {
            if (!File.Exists(fullPath))
            {
                return new List<string>();
            }

            return File.ReadAllLines(fullPath).ToList();
        }

        public static List<PrizeModel> ConvertToPrizeModel(this List<string> lines)
        {
            List<PrizeModel> models = new List<PrizeModel>();
            foreach (string line in lines)
            {
                string[] cols = line.Split(',');
                PrizeModel model = new PrizeModel();
                model.Id = int.Parse(cols[0]);
                model.PlaceNumber = int.Parse(cols[1]);
                model.PlaceName = cols[2];
                model.PrizeAmount = decimal.Parse(cols[3]);
                model.PrizePercentage = double.Parse(cols[4]);
                models.Add(model);
            }
            return models;
        }

        public static void SaveToPrizeFile(this List<PrizeModel> models, string fileName)
        {
            List<string> lines = new List<string>();
            foreach (PrizeModel model in models)
            {
                lines.Add($"{model.Id},{model.PlaceNumber},{model.PlaceName},{model.PrizeAmount}," +
                    $"{model.PrizePercentage}");
            }
            File.WriteAllLines(fileName.GetFullPath(), lines);
        }

        public static List<PersonModel> ConvertToPersonModel(this List<string> lines)
        {
            List<PersonModel> models = new List<PersonModel>();
            foreach (string line in lines)
            {
                string[] cols = line.Split(',');
                PersonModel model = new PersonModel();
                model.Id = int.Parse(cols[0]);
                model.FirstName = cols[1];
                model.LastName = cols[2];
                model.EmailAddress = cols[3];
                model.CellphoneNumber = cols[4];
                models.Add(model);
            }
            return models;
        }

        public static void SaveToPersonFile(this List<PersonModel> models, string fileName)
        {
            List<string> lines = new List<string>();
            foreach (PersonModel model in models)
            {
                lines.Add($"{model.Id},{model.FirstName},{model.LastName},{model.EmailAddress},{model.CellphoneNumber}");
            }
            File.WriteAllLines(fileName.GetFullPath(), lines);
        }

        public static List<TeamModel> ConvertToTeamModels(this List<string> lines, string personsFileName)
        {
            // id, team name, list of ids separated by the pipe
            // 3, someone's team, 1|3|5 (id of each person)
            List<TeamModel> teamModels = new List<TeamModel>();
            List<PersonModel> persons = personsFileName.GetFullPath().LoadFile().ConvertToPersonModel();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');
                TeamModel t = new TeamModel();
                t.Id = int.Parse(cols[0]);
                t.TeamName = cols[1];
                string[] personIds = cols[2].Split('|');

                foreach (string id in personIds)
                {
                    t.TeamMembers.Add(persons.Where(x => x.Id == int.Parse(id)).First());
                }
            }
            return teamModels;
        }

        public static void SaveToTeamFile(this List<TeamModel> models, string fileName)
        {
            List<string> lines = new List<string>();
            foreach (TeamModel model in models)
            {
                lines.Add($"{model.Id},{model.TeamName},{ConvertPersonModelToString(model.TeamMembers)}");
            }
            File.WriteAllLines(fileName.GetFullPath(), lines);
        }

        private static string ConvertPersonModelToString(List<PersonModel> persons)
        {
            string ids="";
            if (persons.Count == 0)
            {
                return "";
            }
            foreach (PersonModel person in persons)
            {
                ids += $"{person.Id}|";
            }
            ids = ids.Substring(0, ids.Length - 1);
            return ids;
        }
    }
}