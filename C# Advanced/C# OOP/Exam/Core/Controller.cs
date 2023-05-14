using RobotService.Core.Contracts;
using RobotService.Models.Contracts;
using RobotService.Models.Robot;
using RobotService.Models.Supplement;
using RobotService.Repositories;
using RobotService.Repositories.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private string[] robotChilds = new string[2] { "DomesticAssistant", "IndustrialAssistant"};
        private string[] supplementChilds = new string[2] { "LaserRadar", "SpecializedArm" };
        private IRepository<ISupplement> supplements;
        private IRepository<IRobot> robots;
        public Controller()
        {
            supplements = new SupplementRepository();
            robots = new RobotRepository();

        }

        public string CreateRobot(string model, string typeName)
        {
            if (!robotChilds.Contains(typeName))
            {
                return string.Format(OutputMessages.RobotCannotBeCreated,typeName);
            }
            IRobot robot;
            if (typeName== "DomesticAssistant")
            {
                 robot = new DomesticAssistant(model);
            }
            else
            {
                 robot = new IndustrialAssistant(model);
            }
            robots.AddNew(robot);
            return string.Format(OutputMessages.RobotCreatedSuccessfully, typeName,model);
        }

        public string CreateSupplement(string typeName)
        {
            if (!supplementChilds.Contains(typeName))
            {
                return string.Format(OutputMessages.SupplementCannotBeCreated, typeName);
            }
            ISupplement supp;
            if (typeName == "LaserRadar")
            {
                supp = new LaserRadar();
            }
            else
            {
                supp = new SpecializedArm();
            }
            supplements.AddNew(supp);
            return string.Format(OutputMessages.SupplementCreatedSuccessfully, typeName);
        }

        public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)
        {
         
            List<IRobot> robotsCollection = robots.Models().Where(x => x.InterfaceStandards.Contains(intefaceStandard) == true).ToList();
            if (robotsCollection.Count==0)
            {
                return string.Format(OutputMessages.UnableToPerform, intefaceStandard);
            }
            robotsCollection=robotsCollection.OrderByDescending(x => x.BatteryLevel).ToList();
            int sum=robotsCollection.Sum(x => x.BatteryLevel);
            int counter = 0;
            if (sum < totalPowerNeeded)
            {
                return string.Format(OutputMessages.MorePowerNeeded, serviceName, (totalPowerNeeded - sum));
            }
            else if (sum >= totalPowerNeeded)
            {

                while (totalPowerNeeded > 0)
                {
                    foreach (var robot in robotsCollection)
                    {
                        if (robot.BatteryLevel>=totalPowerNeeded)
                        {
                            robot.ExecuteService(totalPowerNeeded);
                            totalPowerNeeded = 0;
                            counter++;
                            break;
                        }
                        else 
                        {
                            totalPowerNeeded -= robot.BatteryLevel;
                            robot.ExecuteService(robot.BatteryLevel);
                            counter++;
                        }
                    }
                }
            }
            return string.Format(OutputMessages.PerformedSuccessfully, serviceName, counter);

        }

        public string Report()
        {
            StringBuilder sb = new();
            foreach (var robot in robots.Models().OrderByDescending(x=>x.BatteryLevel).ThenBy(x=>x.BatteryCapacity))
            {
                sb.AppendLine(robot.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        public string RobotRecovery(string model, int minutes)
        {//KUSANGI - 0
            List<IRobot> robotsCollection = robots.Models().Where(x => x.BatteryLevel < x.BatteryCapacity * 0.5).Where(x=>x.Model==model).ToList();
            int count = 0;
            robotsCollection.ForEach(x => { x.Eating(minutes);count++; });
            return string.Format(OutputMessages.RobotsFed, count);

        }

        public string UpgradeRobot(string model, string supplementTypeName)
        {
            int interfaceValue = supplements.Models().FirstOrDefault(x => x.GetType().Name == supplementTypeName).InterfaceStandard;
            List<IRobot> robotsCollection = robots.Models().Where(x => x.InterfaceStandards.Contains(interfaceValue) == false).ToList();
            robotsCollection = robotsCollection.Where(x => x.Model == model).ToList();
            if (robotsCollection.Count==0)
            {
                return string.Format(OutputMessages.AllModelsUpgraded,model);
            }
            ISupplement supp;
            if (supplementTypeName == "LaserRadar")
            {
                supp = new LaserRadar();
            }
            else
            {
                supp = new SpecializedArm();
            }
            IRobot robot = robotsCollection[0];
            robot.InstallSupplement(supp);
            supplements.RemoveByName(supplementTypeName);
            return string.Format(OutputMessages.UpgradeSuccessful, model,supplementTypeName);

        }
        
        

    }
}
