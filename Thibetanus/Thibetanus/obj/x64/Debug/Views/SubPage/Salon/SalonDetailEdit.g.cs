﻿#pragma checksum "D:\source\UWP\Thibetanus\Thibetanus\Views\SubPage\Salon\SalonDetailEdit.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "4F9DAD7EDBFF4EE61E864D3B2D7653F6"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Thibetanus.Views.SubPage.Salon
{
    partial class SalonDetailEdit : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(global::Windows.UI.Xaml.Controls.ItemsControl obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.ItemsSource = value;
            }
            public static void Set_Windows_UI_Xaml_Controls_TextBlock_Text(global::Windows.UI.Xaml.Controls.TextBlock obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class SalonDetailEdit_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            ISalonDetailEdit_Bindings
        {
            private global::Thibetanus.Views.SubPage.Salon.SalonDetailEdit dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);
            private global::Windows.UI.Xaml.ResourceDictionary localResources;
            private global::System.WeakReference<global::Windows.UI.Xaml.FrameworkElement> converterLookupRoot;

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.ListView obj17;
            private global::Windows.UI.Xaml.Controls.TextBlock obj20;
            private global::Windows.UI.Xaml.Controls.TextBlock obj21;
            private global::Windows.UI.Xaml.Controls.TextBlock obj22;
            private global::Windows.UI.Xaml.Controls.TextBlock obj23;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj17ItemsSourceDisabled = false;
            private static bool isobj20TextDisabled = false;
            private static bool isobj21TextDisabled = false;
            private static bool isobj22TextDisabled = false;
            private static bool isobj23TextDisabled = false;

            private SalonDetailEdit_obj1_BindingsTracking bindingsTracking;

            public SalonDetailEdit_obj1_Bindings()
            {
                this.bindingsTracking = new SalonDetailEdit_obj1_BindingsTracking(this);
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 132 && columnNumber == 45)
                {
                    isobj17ItemsSourceDisabled = true;
                }
                else if (lineNumber == 126 && columnNumber == 24)
                {
                    isobj20TextDisabled = true;
                }
                else if (lineNumber == 127 && columnNumber == 24)
                {
                    isobj21TextDisabled = true;
                }
                else if (lineNumber == 128 && columnNumber == 24)
                {
                    isobj22TextDisabled = true;
                }
                else if (lineNumber == 129 && columnNumber == 24)
                {
                    isobj23TextDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 17: // Views\SubPage\Salon\SalonDetailEdit.xaml line 132
                        this.obj17 = (global::Windows.UI.Xaml.Controls.ListView)target;
                        this.bindingsTracking.RegisterTwoWayListener_17(this.obj17);
                        break;
                    case 20: // Views\SubPage\Salon\SalonDetailEdit.xaml line 126
                        this.obj20 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 21: // Views\SubPage\Salon\SalonDetailEdit.xaml line 127
                        this.obj21 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 22: // Views\SubPage\Salon\SalonDetailEdit.xaml line 128
                        this.obj22 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 23: // Views\SubPage\Salon\SalonDetailEdit.xaml line 129
                        this.obj23 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    default:
                        break;
                }
            }

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                throw new global::System.NotImplementedException();
            }

            public void Recycle()
            {
                throw new global::System.NotImplementedException();
            }

            // ISalonDetailEdit_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
                this.bindingsTracking.ReleaseAllListeners();
                this.initialized = false;
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                this.bindingsTracking.ReleaseAllListeners();
                if (newDataRoot != null)
                {
                    this.dataRoot = (global::Thibetanus.Views.SubPage.Salon.SalonDetailEdit)newDataRoot;
                    return true;
                }
                return false;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }
            public void SetConverterLookupRoot(global::Windows.UI.Xaml.FrameworkElement rootElement)
            {
                this.converterLookupRoot = new global::System.WeakReference<global::Windows.UI.Xaml.FrameworkElement>(rootElement);
            }

            public global::Windows.UI.Xaml.Data.IValueConverter LookupConverter(string key)
            {
                if (this.localResources == null)
                {
                    global::Windows.UI.Xaml.FrameworkElement rootElement;
                    this.converterLookupRoot.TryGetTarget(out rootElement);
                    this.localResources = rootElement.Resources;
                    this.converterLookupRoot = null;
                }
                return (global::Windows.UI.Xaml.Data.IValueConverter) (this.localResources.ContainsKey(key) ? this.localResources[key] : global::Windows.UI.Xaml.Application.Current.Resources[key]);
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::Thibetanus.Views.SubPage.Salon.SalonDetailEdit obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_(obj);
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_Serivces(obj.Serivces, phase);
                    }
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_Code(obj.Code, phase);
                        this.Update_SalonName(obj.SalonName, phase);
                        this.Update_Location(obj.Location, phase);
                        this.Update_Manager(obj.Manager, phase);
                    }
                }
            }
            private void Update_Serivces(global::System.Collections.ObjectModel.ObservableCollection<global::Thibetanus.Models.SubPage.Service.ServiceModel> obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_Serivces(obj);
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Views\SubPage\Salon\SalonDetailEdit.xaml line 132
                    if (!isobj17ItemsSourceDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(this.obj17, obj, null);
                    }
                }
            }
            private void Update_Code(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\SubPage\Salon\SalonDetailEdit.xaml line 126
                    if (!isobj20TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj20, (global::System.String)this.LookupConverter("cvtHeading").Convert(obj, typeof(global::System.String), "编号：", null), null);
                    }
                }
            }
            private void Update_SalonName(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\SubPage\Salon\SalonDetailEdit.xaml line 127
                    if (!isobj21TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj21, (global::System.String)this.LookupConverter("cvtHeading").Convert(obj, typeof(global::System.String), "名称：", null), null);
                    }
                }
            }
            private void Update_Location(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\SubPage\Salon\SalonDetailEdit.xaml line 128
                    if (!isobj22TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj22, (global::System.String)this.LookupConverter("cvtHeading").Convert(obj, typeof(global::System.String), "所属地：", null), null);
                    }
                }
            }
            private void Update_Manager(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\SubPage\Salon\SalonDetailEdit.xaml line 129
                    if (!isobj23TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj23, (global::System.String)this.LookupConverter("cvtHeading").Convert(obj, typeof(global::System.String), "店长：", null), null);
                    }
                }
            }
            private void UpdateTwoWay_17_ItemsSource()
            {
                if (this.initialized)
                {
                    if (this.dataRoot != null)
                    {
                        this.dataRoot.Serivces = (global::System.Collections.ObjectModel.ObservableCollection<global::Thibetanus.Models.SubPage.Service.ServiceModel>)this.obj17.ItemsSource;
                    }
                }
            }

            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private class SalonDetailEdit_obj1_BindingsTracking
            {
                private global::System.WeakReference<SalonDetailEdit_obj1_Bindings> weakRefToBindingObj; 

                public SalonDetailEdit_obj1_BindingsTracking(SalonDetailEdit_obj1_Bindings obj)
                {
                    weakRefToBindingObj = new global::System.WeakReference<SalonDetailEdit_obj1_Bindings>(obj);
                }

                public SalonDetailEdit_obj1_Bindings TryGetBindingObject()
                {
                    SalonDetailEdit_obj1_Bindings bindingObject = null;
                    if (weakRefToBindingObj != null)
                    {
                        weakRefToBindingObj.TryGetTarget(out bindingObject);
                        if (bindingObject == null)
                        {
                            weakRefToBindingObj = null;
                            ReleaseAllListeners();
                        }
                    }
                    return bindingObject;
                }

                public void ReleaseAllListeners()
                {
                    UpdateChildListeners_(null);
                    UpdateChildListeners_Serivces(null);
                }

                public void PropertyChanged_(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    SalonDetailEdit_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        string propName = e.PropertyName;
                        global::Thibetanus.Views.SubPage.Salon.SalonDetailEdit obj = sender as global::Thibetanus.Views.SubPage.Salon.SalonDetailEdit;
                        if (global::System.String.IsNullOrEmpty(propName))
                        {
                            if (obj != null)
                            {
                                bindings.Update_Serivces(obj.Serivces, DATA_CHANGED);
                            }
                        }
                        else
                        {
                            switch (propName)
                            {
                                case "Serivces":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_Serivces(obj.Serivces, DATA_CHANGED);
                                    }
                                    break;
                                }
                                default:
                                    break;
                            }
                        }
                    }
                }
                public void UpdateChildListeners_(global::Thibetanus.Views.SubPage.Salon.SalonDetailEdit obj)
                {
                    SalonDetailEdit_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        if (bindings.dataRoot != null)
                        {
                            ((global::System.ComponentModel.INotifyPropertyChanged)bindings.dataRoot).PropertyChanged -= PropertyChanged_;
                        }
                        if (obj != null)
                        {
                            bindings.dataRoot = obj;
                            ((global::System.ComponentModel.INotifyPropertyChanged)obj).PropertyChanged += PropertyChanged_;
                        }
                    }
                }
                public void PropertyChanged_Serivces(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    SalonDetailEdit_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        string propName = e.PropertyName;
                        global::System.Collections.ObjectModel.ObservableCollection<global::Thibetanus.Models.SubPage.Service.ServiceModel> obj = sender as global::System.Collections.ObjectModel.ObservableCollection<global::Thibetanus.Models.SubPage.Service.ServiceModel>;
                        if (global::System.String.IsNullOrEmpty(propName))
                        {
                        }
                        else
                        {
                            switch (propName)
                            {
                                default:
                                    break;
                            }
                        }
                    }
                }
                public void CollectionChanged_Serivces(object sender, global::System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
                {
                    SalonDetailEdit_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        global::System.Collections.ObjectModel.ObservableCollection<global::Thibetanus.Models.SubPage.Service.ServiceModel> obj = sender as global::System.Collections.ObjectModel.ObservableCollection<global::Thibetanus.Models.SubPage.Service.ServiceModel>;
                    }
                }
                private global::System.Collections.ObjectModel.ObservableCollection<global::Thibetanus.Models.SubPage.Service.ServiceModel> cache_Serivces = null;
                public void UpdateChildListeners_Serivces(global::System.Collections.ObjectModel.ObservableCollection<global::Thibetanus.Models.SubPage.Service.ServiceModel> obj)
                {
                    if (obj != cache_Serivces)
                    {
                        if (cache_Serivces != null)
                        {
                            ((global::System.ComponentModel.INotifyPropertyChanged)cache_Serivces).PropertyChanged -= PropertyChanged_Serivces;
                            ((global::System.Collections.Specialized.INotifyCollectionChanged)cache_Serivces).CollectionChanged -= CollectionChanged_Serivces;
                            cache_Serivces = null;
                        }
                        if (obj != null)
                        {
                            cache_Serivces = obj;
                            ((global::System.ComponentModel.INotifyPropertyChanged)obj).PropertyChanged += PropertyChanged_Serivces;
                            ((global::System.Collections.Specialized.INotifyCollectionChanged)obj).CollectionChanged += CollectionChanged_Serivces;
                        }
                    }
                }
                public void RegisterTwoWayListener_17(global::Windows.UI.Xaml.Controls.ListView sourceObject)
                {
                    sourceObject.RegisterPropertyChangedCallback(global::Windows.UI.Xaml.Controls.ItemsControl.ItemsSourceProperty, (sender, prop) =>
                    {
                        var bindingObj = this.TryGetBindingObject();
                        if (bindingObj != null)
                        {
                            bindingObj.UpdateTwoWay_17_ItemsSource();
                        }
                    });
                }
            }
        }
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // Views\SubPage\Salon\SalonDetailEdit.xaml line 16
                {
                    this.listTextBlock = (global::Windows.UI.Xaml.Style)(target);
                }
                break;
            case 3: // Views\SubPage\Salon\SalonDetailEdit.xaml line 20
                {
                    this.listTextBox = (global::Windows.UI.Xaml.Style)(target);
                }
                break;
            case 4: // Views\SubPage\Salon\SalonDetailEdit.xaml line 24
                {
                    this.listComboBox = (global::Windows.UI.Xaml.Style)(target);
                }
                break;
            case 5: // Views\SubPage\Salon\SalonDetailEdit.xaml line 28
                {
                    this.listButton = (global::Windows.UI.Xaml.Style)(target);
                }
                break;
            case 7: // Views\SubPage\Salon\SalonDetailEdit.xaml line 73
                {
                    global::Windows.UI.Xaml.Controls.Button element7 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element7).Click += this.DelButton_Click;
                }
                break;
            case 9: // Views\SubPage\Salon\SalonDetailEdit.xaml line 63
                {
                    global::Windows.UI.Xaml.Controls.Button element9 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element9).Click += this.DelButton_Click;
                }
                break;
            case 12: // Views\SubPage\Salon\SalonDetailEdit.xaml line 82
                {
                    this.LargeWindow = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 13: // Views\SubPage\Salon\SalonDetailEdit.xaml line 93
                {
                    this.MediumWindow = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 14: // Views\SubPage\Salon\SalonDetailEdit.xaml line 104
                {
                    this.SmallWindow = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 15: // Views\SubPage\Salon\SalonDetailEdit.xaml line 122
                {
                    this.title = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 16: // Views\SubPage\Salon\SalonDetailEdit.xaml line 125
                {
                    this.saloninfo = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 17: // Views\SubPage\Salon\SalonDetailEdit.xaml line 132
                {
                    this.serviceList = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 18: // Views\SubPage\Salon\SalonDetailEdit.xaml line 137
                {
                    global::Windows.UI.Xaml.Controls.Button element18 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element18).Click += this.SaveButton_Click;
                }
                break;
            case 19: // Views\SubPage\Salon\SalonDetailEdit.xaml line 140
                {
                    global::Windows.UI.Xaml.Controls.Button element19 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element19).Click += this.AddButton_Click;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 1: // Views\SubPage\Salon\SalonDetailEdit.xaml line 1
                {                    
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    SalonDetailEdit_obj1_Bindings bindings = new SalonDetailEdit_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    bindings.SetConverterLookupRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                    global::Windows.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element1, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}

