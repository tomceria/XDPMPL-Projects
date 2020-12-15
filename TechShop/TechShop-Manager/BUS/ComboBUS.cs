using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TechShop_Manager.DAL;

namespace TechShop_Manager.BUS
{
    public partial class Combo
    {
        public static List<Combo> GetAll()
        {
            return ComboDAL.GetAll();
        }

        public static Combo GetOne(int id)
        {
            return ComboDAL.GetOne(id);
        }

        public static Combo CreateOne(Combo combo)
        {
            combo.Slug = ConvertToSlug(combo.Name, combo.Id);
            return ComboDAL.CreateOne(combo);
        }

        public static void UpdateOne(Combo combo)
        {
            ComboDAL.UpdateOne(combo);
        }

        public static void DeleteOne(int id)
        {
            ComboDAL.DeleteOne(id);
        }

        public static string ConvertToUnSign(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }

        public static string ConvertToSlug(string name, int id)
        {
            string unsignName = ConvertToUnSign(name);
            unsignName = unsignName.Replace(" ", "-").ToLower();
            return unsignName;
        }
    }
}
