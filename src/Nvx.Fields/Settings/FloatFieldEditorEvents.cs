using System.Collections.Generic;
using Orchard.ContentManagement;
using Orchard.ContentManagement.MetaData;
using Orchard.ContentManagement.MetaData.Builders;
using Orchard.ContentManagement.MetaData.Models;
using Orchard.ContentManagement.ViewModels;

namespace Nvx.Fields.Settings
{
    public class FloatFieldEditorEvents : ContentDefinitionEditorEventsBase
    {

        public override IEnumerable<TemplateViewModel>
          PartFieldEditor(ContentPartFieldDefinition definition)
        {
            if (definition.FieldDefinition.Name == "FloatField")
            {
                var model = definition.Settings.GetModel<FloatFieldSettings>();
                yield return DefinitionTemplate(model);
            }
        }

        public override IEnumerable<TemplateViewModel> PartFieldEditorUpdate(
          ContentPartFieldDefinitionBuilder builder, IUpdateModel updateModel)
        {
            var model = new FloatFieldSettings();
            if (updateModel.TryUpdateModel(
              model, "FloatFieldSettings", null, null))
            {
                builder.WithSetting("FloatFieldSettings.Decimals",
                                    model.Decimals.ToString());
            }

            yield return DefinitionTemplate(model);
        }
    }
}