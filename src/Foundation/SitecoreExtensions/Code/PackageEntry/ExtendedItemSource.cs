using Sitecore.Globalization;
using Sitecore.Install.Framework;
using Sitecore.Install.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;
using Sitecore.Configuration;
using System.Collections;

namespace HackstreetBoys.Foundation.SitecoreExtensions.PackageEntries
{
	public class ExtendedItemSource : BaseSource<Item>
    {

        private string database;

        private string root;

        private bool skipVersions;

        public Language Language { get; set; }
        
        public string Database
        {
            get
            {
                return this.database;
            }
            set
            {
                this.database = value;
            }
        }

        
        public string Root
        {
            get
            {
                return this.root;
            }
            set
            {
                this.root = value;
            }
        }

        public bool SkipVersions
        {
            get
            {
                return this.skipVersions;
            }
            set
            {
                this.skipVersions = value;
            }
        }

        
        public ExtendedItemSource()
        {
            base.Converter = new ItemToEntryConverter();
        }

        
        protected override void InternalPopulate(ISink<Item> sink)
        {
            if (Language == null)
            {
                this.RecursivePopulate(Factory.GetDatabase(this.database).GetItem(this.root), Language, sink);
            }
            else
            {
                this.RecursivePopulate(Factory.GetDatabase(this.database).GetItem(this.root, Language), Language, sink);
            }
        }

        /// <summary>
        /// Populates the sink recursively.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="sink">The sink.</param>
        private void RecursivePopulate(Item item, Language lng, ISink<Item> sink)
        {
            if (item == null)
            {
                sink.ProcessingContext.ObjectNotFound(string.Concat(this.database, "/", this.root, ")"), "Source root item");
            }
            else
            {
                if (!this.skipVersions)
                {
                    IList versions = lng == null?  item.Versions.GetVersions(true) : item.Versions.GetVersions();
                    if (versions.Count <= 0)
                    {
                        sink.Put(item);
                    }
                    else
                    {
                        foreach (Item version in versions)
                        {
                            sink.Put(version);
                        }
                    }
                }
                else
                {
                    sink.Put(item);
                }
                foreach (Item child in item.Children)
                {
                    this.RecursivePopulate(child, lng, sink);
                }
            }
        }
    }
}