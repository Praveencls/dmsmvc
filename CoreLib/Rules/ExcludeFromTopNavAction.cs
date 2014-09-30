
namespace CoreLib.Rules
{
    using Sitecore.Data.Fields;
    using Sitecore.Diagnostics;
    using Sitecore.Rules;
    using Sitecore.Rules.Actions;

    public class ExcludeFromTopNavAction<T> : RuleAction<T> where T : RuleContext
    {
        private const string IncludeInNavigationFieldName = "Include In Navigation";
        public override void Apply(T ruleContext)
        {
            Assert.ArgumentNotNull(ruleContext, "RuleContext");
            var item = ruleContext.Item;
             if (item != null)   
 	            {
                    var includeInTopNavigationField = (CheckboxField)item.Fields[IncludeInNavigationFieldName];   
 	                if (includeInTopNavigationField == null)   
 	                    return;   
 	    
 	                item.Editing.BeginEdit();   
 	                includeInTopNavigationField.Checked = false;   
 	                item.Editing.EndEdit();   
 	            }    
        }
    }
}
