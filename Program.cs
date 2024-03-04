using System.Security.Cryptography.X509Certificates;

namespace uc5
{
    

    internal class Program
    {
        static void Main(string[] args)
        {
          
            int lakewoodWeekdayRegularRate = 110;
            int lakewoodWeekendRegularRate = 90;
            int lakewoodWeekdayRewardsRate = 80;
            int lakewoodWeekendRewardsRate = 80;

            int bridgewoodWeekdayRegularRate = 160;
            int bridgewoodWeekendRegularRate = 60;
            int bridgewoodWeekdayRewardsRate = 110;
            int bridgewoodWeekendRewardsRate = 50;

            int ridgewoodWeekdayRegularRate = 220;
            int ridgewoodWeekendRegularRate = 150;
            int ridgewoodWeekdayRewardsRate = 100;
            int ridgewoodWeekendRewardsRate = 40;

            
            Console.WriteLine("Are you a Regular or Rewards customer?");
            string customerType = Console.ReadLine();
            Console.WriteLine("Enter dates (e.g., 16Mar2020, 17Mar2020, 18Mar2020):");
            string[] dates = Console.ReadLine().Split(',');

            
            int lakewoodTotalRate = CalculateTotalRate(customerType, dates, lakewoodWeekdayRegularRate, lakewoodWeekendRegularRate, lakewoodWeekdayRewardsRate, lakewoodWeekendRewardsRate);
            int bridgewoodTotalRate = CalculateTotalRate(customerType, dates, bridgewoodWeekdayRegularRate, bridgewoodWeekendRegularRate, bridgewoodWeekdayRewardsRate, bridgewoodWeekendRewardsRate);
            int ridgewoodTotalRate = CalculateTotalRate(customerType, dates, ridgewoodWeekdayRegularRate, ridgewoodWeekendRegularRate, ridgewoodWeekdayRewardsRate, ridgewoodWeekendRewardsRate);

            
            string cheapestHotel = FindCheapestHotel(lakewoodTotalRate, bridgewoodTotalRate, ridgewoodTotalRate);
            int cheapestRate = Math.Min(lakewoodTotalRate, Math.Min(bridgewoodTotalRate, ridgewoodTotalRate));

            // Output cheapest hotel and rate
            Console.WriteLine("Cheapest hotel: " + cheapestHotel);
            if(cheapestHotel == "Lakewood")
            {
                Console.WriteLine("hotel rating : 3");
            }else if(cheapestHotel == "Bridgewood")
            {
                Console.WriteLine("hotel rating : 4");
            }
            else
            {
                Console.WriteLine("hotel rating : 5");
            }

            
            Console.WriteLine("Cheapest rate: $" + cheapestRate);
        }

        static int CalculateTotalRate(string customerType, string[] dates, int weekdayRegularRate, int weekendRegularRate, int weekdayRewardsRate, int weekendRewardsRate)
        {
            int totalRate = 0;
            try
            {
                foreach (string date in dates)
                {
                    bool isWeekend = IsWeekend(date);
                    if (customerType.ToLower() == "regular")
                    {
                        totalRate += isWeekend ? weekendRegularRate : weekdayRegularRate;
                    }
                    else if (customerType.ToLower() == "rewards")
                    {
                        totalRate += isWeekend ? weekendRewardsRate : weekdayRewardsRate;
                    }
                    else
                    {
                        throw new InvalidDataException("invalid data enter again...");
                        break;
                    }
                    
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return totalRate;

        }

        static bool IsWeekend(string date)
        {
            DateTime parsedDate;
            if (DateTime.TryParse(date, out parsedDate))
            {
                return parsedDate.DayOfWeek == DayOfWeek.Saturday || parsedDate.DayOfWeek == DayOfWeek.Sunday;
            }
            return false;
        }

        static string FindCheapestHotel(int lakewoodTotalRate, int bridgewoodTotalRate, int ridgewoodTotalRate)
        {
            int minRate = Math.Min(lakewoodTotalRate, Math.Min(bridgewoodTotalRate, ridgewoodTotalRate));
            if (minRate == lakewoodTotalRate)
                return "Lakewood";
            else if (minRate == bridgewoodTotalRate)
                return "Bridgewood";
            else
                return "Ridgewood";
        }
    }




}

   
