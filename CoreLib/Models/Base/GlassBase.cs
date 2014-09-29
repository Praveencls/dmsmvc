using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLib.Interface.Base;
using Glass.Mapper.Sc;
using Sitecore.Data.Items;
using Sitecore.Globalization;

namespace CoreLib.Models.Base
{
    public class GlassBase : IGlassBase
    {
        #region IGlassBase Members
        public virtual Guid Id
        {
            get;
            private set;
        }

        public virtual string Url
        {
            get;
            private set;
        }

        public virtual string Name
        {
            get;
            private set;
        }

        public virtual string DisplayName
        {
            get;
            private set;
        }

        public virtual string Path
        {
            get;
            private set;
        }

        public virtual string FullPath
        {
            get;
            private set;
        }

        public virtual Language Language
        {
            get;
            private set;
        }

        public virtual DateTime Created
        {
            get;
            set;
        }

        public virtual DateTime Updated
        {
            get;
            set;
        }

        public virtual Guid TemplateId
        {
            get;
            private set;
        }

        public virtual string TemplateName
        {
            get;
            private set;
        }

        public virtual string Key
        {
            get;
            private set;
        }

        public virtual Item InnerItem
        {
            get
            {
                return Sitecore.Context.Database.GetItem(this.Id.ToString());
            }
        }

        public virtual IEnumerable<IGlassBase> BaseChildren { get; set; }

        public virtual IGlassBase Parent { get; set; }

        public IEnumerable<T> GetChildren<T>(string templateName) where T : GlassBase
        {
            var items = new List<T>();
            ISitecoreContext context = new SitecoreContext();
            if (BaseChildren != null)
                items.AddRange(
                 from item in BaseChildren
                 where item.TemplateName.ToLower() == templateName.ToLower()
                 select context.GetItem<T>(item.Id));
            return items;
        }

        /*
          [SitecoreQuery("/sitecore/content/home/*[@AppearInNavigation='1']")]
        public virtual IEnumerable<ContentBase> Links { get; set; }

         * [SitecoreQuery("./*")]
public virtual IEnumerable<AbstractModel> Children { get; set; }
         * 
         * [SitecoreQuery("//*")]
public virtual IEnumerable<AbstractModel> Children { get; set; }
         * 
         * [SitecoreQuery("./*[@@templatename='Testimonial']", IsRelative = true)]        
public virtual IEnumerable<Testimonial> Children { get; set; }  
         * 
         * [SitecoreQuery("/sitecore/content//*[@@templatename='Testimonial']")]
public virtual IEnumerable<Testimonial> TestimonialList { get; set; }
         * 
         * [SitecoreQuery("./*[@featured='1']", IsRelative=true)]
public virtual IEnumerable<News> FeaturedNews { get; set; }
         * 
         * public virtual IEnumerable<Testimonial> Children { get; set; }
         * 
         *  [SitecoreQuery("./*[@AppearInLeftMenu='1']", IsRelative = true)]
            public virtual IEnumerable<LeftMenuItem> Children { get; set; }

            [SitecoreQuery("ancestor::*[@AppearInLeftMenu='1']", IsRelative = true)]
            public virtual IEnumerable<LeftMenuItem> Ancestors { get; set; }
         * 
         *  [SitecoreQuery("ancestor-or-self::*[@AppearInMenu='1']", IsRelative = true)]
        public virtual IEnumerable<LeftMenuItem> Ancestors { get; set; }
         * 
         * [SitecoreLinked(Option = SitecoreLinkedOptions.Referrers, InferType = true)]
        //[SitecoreQuery("/sitecore/content/home//*[contains(@tags,'{id}')]", InferType= true)]
        public virtual IEnumerable<Base> TaggedItems { get; set; }  
         * 
         * [SitecoreQuery("./*[@@templateid='{7BCF9DFE-B041-4205-8DEA-04CD8503500D}']", IsRelative=true)]
        public virtual IEnumerable<Comment> Comments { get; set; }
         * 
         *  [SitecoreQuery("./*[@@templatename='NewsArticle']", IsRelative = true)]
        public virtual IEnumerable<NewsArticle> Articles { get; set; }
                                  * 
                                  * 
                                  *   public virtual IEnumerable<BasePage> Ancestors() {
            if(Link.Type != LinkType.Internal)
                return Enumerable.Empty<BasePage>();
 
            var item = Sitecore.Context.Database.GetItem(new ID(Link.TargetId));
 
            return (from ancestor in item.Axes.GetAncestors()
                    let basePage = ancestor.GlassCast<BasePage>()
                    where ancestor.Axes.Level > 2
                    select basePage);
        }       
         */
        #endregion

        #region IGlassBase Members


        public virtual string TemplateKey
        {
            get;
            private set;
        }

        #endregion
    }
}
