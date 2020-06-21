﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc;

namespace WebLabs.TagHelpers
{
    [HtmlTargetElement("img", Attributes = "img-action, img-controller")]

    public class ImageTagHalper:TagHelper
    {
        IUrlHelperFactory urlHelperFactory;
        public string ImgAction { get; set; }
        public string ImgController { get; set; }
        public ImageTagHalper(IUrlHelperFactory factory)
        {
            urlHelperFactory = factory;
        }
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext viewContext { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var urlHelper = urlHelperFactory.GetUrlHelper(viewContext);
            var url = urlHelper.Action(ImgAction, ImgController);
            output.Attributes.Add("src", url);
        }
    }
}
