using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;

namespace System.Web.Mvc.Html
{
    public static class BootstrapHelper
    {


        const string CLASS = "class";

        //class values
        const string FORM_CONTROL = "form-control";
        const string TEXT_BOX = "text-box";
        const string SINGLE_LINE = "single-line";
        const string CONTROL_LABEL = "control-label";
        const string COL_MD_2 = "col-md-2";
        const string COL_MD_10 = "col-md-10";
        const string TEXT_DANGER = "text-danger";
        const string FORM_GROUP = "form-group ";

        //TAG'S
        const string DIV = "div";

        //attributes
        const string FILE = "file";
        const string TYPE = "type";
        public const string FILE_SUFIX = "FileUploader";


        private static MvcHtmlString putInFormGroup<TModel, TProperty>(
           this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> property, HtmlString componente)
        {
            var formGroup = new TagBuilder(DIV);
            formGroup.AddCssClass(FORM_GROUP);

            var attLabel = new RouteValueDictionary();
            attLabel.Add(CLASS, CONTROL_LABEL + " " + COL_MD_2);
            HtmlString label = htmlHelper.LabelFor(property, attLabel);

            var divRight = new TagBuilder(DIV);
            divRight.AddCssClass(COL_MD_10);

            var attValidation = new RouteValueDictionary();
            attValidation.Add(CLASS, TEXT_DANGER);
            HtmlString validation = htmlHelper.ValidationMessageFor(property, "", attValidation);

            divRight.InnerHtml = componente.ToString() + validation.ToString();

            formGroup.InnerHtml = label.ToString() + divRight.ToString();

            return new MvcHtmlString(formGroup.ToString());
        }

        public static MvcHtmlString BootstrapTextBoxFor<TModel, TProperty>(
                   this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> property)
        {

            var attTexBox = new RouteValueDictionary();
            attTexBox.Add(CLASS, FORM_CONTROL + " " + TEXT_BOX + " " + SINGLE_LINE);
            HtmlString textbox = htmlHelper.TextBoxFor(property, attTexBox);

            return putInFormGroup(htmlHelper,property,textbox);
        }

        public static MvcHtmlString BootstrapFileFor<TModel, TPorperty>(
           this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TPorperty>> property)
        {
            var att = new RouteValueDictionary();
            att.Add(CLASS, FORM_CONTROL);
            att.Add(TYPE, FILE);

            var data = ModelMetadata.FromLambdaExpression(property, htmlHelper.ViewData);
            HtmlString file = htmlHelper.Editor(data.PropertyName + FILE_SUFIX, new { htmlAttributes = att });
            HtmlString hidden = htmlHelper.HiddenFor(property);

            var componente = new HtmlString(file.ToString() + hidden.ToString());

            return putInFormGroup(htmlHelper, property, componente);
        }


    }
}
