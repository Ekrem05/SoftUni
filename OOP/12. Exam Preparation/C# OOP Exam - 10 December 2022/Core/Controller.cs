using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Booths.Models;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Cocktails.Models;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Models.Delicacies.Models;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Repositories.Models;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private IRepository<IBooth> booths;
       
        public Controller()
        {
            booths = new BoothRepository();
          
        }
        public string AddBooth(int capacity)
        {
            IBooth booth = new Booth(booths.Models.Count + 1,capacity);
            booths.AddModel(booth);
            return String.Format(OutputMessages.NewBoothAdded, booth.BoothId, capacity);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            if (cocktailTypeName!= "Hibernation"&&cocktailTypeName!="MulledWine")
            {
                return String.Format(OutputMessages.InvalidCocktailType,cocktailTypeName);
            }
            if (size!="Small"&& size != "Middle" && size != "Large")
            {
                return String.Format(OutputMessages.InvalidCocktailSize, size);
            }
            if (booths.Models.Any(x=>x.CocktailMenu.Models.Any(x=>x.Name==cocktailName&&x.Size==size)))
            {
                return String.Format(OutputMessages.CocktailAlreadyAdded,size,cocktailName);
            }
            ICocktail cocktail;
            if (cocktailTypeName =="Hibernation")
            {
                cocktail = new Hibernation(cocktailName, size);

            }
            else
            {
                 cocktail = new MulledWine(cocktailName, size);
            }

           IBooth booth=booths.Models.FirstOrDefault(x => x.BoothId == boothId);
              booth.CocktailMenu.AddModel(cocktail);
            return String.Format(OutputMessages.NewCocktailAdded, size, cocktailName,cocktailTypeName);
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            IDelicacy delicacy;
            if (delicacyTypeName!="Gingerbread"&& delicacyTypeName != "Stolen")
            {
                return String.Format(OutputMessages.InvalidDelicacyType,delicacyTypeName);
            }
            
            if (booths.Models.Any(x=>x.DelicacyMenu.Models.Any(x=>x.Name==delicacyName)))
            {
                return String.Format(OutputMessages.DelicacyAlreadyAdded, delicacyTypeName,delicacyName);
            }
            if (delicacyName=="Stolen")
            {
                delicacy = new Stolen(delicacyName);
            }
            else
            {
                delicacy = new Gingerbread(delicacyName);
            }
            IBooth booth=booths.Models.FirstOrDefault(x=>x.BoothId==boothId);
            booth.DelicacyMenu.AddModel(delicacy);
            return String.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }

        public string BoothReport(int boothId)
        {
            return this.booths.Models.FirstOrDefault(b => b.BoothId == boothId).ToString().TrimEnd();
        }

        public string LeaveBooth(int boothId)
        {
            IBooth booth= booths.Models.FirstOrDefault(x=>x.BoothId== boothId);         
            booth.Charge();
            booth.ChangeStatus();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Bill {booth.Turnover:f2} lv");
            sb.AppendLine($"Booth {boothId} is now available!");
            return sb.ToString().TrimEnd();
        }

        public string ReserveBooth(int countOfPeople)
        {
            var booth = this.booths.Models
                .Where(b => b.IsReserved == false && b.Capacity >= countOfPeople)
                .OrderBy(b => b.Capacity)
                .ThenByDescending(b => b.BoothId)
                .FirstOrDefault();

           
            if (booth==null)
            {
                return String.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }
            booth.ChangeStatus();
            return String.Format(OutputMessages.BoothReservedSuccessfully,booth.BoothId,countOfPeople);
        }

        public string TryOrder(int boothId, string order)
        {
            string itemTypeName = order.Split('/')[0];
            string itemName = order.Split('/')[1];
            int count = int.Parse(order.Split('/')[2]);
            bool added= false;
            IBooth booth = booths.Models.FirstOrDefault(x => x.BoothId == boothId);

            if (itemTypeName=="MulledWine"||itemTypeName=="Hibernation")
            {
                string size = order.Split('/')[3];
               
                
               
                if (!booths.Models.Any(x=>x.CocktailMenu.Models.Any(x=>x.Name==itemName)))
                {
                    return String.Format(OutputMessages.NotRecognizedItemName, size,itemName);
                }
                if (itemTypeName == "MulledWine")
                {
                    ICocktail cocktail1=new MulledWine(itemName, size);
                    booth.UpdateCurrentBill(cocktail1.Price*count);
                    added = true;
                    return String.Format(OutputMessages.SuccessfullyOrdered, boothId,count, itemName);
                   

                }
                else
                {
                    ICocktail cocktail1 = new Hibernation(itemName, size);
                    booth.UpdateCurrentBill(cocktail1.Price * count);
                    added = true;
                    return String.Format(OutputMessages.SuccessfullyOrdered, boothId, count, itemName);
                }
            }
            else if (itemTypeName == "Gingerbread" || itemTypeName == "Stolen")
            {
                IDelicacy delicacy;
                if (!booths.Models.Any(x => x.DelicacyMenu.Models.Any(x => x.Name == itemName)))
                {
                    return String.Format(OutputMessages.NotRecognizedItemName,itemTypeName, itemName);
                }
                if (itemTypeName == "Gingerbread")
                {
                    IDelicacy cocktail1 = new Gingerbread(itemName);
                    booth.UpdateCurrentBill(cocktail1.Price * count);
                    added = true;
                    return String.Format(OutputMessages.SuccessfullyOrdered, boothId, count, itemName);

                }
                else
                {
                    IDelicacy cocktail1 = new Stolen(itemName);
                    booth.UpdateCurrentBill(cocktail1.Price * count);
                    added = true;
                    return String.Format(OutputMessages.SuccessfullyOrdered, boothId, count, itemName);
                }
            }
            else
            {
                return String.Format(OutputMessages.NotRecognizedItemName, itemTypeName);

            }
                
            
        }
    }
}
