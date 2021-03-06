﻿using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace ActionMailerNext.Mvc5_3
{
    /// <summary>
    ///     This class contains some handy extension methods that make it easier
    ///     to consume inline attachments in your messageBase body.
    /// </summary>
    public static class HtmlHelperExtensions
    {
        /// <summary>
        ///     Creates an image tag linked against the specified inline image attachment.
        /// </summary>
        /// <param name="helper">Your html helper instance.</param>
        /// <param name="contentId">The content id (in ActionMailer this is the attachment name).</param>
        /// <returns>An HTML image tag linked against the specified inline image attachment.</returns>
        public static MvcHtmlString InlineImage(this HtmlHelper helper, string contentId)
        {
            return helper.InlineImage(contentId, null, null, null);
        }

        /// <summary>
        ///     Creates an image tag linked against the specified inline image attachment.
        /// </summary>
        /// <param name="helper">Your html helper instance.</param>
        /// <param name="contentId">The content id (in ActionMailer this is the attachment name).</param>
        /// <param name="htmlAttributes">An anonymous object with extra html attributes you wish to add to this tag.</param>
        /// <returns>An HTML image tag linked against the specified inline image attachment.</returns>
        public static MvcHtmlString InlineImage(this HtmlHelper helper, string contentId, object htmlAttributes)
        {
            return helper.InlineImage(contentId, null, null, htmlAttributes);
        }

        /// <summary>
        ///     Creates an image tag linked against the specified inline image attachment.
        /// </summary>
        /// <param name="helper">Your html helper instance.</param>
        /// <param name="contentId">The content id (in ActionMailer this is the attachment name).</param>
        /// <param name="alt">The tooltip text to display when hovering over the image</param>
        /// <returns>An HTML image tag linked against the specified inline image attachment.</returns>
        public static MvcHtmlString InlineImage(this HtmlHelper helper, string contentId, string alt)
        {
            return helper.InlineImage(contentId, alt, null, null);
        }

        /// <summary>
        ///     Creates an image tag linked against the specified inline image attachment.
        /// </summary>
        /// <param name="helper">Your html helper instance.</param>
        /// <param name="contentId">The content id (in ActionMailer this is the attachment name).</param>
        /// <param name="alt">The tooltip text to display when hovering over the image</param>
        /// <param name="htmlAttributes">An anonymous object with extra html attributes you wish to add to this tag.</param>
        /// <returns>An HTML image tag linked against the specified inline image attachment.</returns>
        public static MvcHtmlString InlineImage(this HtmlHelper helper, string contentId, string alt,
            object htmlAttributes)
        {
            return helper.InlineImage(contentId, alt, null, htmlAttributes);
        }

        /// <summary>
        ///     Creates an image tag linked against the specified inline image attachment.
        /// </summary>
        /// <param name="helper">Your html helper instance.</param>
        /// <param name="contentId">The content id (in ActionMailer this is the attachment name).</param>
        /// <param name="alt">The tooltip text to display when hovering over the image</param>
        /// <param name="id">Any HTML ID that you want the image tag to have.</param>
        /// <returns>An HTML image tag linked against the specified inline image attachment.</returns>
        public static MvcHtmlString InlineImage(this HtmlHelper helper, string contentId, string alt, string id)
        {
            return helper.InlineImage(contentId, alt, id, null);
        }

        /// <summary>
        ///     Creates an image tag linked against the specified inline image attachment.
        /// </summary>
        /// <param name="helper">Your html helper instance.</param>
        /// <param name="contentId">The content id (in ActionMailer this is the attachment name).</param>
        /// <param name="alt">The tooltip text to display when hovering over the image</param>
        /// <param name="id">Any HTML ID that you want the image tag to have.</param>
        /// <param name="htmlAttributes">An anonymous object with extra html attributes you wish to add to this tag.</param>
        /// <returns>An HTML image tag linked against the specified inline image attachment.</returns>
        public static MvcHtmlString InlineImage(this HtmlHelper helper, string contentId, string alt, string id,
            object htmlAttributes)
        {
            if (contentId == null)
                throw new ArgumentNullException(nameof(contentId));

            var builder = new TagBuilder("img");
            string fileUrl = $"cid:{contentId}";

            builder.MergeAttribute("src", fileUrl);

            if (!string.IsNullOrWhiteSpace(alt))
                builder.MergeAttribute("alt", alt);

            if (!string.IsNullOrWhiteSpace(id))
                builder.GenerateId(id);

            if (htmlAttributes != null)
                builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));

            return new MvcHtmlString(builder.ToString(TagRenderMode.SelfClosing));
        }

        /// <summary>
        ///     Creates a link tag for an inline CSS attachment.
        /// </summary>
        /// <param name="helper">Your html helper instance.</param>
        /// <param name="contentId">The content id (in ActionMailer this is the attachment name).</param>
        /// <returns>An HTML link tag that represents the inline CSS attachment specified.</returns>
        public static MvcHtmlString InlineCSS(this HtmlHelper helper, string contentId)
        {
            return helper.InlineCSS(contentId, null, null);
        }

        /// <summary>
        ///     Creates a link tag for an inline CSS attachment.
        /// </summary>
        /// <param name="helper">Your html helper instance.</param>
        /// <param name="contentId">The content id (in ActionMailer this is the attachment name).</param>
        /// <param name="htmlAttributes">An anonymous object with extra html attributes you wish to add to this tag.</param>
        /// <returns>An HTML link tag that represents the inline CSS attachment specified.</returns>
        public static MvcHtmlString InlineCSS(this HtmlHelper helper, string contentId, object htmlAttributes)
        {
            return helper.InlineCSS(contentId, null, htmlAttributes);
        }

        /// <summary>
        ///     Creates a link tag for an inline CSS attachment.
        /// </summary>
        /// <param name="helper">Your html helper instance.</param>
        /// <param name="contentId">The content id (in ActionMailer this is the attachment name).</param>
        /// <param name="media">The media type for the link tag.</param>
        /// <returns>An HTML link tag that represents the inline CSS attachment specified.</returns>
        public static MvcHtmlString InlineCSS(this HtmlHelper helper, string contentId, string media)
        {
            return helper.InlineCSS(contentId, media, null);
        }

        /// <summary>
        ///     Creates a link tag for an inline CSS attachment.
        /// </summary>
        /// <param name="helper">Your html helper instance.</param>
        /// <param name="contentId">The content id (in ActionMailer this is the attachment name).</param>
        /// <param name="media">The media type for the link tag.</param>
        /// <param name="htmlAttributes">An anonymous object with extra html attributes you wish to add to this tag.</param>
        /// <returns>An HTML link tag that represents the inline CSS attachment specified.</returns>
        public static MvcHtmlString InlineCSS(this HtmlHelper helper, string contentId, string media,
            object htmlAttributes)
        {
            if (contentId == null)
                throw new ArgumentNullException(nameof(contentId));

            var builder = new TagBuilder("link");
            string fileUrl = $"cid:{contentId}";

            builder.MergeAttribute("href", fileUrl);
            builder.MergeAttribute("rel", "stylesheet");
            builder.MergeAttribute("type", "text/css");

            if (!string.IsNullOrWhiteSpace(media))
                builder.MergeAttribute("media", media);

            if (htmlAttributes != null)
                builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));

            return new MvcHtmlString(builder.ToString(TagRenderMode.SelfClosing));
        }
    }
}