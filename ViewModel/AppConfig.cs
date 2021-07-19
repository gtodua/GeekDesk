﻿
using GeekDesk.Constant;
using GeekDesk.Util;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

/// <summary>
/// 程序设置
/// </summary>
namespace GeekDesk.ViewModel
{

    [Serializable]
    public class AppConfig : INotifyPropertyChanged
    {
        private SortType menuSortType = SortType.CUSTOM; //菜单排序类型
        private SortType iconSortType = SortType.CUSTOM; //图表排序类型
        private double windowWidth = (double)MainWindowEnum.WINDOW_WIDTH;  //窗口宽度
        private double windowHeight = (double)MainWindowEnum.WINDOW_HEIGHT; //窗口高度
        private double menuCardWidth = (double)MainWindowEnum.MENU_CARD_WIDHT;//菜单栏宽度
        private int selectedMenuIndex = 0;  //上次选中菜单索引
        private bool followMouse = true;  //面板跟随鼠标 默认是
        private Visibility configIconVisible = Visibility.Visible; // 设置按钮是否显示
        private AppHideType appHideType = AppHideType.START_EXE;  //面板关闭方式 (默认启动程序后)
        private bool startedShowPanel = true;  //启动时是否显示主面板  默认显示
        [field: NonSerialized]
        private BitmapImage bitmapImage; //位图
        private byte[] imageByteArr; //背景图片 byte数组
        private string bacImgName = "系统默认";
        private int cardOpacity = 10;  //默认0.1的不透明度  此处显示数值 * 100
        private int bgOpacity = 100; // 背景图片不透明度 此处显示数值 * 100
        private int pannelOpacity = 100; //主面板不透明度 此处显示数值 * 100
        private int pannelCornerRadius = 4;  //面板圆角 默认4
        [field: NonSerialized]
        private ObservableCollection<IconInfo> selectedMenuIcons;

        private string hotkeyStr = "Ctrl + Q";  //默认启动面板快捷键
        private HotkeyModifiers hotkeyModifiers = HotkeyModifiers.MOD_CONTROL; //默认启动面板快捷键
        private Key hotkey = Key.Q; //默认启动面板快捷键

        private string toDoHotkeyStr;  //待办任务快捷键
        private HotkeyModifiers toDoHotkeyModifiers; //待办任务快捷键
        private Key toDoHotkey; //待办任务快捷键

        private string customIconUrl; //自定义图标url
        private string customIconJsonUrl;  //自定义图标json信息url

        private bool blurEffect = false; //毛玻璃效果 默认否
        private double blurValue;

        private UpdateType updateType = UpdateType.Gitee; //更新源 默认gitee源

        #region GetSet


        public Key ToDoHotkey
        {
            get
            {
                return toDoHotkey;
            }
            set
            {
                toDoHotkey = value;
                OnPropertyChanged("ToDoHotkey");
            }
        }


        public HotkeyModifiers ToDoHotkeyModifiers
        {
            get
            {
                return toDoHotkeyModifiers;
            }
            set
            {
                toDoHotkeyModifiers = value;
                OnPropertyChanged("ToDoHotkeyModifiers");
            }
        }

        public string ToDoHotkeyStr
        {
            get
            {
                return toDoHotkeyStr;
            }
            set
            {
                toDoHotkeyStr = value;
                OnPropertyChanged("ToDoHotkeyStr");
            }
        }

        public UpdateType UpdateType
        {
            get
            {
                return updateType;
            }
            set
            {
                updateType = value;
                OnPropertyChanged("UpdateType");
            }
        }

        public double BlurValue
        {
            get
            {
                return blurValue;
            }
            set
            {
                blurValue = value;
                OnPropertyChanged("BlurValue");
            }
        }

        public bool BlurEffect
        {
            get
            {
                return blurEffect;
            }
            set
            {
                blurEffect = value;
                if (blurEffect)
                {
                    BlurValue = 100;
                } else
                {
                    BlurValue = 0;
                }
                OnPropertyChanged("BlurEffect");
            }
        }
        public string CustomIconUrl
        {
            get
            {
                return customIconUrl;
            }
            set
            {
                customIconUrl = value;
                OnPropertyChanged("CustomIconUrl");
            }
        }
        public string CustomIconJsonUrl
        {
            get
            {
                return customIconJsonUrl;
            }
            set
            {
                customIconJsonUrl = value;
                OnPropertyChanged("CustomIconJsonUrl");
            }
        }
        public Key Hotkey
        {
            get
            {
                return hotkey;
            }
            set
            {
                hotkey = value;
                OnPropertyChanged("Hotkey");
            }
        }
        public string HotkeyStr
        {
            get
            {
                return hotkeyStr;
            }
            set
            {
                hotkeyStr = value;
                OnPropertyChanged("HotkeyStr");
            }
        }
        public HotkeyModifiers HotkeyModifiers
        {
            get
            {
                return hotkeyModifiers;
            }
            set
            {
                hotkeyModifiers = value;
                OnPropertyChanged("HotkeyModifiers");
            }
        }

