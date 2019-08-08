namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Common;
    using MortalEngines.Entities;
    using MortalEngines.Entities.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MachinesManager : IMachinesManager
    {
        private List<IPilot> pilots = new List<IPilot>();
        private List<IMachine> machines = new List<IMachine>();

        public string HirePilot(string name)
        {
            if (pilots.Any(p => p.Name == name))
            {
                return string.Format(OutputMessages.PilotExists, name);
            }

            else
            {
                IPilot pilot = new Pilot(name);
                pilots.Add(pilot);
                
                return string.Format(OutputMessages.PilotHired, name);
            }
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            if (machines.Any(t => t.Name == name && t is Tank))
            {
                return string.Format(OutputMessages.MachineExists, name);
            }

            else
            {
                IMachine machine = new Tank(name, attackPoints, defensePoints);

                machines.Add(machine);

                return string.Format(OutputMessages.TankManufactured, name, machine.AttackPoints, machine.DefensePoints);
            }
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            if (machines.Any(f => f.Name == name && f is Fighter))
            {
                return string.Format(OutputMessages.MachineExists, name);
            }

            else
            {
                IMachine machine = new Fighter(name, attackPoints, defensePoints);

                machines.Add(machine);

                return string.Format(OutputMessages.FighterManufactured, name, machine.AttackPoints, machine.DefensePoints, "ON");
            }
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            IPilot pilot = pilots.FirstOrDefault(p => p.Name == selectedPilotName);

            if (pilot is null)
            {
                return string.Format(OutputMessages.PilotNotFound, selectedPilotName);
            }

            IMachine machine = machines.FirstOrDefault(m => m.Name == selectedMachineName);

            if (machine is null)
            {
                return string.Format(OutputMessages.MachineNotFound, selectedMachineName);
            }

            if (machine.Pilot != null)
            {
                return string.Format(OutputMessages.MachineHasPilotAlready, selectedMachineName);
            }

            machine.Pilot = pilot;

            return string.Format(OutputMessages.MachineEngaged, selectedPilotName, selectedMachineName);
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            IMachine attackingMachine = machines.FirstOrDefault(m => m.Name == attackingMachineName);

            if (attackingMachine is null)
            {
                return string.Format(OutputMessages.MachineNotFound, attackingMachineName);
            }

            if (attackingMachine.HealthPoints == 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, attackingMachineName);
            }

            IMachine defendingMachine = machines.FirstOrDefault(m => m.Name == defendingMachineName);

            if (defendingMachine is null)
            {
                return string.Format(OutputMessages.MachineNotFound, defendingMachineName);
            }

            if (defendingMachine.HealthPoints == 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, defendingMachineName);
            }

            attackingMachine.Attack(defendingMachine);

            return string.Format(OutputMessages.AttackSuccessful, defendingMachineName, attackingMachineName, defendingMachine.HealthPoints);
        }

        public string PilotReport(string pilotReporting)
        {
            return pilots.FirstOrDefault(p => p.Name == pilotReporting).Report();
        }

        public string MachineReport(string machineName)
        {
            return machines.FirstOrDefault(m => m.Name == machineName).ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            IMachine machine = machines.FirstOrDefault(f => f.Name == fighterName && f is Fighter);

            if (machine is null)
            {
                return string.Format(OutputMessages.MachineNotFound, fighterName);
            }

            else
            {
                IFighter fighter = machine as Fighter;

                fighter.ToggleAggressiveMode();

                return string.Format(OutputMessages.FighterOperationSuccessful, fighterName);
            }
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            IMachine machine = machines.FirstOrDefault(t => t.Name == tankName && t is Tank);

            if (machine is null)
            {
                return string.Format(OutputMessages.MachineNotFound, tankName);
            }

            else
            {
                ITank tank = machine as ITank;
                tank.ToggleDefenseMode();

                return string.Format(OutputMessages.TankOperationSuccessful, tankName);
            }
        }
    }
}