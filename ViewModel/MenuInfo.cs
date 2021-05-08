﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GeekDesk.ViewModel
{

    [Serializable]
    class MenuInfo : INotifyPropertyChanged
    {
        [field: NonSerializedAttribute()]
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string menuName;
        private string menuId;
        private int menuEdit = (int)Visibility.Collapsed;
        private int notMenuEdit = (int)Visibility.Visible;

        public string MenuName
        {
            get
            {
                return menuName;
            }
            set
            {
                menuName = value;
                OnPropertyChanged("MenuName");
            }
        }

        public string MenuId
        {
            get
            {
                return menuId;
            }
            set
            {
                menuId = value;
                OnPropertyChanged("MenuId");
            }
        }

        public int MenuEdit
        {
            get
            {
                return menuEdit;
            }
            set
            {
                menuEdit = value;
                if (menuEdit == (int)Visibility.Visible)
                {
                    NotMenuEdit = (int)Visibility.Collapsed;
                } else
                {
                    NotMenuEdit = (int)Visibility.Visible;
                }
                OnPropertyChanged("MenuEdit");
            }
        }

        public int NotMenuEdit
        {
            get
            {
                return notMenuEdit;
            }
            set
            {
                notMenuEdit = value;
                OnPropertyChanged("NotMenuEdit");
            }
        }
    }
}