        public ObservableCollection<IconInfo> SelectedMenuIcons
        {
            get
            {
                return selectedMenuIcons;
            }
            set
            {
                selectedMenuIcons = value;
                OnPropertyChanged("SelectedMenuIcons");
            }
        }

        public int PannelCornerRadius
        {
            get
            {
                return pannelCornerRadius;
            }
            set
            {
                pannelCornerRadius = value;
                OnPropertyChanged("pannelCornerRadius");
            }
        }

        public int PannelOpacity
        {
            get
            {
                return pannelOpacity;
            }
            set
            {
                pannelOpacity = value;
                OnPropertyChanged("PannelOpacity");
            }
        }
        public int BgOpacity
        {
            get
            {
                return bgOpacity;
            }
            set
            {
                bgOpacity = value;
                OnPropertyChanged("BgOpacity");
            }
        }

        public int CardOpacity
        {
            get
            {
                return cardOpacity;
            }
            set
            {
                cardOpacity = value;
                OnPropertyChanged("CardOpacity");
            }
        }

        public string BacImgName
        {
            get
            {
                return bacImgName;
            }
            set
            {
                bacImgName = value;
                OnPropertyChanged("BacImgName");
            }
        }

        public byte[] ImageByteArr
        {
            get
            {
                return imageByteArr;
            }
            set
            {
                imageByteArr = value;
                OnPropertyChanged("ImageByteArr");
            }
        }


        public BitmapImage BitmapImage
        {
            get
            {
                if (imageByteArr == null || imageByteArr.Length == 0)
                {
                    bacImgName = "系统默认";
                    //Image image = ImageUtil.ByteArrayToImage(Convert.FromBase64String(Constants.DEFAULT_BAC_IMAGE_BASE64));
                    return ImageUtil.ByteArrToImage(Convert.FromBase64String(Constants.DEFAULT_BAC_IMAGE_BASE64));
                } else
                {
                    return ImageUtil.ByteArrToImage(ImageByteArr);
                }
            }
            set
            {
                bitmapImage = value;
                imageByteArr = ImageUtil.BitmapImageToByte(bitmapImage);
                OnPropertyChanged("BitmapImage");
            }
        }


        public bool StartedShowPanel
        {
            get
            {
                return startedShowPanel;
            }
            set
            {
                startedShowPanel = value;
                OnPropertyChanged("StartedShowPanel");
            }
        }

        public AppHideType AppHideType
        {
            get
            {
                return appHideType;
            }
            set
            {
                appHideType = value;
                OnPropertyChanged("AppHideType");
            }
        }

        public Visibility ConfigIconVisible
        {
            get
            {
                return configIconVisible;
            }
            set
            {
                configIconVisible = value;
                OnPropertyChanged("ConfigIconVisible");
            }
        }


        public bool FollowMouse
        {
            get
            {
                return followMouse;
            }
            set
            {
                followMouse = value;
                OnPropertyChanged("FollowMouse");
            }
        }

        public int SelectedMenuIndex
        {
            get
            {
                return selectedMenuIndex;
            }
            set
            {
                selectedMenuIndex = value;
                OnPropertyChanged("SelectedMenuIndex");
            }
        }

        public SortType MenuSortType
        {
            get
            {
                return menuSortType;
            }
            set
            {
                menuSortType = value;
                OnPropertyChanged("MenuSortType");
            }
        }

        public SortType IconSortType
        {
            get
            {
                return iconSortType;
            }
            set
            {
                iconSortType = value;
                OnPropertyChanged("IconSortType");
            }
        }

        public double WindowWidth
        {
            get
            {
                return windowWidth;
            }
            set
            {
                windowWidth = value;
                OnPropertyChanged("WindowWidth");
            }
        }

        public double WindowHeight
        {
            get
            {
                return windowHeight;
            }
            set
            {
                windowHeight = value;
                OnPropertyChanged("WindowHeight");
            }
        }

        public double MenuCardWidth
        {
            get
            {
                return menuCardWidth;
            }
            set
            {
                menuCardWidth = value;
                OnPropertyChanged("MenuCardWidth");
            }
        }

        [field: NonSerializedAttribute()]
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            CommonCode.SaveAppData(MainWindow.appData);
        }

        #endregion

    }
}
