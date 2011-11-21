using System;
using System.Collections.Generic;
using System.Linq;
using Orchard.ContentManagement;
using Orchard.ContentManagement.MetaData;
using Orchard.ContentManagement.MetaData.Builders;
using Orchard.ContentManagement.MetaData.Models;
using Orchard.ContentManagement.ViewModels;

namespace Nvx.Fields.Settings
{
    public class MapPartEditorEvents : ContentDefinitionEditorEventsBase
    {
        public override IEnumerable<TemplateViewModel> TypePartEditor(
            ContentTypePartDefinition definition)
        {
            if (definition.PartDefinition.Name != "MapPart")
                yield break;
            var model = definition.Settings.GetModel<MapPartSettings>();

            model.EngineTypes = Enum.GetValues(typeof(MapEngineType))
                .Cast<int>()
                .Select(i =>
                    new
                    {
                        Text = Enum.GetName(typeof(MapEngineType), i),
                        Value = i
                    });

            yield return DefinitionTemplate(model);
        }

        public override IEnumerable<TemplateViewModel> TypePartEditorUpdate(
            ContentTypePartDefinitionBuilder builder,
            IUpdateModel updateModel)
        {
            if (builder.Name != "MapPart")
                yield break;

            var model = new MapPartSettings();
            updateModel.TryUpdateModel(model, "ShareBarTypePartSettings", null, null);
            builder.WithSetting("ShareBarTypePartSettings.Mode",
                ((int)model.Engine).ToString());
            yield return DefinitionTemplate(model);
        }
    }
}