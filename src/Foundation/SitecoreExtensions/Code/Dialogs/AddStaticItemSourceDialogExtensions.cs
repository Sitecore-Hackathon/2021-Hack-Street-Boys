using Sitecore;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Globalization;
using Sitecore.Install.Framework;
using Sitecore.Install.Items;
using Sitecore.Install.Utils;
using Sitecore.Links;
using Sitecore.Shell.Applications.Install;
using Sitecore.Shell.Applications.Install.Controls;
using Sitecore.Web.UI.HtmlControls;
using Sitecore.Web.UI.Pages;
using Sitecore.Web.UI.Sheer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using HackstreetBoys.Foundation.SitecoreExtensions.PackageEntries;
using Sitecore.Install.Filters;
using Sitecore.Layouts;
using Sitecore.Data.Fields;
using Sitecore.DependencyInjection;
using Sitecore.Abstractions;
using Sitecore.Pipelines.ResolveRenderingDatasource;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace HackstreetBoys.Foundation.SitecoreExtensions.Dialogs
{
    /// <summary></summary>
    public class AddStaticItemSourceDialogExtensions : WizardForm
    {
        /// <summary></summary>
        protected Sitecore.Web.UI.HtmlControls.Combobox Languages;

        /// <summary></summary>
        protected Sitecore.Web.UI.HtmlControls.Literal NoLanguageLabel;

        /// <summary></summary>
        protected DataContext DataContext;

        /// <summary></summary>
        protected Combobox Databases;

        /// <summary></summary>
        protected DataTreeview Treeview;

        /// <summary></summary>
        protected Listview ItemList;

        /// <summary></summary>
        protected NameEditor Name;

        public AddStaticItemSourceDialogExtensions()
        {
        }

        /// <summary></summary>
        protected override void ActivePageChanged(string page, string oldPage)
        {
            base.ActivePageChanged(page, oldPage);
            if (page == "LastPage")
            {
                this.BackButton.Disabled = true;
            }
        }

        private void BindLanguages(Combobox list, string databaseName)
        {

            if (list != null)
            {
                list.Controls.Clear();
                Database database = Factory.GetDatabase(databaseName);
                ListItem emptyItem = new ListItem()
                {
                    ID = Sitecore.Web.UI.HtmlControls.Control.GetUniqueID("Language")
                };
                emptyItem.Selected = true;
                list.Controls.Add(emptyItem);
                if (database != null)
                {
                    Language[] languages = database.Languages;
                    Language[] languageArray = languages;
                    for (int i = 0; i < (int)languageArray.Length; i++)
                    {
                        Language language = languageArray[i];
                        ListItem checklistItem = new ListItem()
                        {
                            ID = Sitecore.Web.UI.HtmlControls.Control.GetUniqueID("Language")
                        };
                        list.Controls.Add(checklistItem);
                        checklistItem.Header = language.CultureInfo.DisplayName;
                        checklistItem.Value = language.Name;
                    }

                }
                Context.ClientPage.ClientResponse.Refresh(list);
            }
        }

        private void AddEntry(Sitecore.Data.Items.Item Item, string type, string icon)
        {
            Context.ClientPage.ClientResponse.DisableOutput();
            ListviewItem listviewItem = null;
            try
            {
                listviewItem = new ListviewItem()
                {
                    ID = Sitecore.Web.UI.HtmlControls.Control.GetUniqueID("ListItem")
                };
                Context.ClientPage.AddControl(this.ItemList, listviewItem);
                string str = Item.Uri.ToString();
                listviewItem.Icon = icon;
                listviewItem.Header = string.Format("{0}, {1}:{2}", Translate.Text(type), Item.Database.Name, Item.Paths.Path);
                listviewItem.Value = string.Format("{0}:{1}", type, str);
            }
            finally
            {
                Context.ClientPage.ClientResponse.EnableOutput();
            }
            Context.ClientPage.ClientResponse.Refresh(this.ItemList);
        }

        /// <summary>
        /// Adds the item.
        /// </summary>
        public void AddItem()
        {
            this.AddEntry(this.DataContext.GetFolder(), "single", "office/16x16/document_empty.png");
        }

        /// <summary>
        /// Adds the tree.
        /// </summary>
        public void AddTree()
        {
            this.AddEntry(this.DataContext.GetFolder(), "recursive", "office/16x16/elements_cascade.png");
        }

        /// <summary>
        /// Adds the item with all related Media Items
        /// </summary>
        public void AddItemWithMedia()
        {
            this.AddEntry(this.DataContext.GetFolder(), "singleWithMedia", "office/16x16/document_empty.png");
        }

        public void AddItemWithDataSources()
        {
            this.AddEntry(this.DataContext.GetFolder(), "singleWithDataSources", "office/16x16/document_empty.png");
        }

        private void Bind()
        {
            this.Name.BindTo(ApplicationContext.DocumentHolder.Document);
        }

        private void BuildDatabases(string selectedName)
        {
            string[] databaseNames = Factory.GetDatabaseNames();
            for (int i = 0; i < (int)databaseNames.Length; i++)
            {
                string str = databaseNames[i];
                if (!Factory.GetDatabase(str).ReadOnly)
                {
                    ListItem listItem = new ListItem();
                    this.Databases.Controls.Add(listItem);
                    listItem.ID = Sitecore.Web.UI.HtmlControls.Control.GetUniqueID("ListItem");
                    listItem.Header = str;
                    listItem.Value = str;
                    listItem.Selected = str == selectedName;
                }
            }
        }

        /// <summary>
        /// Changes the database.
        /// </summary>
        public void ChangeDatabase()
        {
            this.DataContext.Parameters = string.Concat("databasename=", this.Databases.Value);
            this.Treeview.RefreshRoot();
        }

        /// <summary></summary>
        protected override void EndWizard()
        {
            SourceCollection<PackageEntry> sourceCollection = new SourceCollection<PackageEntry>();
            ExplicitItemSource explicitItemSource = new ExplicitItemSource();
            sourceCollection.Add(explicitItemSource);
            ListviewItem[] items = this.ItemList.Items;
            for (int i = 0; i < (int)items.Length; i++)
            {
                string value = items[i].Value;
                string[] strArrays = value.Split(new char[] { ':' }, 2);
                ItemUri itemUri = ItemUri.Parse(strArrays[1]);
                string str = strArrays[0];
                if (str == "recursive")
                {
                    //ExtendedItemSource itemSource = new ExtendedItemSource()
                    ItemSource itemSource = new ItemSource()
                    {
                        SkipVersions = true,
                        Database = itemUri.DatabaseName,
                        Root = itemUri.ItemID.ToString()
                    };
                    sourceCollection.Add(itemSource);
                }
                else if (str == "single")
                {
                    explicitItemSource.Entries.Add((new ItemReference(itemUri, false)).ToString());
                }
                else if (str == "singleWithMedia")
                {
                    //Add the single item
                    explicitItemSource.Entries.Add((new ItemReference(itemUri, false)).ToString());

                    //Get item links from link database to get related media
                    var item = Database.GetItem(itemUri);
                    getRelatedMediaItems(item, explicitItemSource);
                }
                else if (str == "singleWithDataSources")
                {
                    var item = Database.GetItem(itemUri);
                    if (item != null)
                    {
                        //Add the single item
                        explicitItemSource.Entries.Add((new ItemReference(itemUri, false)).ToString());
                        getRelatedMediaItems(item, explicitItemSource);

                        //Get all added renderings
                        Sitecore.Layouts.RenderingReference[] renderings = item.Visualization.GetRenderings(Sitecore.Context.Device, true);

                        // Get the layout definitions and the device
                        LayoutField layoutField = new LayoutField(item.Fields[Sitecore.FieldIDs.LayoutField]);
                        LayoutDefinition layoutDefinition = LayoutDefinition.Parse(layoutField.Value);
                        DeviceDefinition deviceDefinition = layoutDefinition.GetDevice(Sitecore.Context.Device.ID.ToString());
                        foreach (RenderingReference rendering in renderings)
                        {
                            //inject pipeline manager (instead of ServiceLocator you can use constructor injection if needed)
                            BaseCorePipelineManager pipelineManager = ServiceLocator.ServiceProvider.GetService<BaseCorePipelineManager>();

                            //create pipeline arguments where you put data source string
                            var args = new ResolveRenderingDatasourceArgs(rendering.Settings.DataSource);
                            args.CustomData["contextItem"] = item;

                            //run the pipeline
                            pipelineManager.Run("resolveRenderingDatasource", args);

                            var datasourceItem = Sitecore.Configuration.Factory.GetDatabase("master").GetItem(args.Datasource);
                            if (datasourceItem != null)
                            {
                                explicitItemSource.Entries.Add((new ItemReference(datasourceItem)).ToString());
                                getRelatedMediaItems(datasourceItem, explicitItemSource);
                            }
                        }
                    }

                }
            }

            ExplicitItemSource.Builder builder = new ExplicitItemSource.Builder(ApplicationContext.DocumentHolder.Document as ExplicitItemSource);
            builder.Initialize(new SimpleProcessingContext());
            (new EntrySorter(sourceCollection)).Populate(new Uniq(builder));
            if (!string.IsNullOrEmpty(Languages.Value))
            {
                Language lng;
                if (Language.TryParse(Languages.Value, out lng))
                {
                    //itemSource.Language = lng;
                    var filter = new ItemLanguageFilter();
                    filter.Languages = Languages.Value;
                    builder.Source.Include.Add(filter);
                }
            }
            builder.Finish();
            string str1 = ApplicationContext.StoreObject(builder.Source);
            Context.ClientPage.ClientResponse.SetDialogValue(str1);
            base.EndWizard();
        }

        private void getRelatedMediaItems(Item item, ExplicitItemSource explicitItemSource)
        {
            ItemLink[] itemLinks = Globals.LinkDatabase.GetItemReferences(item, false);
            if (itemLinks != null)
            {
                var linkedItems = itemLinks.Select(x => x.GetTargetItem()).Where(x => x != null && x.Paths.IsMediaItem);
                foreach (var linkedItem in linkedItems)
                {
                    explicitItemSource.Entries.Add((new ItemReference(linkedItem.Uri, false)).ToString());
                }
            }
        }


        /// <summary>
        /// Lists the context menu.
        /// </summary>
        public void ListContextMenu()
        {
            if (Context.ClientPage.FindControl(Context.ClientPage.ClientRequest.Source) is ListviewItem)
            {
                Context.ClientPage.ClientResponse.DisableOutput();
                Menu menu = new Menu();
                MenuItem menuItem = new MenuItem();
                Context.ClientPage.AddControl(menu, menuItem);
                menuItem.Header = "Remove";
                menuItem.Icon = "office/16x16/delete.png";
                menuItem.Click = string.Concat("Remove(\"", Context.ClientPage.ClientRequest.Source, "\")");
                Context.ClientPage.ClientResponse.EnableOutput();
                Context.ClientPage.ClientResponse.ShowContextMenu(string.Empty, "right", menu);
            }
        }

        /// <summary>
        /// Called when this instance has bind.
        /// </summary>
        /// <param name="message">The message.</param>
        [HandleMessage("document:bind")]
        public void OnBind(Message message)
        {
            this.Bind();
        }

        /// <summary></summary>
        protected override void OnLoad(EventArgs e)
        {
            if (!Context.ClientPage.IsEvent)
            {
                this.DataContext.GetFromQueryString();
                Item folder = this.DataContext.GetFolder();
                this.BuildDatabases((folder == null ? string.Empty : folder.Database.Name));
                ApplicationContext.AttachDocument(new ExplicitItemSource());
                this.Bind();

                this.BindLanguages(this.Languages, "master");
            }
            base.OnLoad(e);
        }

        /// <summary>
        /// Removes the control that has specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        public void Remove(string id)
        {
            ListviewItem[] listviewItemArray = null;
            listviewItemArray = (id.Length != 0 ? new ListviewItem[] { Context.ClientPage.FindControl(id) as ListviewItem } : this.ItemList.SelectedItems);
            ListviewItem[] listviewItemArray1 = listviewItemArray;
            for (int i = 0; i < (int)listviewItemArray1.Length; i++)
            {
                ListviewItem listviewItem = listviewItemArray1[i];
                if (listviewItem != null)
                {
                    listviewItem.Parent.Controls.Remove(listviewItem);
                    Context.ClientPage.ClientResponse.Remove(listviewItem.ID, true);
                }
            }
        }

        /// <summary>
        /// Shows this dialog.
        /// </summary>
        public static void Show()
        {
            Context.ClientPage.ClientResponse.ShowModalDialog(UIUtil.GetUri("control:Installer.AddStaticItemSource"), true);
        }
    }
}