﻿namespace ISIS.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Enums;
    using Interfaces;

    public class Engine : IRunnable
    {
        private readonly ICollection<IMilitantGroup> groups;
        private readonly IInputReader reader;
        private readonly IOutputWriter writer;
        private readonly IMilitantGroupFactory factory;

        public Engine(IInputReader reader, IOutputWriter writer, IMilitantGroupFactory groupFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.factory = groupFactory;
            this.groups = new List<IMilitantGroup>();
        }

        public void Run()
        {
            while (true)
            {
                string[] input = this.reader.ReadLine().Split('.').ToArray();

                this.ExecuteCommand(input);
                this.UpdateGroups();
            }
        }

        protected virtual void ExecuteCommand(string[] input)
        {
            var command = input[1];

            if (command.Contains("create"))
            {
                this.CreateGroup(input);
            }
            else if (command.Contains("attack"))
            {
                this.Attack(input);
            }
            else if (command.Contains("status"))
            {
                this.Status();
            }
            else if (command.Contains("akbar"))
            {             
            }
            else if (command.Contains("apocalypse"))
            {
                Environment.Exit(0);
            }
        }

        private void UpdateGroups()
        {
            foreach (var group in this.groups)
            {
                var militantGroup = group;

                if (!militantGroup.HasUpdated)
                {
                    militantGroup.Update();
                }

                militantGroup.HasUpdated = false;
            }
        }

        private void Status()
        {
            var sortedGroups = this.groups.OrderByDescending(group => group.Health).ThenByDescending(group => group.Damage);

            foreach (var group in sortedGroups)
            {
                this.writer.Print(group.ToString());
            }
        }

        private void Attack(string[] input)
        {
            var attacker = this.groups.FirstOrDefault(group => group.Name == input[0]);

            if (attacker == null)
            {
                throw new ArgumentNullException(nameof(attacker), "Attacker not found");
            }

            string pattern = @"attack\((.*?)\)";
            Regex regex = new Regex(pattern);

            foreach (var command in input)
            {
                if (regex.IsMatch(command))
                {
                    Match match = regex.Match(command);

                    var attacked = this.groups.FirstOrDefault(group => group.Name == match.Groups[1].ToString());

                    if (attacked == null)
                    {
                        throw new ArgumentNullException(nameof(attacked), "Target not found!");
                    }

                    if (attacker.IsAlive && attacked.IsAlive)
                    {
                        attacker.Attack(attacked);
                    }
                }
            }
        }

        private void CreateGroup(string[] input)
        {
            string pattern = @"create\((\d+),\s(\d+),\s(.+),\s(.+)\)";
            Regex regex = new Regex(pattern);
            foreach (var command in input)
            {
                if (regex.IsMatch(command))
                {
                    Match match = regex.Match(command);

                    string attack = match.Groups[4].ToString();
                    string effect = match.Groups[3].ToString();

                    string name = input[0];

                    int health = int.Parse(match.Groups[1].ToString());
                    int damage = int.Parse(match.Groups[2].ToString());

                    WarEffect warEffect = (WarEffect)Enum.Parse(typeof(WarEffect), effect);
                    AttackType attackType = (AttackType)Enum.Parse(typeof(AttackType), attack);

                    var newGroup =
                        this.factory.CreateGroup(name, health, damage, warEffect, attackType);
                    this.groups.Add(newGroup);
                }
            }
        }
    }
}
