using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Repositories.Models;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Booths.Models
{
    public class Booth : IBooth
    {   private int boothId;
        private int capacity;
        private IRepository<IDelicacy> delicacyMenu;
        private IRepository<ICocktail> cocktailMenu;
        public Booth(int boothId, int capacity)
        {
            BoothId = boothId;
            Capacity = capacity;
            delicacyMenu = new DelicacyRepository();
            cocktailMenu = new CocktailRepository();
        }

        public int BoothId { get { return boothId; } private set { boothId = value; } }

        public int Capacity
        {
            get { return capacity; }
            private set
            {
                if (value<=0)
                {
                    throw new ArgumentException(ExceptionMessages.CapacityLessThanOne);
                }
                capacity = value; } }

        public IRepository<IDelicacy> DelicacyMenu => delicacyMenu;

        public IRepository<ICocktail> CocktailMenu =>cocktailMenu;

        public double CurrentBill { get; private set; } = 0;

        public double Turnover { get; private set; } = 0;

        public bool IsReserved { get; private set; } =false;

        public void ChangeStatus()
        {
            if (IsReserved)
            {
                IsReserved = false;
            }
            else
            {
                IsReserved= true;   
            }
        }

        public void Charge()
        {
            Turnover += CurrentBill;
            CurrentBill = 0;
        }

        public void UpdateCurrentBill(double amount)
        {
            CurrentBill += amount;
        }
        public override string ToString()
        {
            StringBuilder stringBuilder= new StringBuilder();
            stringBuilder.AppendLine($"Booth: {boothId}");
            stringBuilder.AppendLine($"Capacity: {capacity}");
            stringBuilder.AppendLine($"Turnover: {Turnover:f2} lv");
            stringBuilder.AppendLine($"-Cocktail menu:");
            foreach (var item in CocktailMenu.Models)
            {
                stringBuilder.AppendLine($"--{item}");
            }
            stringBuilder.AppendLine($"-Delicacy menu");
            foreach (var item in DelicacyMenu.Models)
            {
                stringBuilder.AppendLine($"--{item}");
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
