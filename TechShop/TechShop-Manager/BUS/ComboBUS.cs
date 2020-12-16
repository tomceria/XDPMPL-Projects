using System.Collections.Generic;
using TechShop_Manager.Common.Utilities;
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

        public static void DeleteOne(int id)
        {
            ComboDAL.DeleteOne(id);
        }

        public Combo Add()
        {
            this.Slug = string.Join("-", StringUtil.ConvertToUnsign(this.Name).ToLower()); 
            ComboDAL.AddOne(this);
            
            this.Slug = $"{this.Slug}-{this.Id}"; 
            ComboDAL.UpdateOne(this);

            return this;
        }

        public void AddComboDetail(ComboDetail comboDetail)
        {
            ComboDAL.AddComboDetail(comboDetail);
        }

        public void DeleteComboDetail(ComboDetail comboDetail)
        {
            ComboDAL.DeleteComboDetail(comboDetail);
        }

        public void Update()
        {
            ComboDAL.UpdateOne(this);
        }
        
        public static void RevertChanges()
        {
            ComboDAL.Reload();
        }
    }
}