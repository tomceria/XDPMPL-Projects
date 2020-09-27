﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.ComponentModel.DataAnnotations;
using System.IO;
using DevExpress.XtraLayout.Helpers;
using DevExpress.XtraLayout;
using TourDuLich_GUI.Models;

namespace TourDuLich_GUI
{
    public partial class EditTourView : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private MainView parent;
        private Tour tour;

        public EditTourView(MainView _parent, Tour _tour)
        {
            /*            dataLayoutControl1.DataSource = GetDataSource();
            */            /*            dataLayoutControl1.RetrieveFields();
                                    List<BaseLayoutItem> flatList = new FlatItemsList().GetItemsList(dataLayoutControl1.Root);
                                    BaseLayoutItem aboutItem = flatList.First(e => e.Text == "About");
                                    aboutItem.TextLocation = DevExpress.Utils.Locations.Top;
                        */
            InitializeComponent();
            parent = _parent;
            tour = _tour;

            dataLayoutControl_Tour.DataSource = GetTourDataSource();
            listBoxControl_Destination.DataSource = GetDestinationDataSource();
            LookUpEdit_TourType.Properties.DataSource = GetTourTypeDataSource();
        }

        public BindingList<Tour> GetTourDataSource()
        {
            BindingList<Tour> result = new BindingList<Tour>();
            result.Add(tour);
            return result;
        }

        public BindingList<Destination> GetDestinationDataSource()
        {
            BindingList<Destination> result = new BindingList<Destination>();
            foreach (Destination d in parent.destinations) {
                result.Add(d);
            }
            return result;
        }
        public BindingList<TourType> GetTourTypeDataSource()
        {
            BindingList<TourType> result = new BindingList<TourType>();
            foreach (TourType tt in parent.tourTypes) {
                result.Add(tt);
            }
            return result;
        }

        private void getState ()
        {
            Console.WriteLine($"{tour.Name}, {tour.PriceRef}, {tour.TourPrices.ElementAt(0).Value}, {tour.TourType.Name}, {tour.TourType.ID}");
            Console.WriteLine($"{LookUpEdit_TourType.GetSelectedDataRow()}");
        }

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            getState();
        }
    }
}
