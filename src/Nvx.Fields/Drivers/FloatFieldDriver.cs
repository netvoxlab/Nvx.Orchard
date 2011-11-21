using System;
using System.Text;
using JetBrains.Annotations;
using Nvx.Fields.Settings;
using Nvx.Fields.ViewModels;
using Orchard;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.Handlers;
using Orchard.Localization;

namespace Nvx.Fields.Drivers
{
    [UsedImplicitly]
    public class FloatFieldDriver : ContentFieldDriver<Fields.FloatField>
    {
        public IOrchardServices Services { get; set; }

        // EditorTemplates/Fields/Custom.Custom.cshtml
        private const string TemplateName = "Fields/Custom.Float";

        public FloatFieldDriver(IOrchardServices services)
        {
            Services = services;
            T = NullLocalizer.Instance;
        }

        public Localizer T { get; set; }

        private static string GetPrefix(ContentField field, ContentPart part)
        {
            // handles spaces in field names
            return (part.PartDefinition.Name + "." + field.Name)
                   .Replace(" ", "_");
        }

        protected override DriverResult Display(
            ContentPart part, Fields.FloatField field,
            string displayType, dynamic shapeHelper)
        {

            return ContentShape("Fields_Custom_Float", // key in Shape Table
                    field.Name, // used to differentiate shapes in placement.info overrides, e.g. Fields_Common_Text-DIFFERENTIATOR
                // this is the actual Shape which will be resolved
                // (Fields/Custom.Float.cshtml)
                    s =>
                    s.Name(field.Name)
                     .Display(FloatFieldSettings.GetFloatDiplay(field,field.FloatValue))
                     .Value(field.FloatValue)
                );
        }

        protected override DriverResult Editor(ContentPart part,
                                               Fields.FloatField field,
                                               dynamic shapeHelper)
        {

            var settings = field.PartFieldDefinition.Settings
                                .GetModel<FloatFieldSettings>();
            var value = field.FloatValue;

            var viewModel = new FloatFieldViewModel {
                Name = field.Name,
                Display = FloatFieldSettings.GetFloatDiplay(field, value),
                Decimals = settings.Decimals,
                Value =value
            };

            return ContentShape("Fields_Custom_Float_Edit",
                () => shapeHelper.EditorTemplate(
                          TemplateName: TemplateName,
                          Model: viewModel,
                          Prefix: GetPrefix(field, part)));
        }

        protected override DriverResult Editor(ContentPart part,
                                               Fields.FloatField field,
                                               IUpdateModel updater,
                                               dynamic shapeHelper)
        {

            var viewModel = new FloatFieldViewModel();

            if (updater.TryUpdateModel(viewModel,
                                       GetPrefix(field, part), null, null)) {
                //if (field.FloatValue.HasValue) {
                /*var value = field.FloatValue;
                viewModel.Value = value;
                
                string v = FloatFieldSettings.GetFloatDiplay(field, value);
                viewModel.Display = v;               */

                field.FloatValue = viewModel.Value;

                /*if (float.TryParse(viewModel.Display, out value)) {
                    field.FloatValue = value;
                }
                else {
                    updater.AddModelError(GetPrefix(field, part),
                                          T("{0} is an invalid float",
                                            field.Name));
                    field.FloatValue = null;
                }*/
                //}
            }

            return Editor(part, field, shapeHelper);
        }

        protected override void Importing(ContentPart part, Fields.FloatField field,
            ImportContentContext context)
        {

            var importedText = context.Attribute(GetPrefix(field, part), "Float");
            if (importedText != null)
            {
                field.Storage.Set(null, importedText);
            }
        }

        protected override void Exporting(ContentPart part, Fields.FloatField field,
            ExportContentContext context)
        {
            context.Element(GetPrefix(field, part))
                .SetAttributeValue("Float", field.Storage.Get<float>(null));
        }
    }
}