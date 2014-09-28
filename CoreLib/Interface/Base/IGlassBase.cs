using System;
using System.Collections.Generic;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Globalization;

namespace CoreLib.Interface.Base
{
    [SitecoreType(AutoMap = true)]
    public interface IGlassBase
    {
        [SitecoreId]
        Guid Id { get; }

        [SitecoreInfo(SitecoreInfoType.Url)]
        string Url { get; }

        [SitecoreInfo(SitecoreInfoType.Name)]
        string Name { get; }

        [SitecoreInfo(SitecoreInfoType.DisplayName)]
        string DisplayName { get; }

        [SitecoreInfo(SitecoreInfoType.Path)]
        string Path { get; }

        [SitecoreInfo(SitecoreInfoType.FullPath)]
        string FullPath { get; }

        [SitecoreInfo(SitecoreInfoType.Language)]
        Language Language { get; }

        [SitecoreField(FieldName = "__Created")]
        DateTime Created { get; set; }

        [SitecoreField(FieldName = "__updated")]
        DateTime Updated { get; set; }

        [SitecoreInfo(SitecoreInfoType.TemplateId)]
        Guid TemplateId { get; }

        [SitecoreInfo(SitecoreInfoType.TemplateName)]
        [SitecoreFieldAttribute(FieldName = "Title")]
        string TemplateName { get; }

        [SitecoreInfo(SitecoreInfoType.Key)]
        string TemplateKey { get; }

        [SitecoreChildren(IsLazy = true, InferType = true)]
        IEnumerable<IGlassBase> BaseChildren { get; set; }

        [SitecoreParent(IsLazy = false)]
        IGlassBase Parent { get; set; }
    }
}
