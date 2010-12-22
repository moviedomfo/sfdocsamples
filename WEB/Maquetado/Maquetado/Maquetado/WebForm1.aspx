﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Maquetado.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div>
<div id="comentarios">
      <h1>&quot;Personal&quot; Template </h1>
      <p>This template is best suited for a personal, or blog-style web site.
        Its layout consist of two columns with the main navigation menu spanning
        the top. The layout has a &quot;fluid&quot; width, which means that it
        adjusts its size to the user's browser window. While this is nothing
        spectacular in itself &#8212; after all, table-based layouts have behaved
        like this for years &#8212; there
        is some added benefit for users with large monitors: the content expands
        only to a certain point after which it doesn't get any wider anymore.
        The result is greatly increased readability of the content because the
        lines of text will never extend beyond a comfortable width. Likewise,
        the content won't ever be squashed to a point beyond legibility when
        the user narrows the browser window.</p>
		<p>Note: general features of this template which are common to all templates 
	are described in the <a href="Default.htm">introduction to the template set</a>. Make sure to read 
	this document first if you haven't done so already.</p>
      <h2>Main features</h2>
      <h3><a name="themes" id="themes"></a>Themes and theme selection </h3>
      <p>The template comes with three different themes called <em>Red</em>, <em>Green</em> and <em>Brown</em>,
        named after &#8212; you guessed it &#8212; their predominant color. While
        the other templates in the template set have to have their theme set
        in the application's configuration file by the site's administrator,
        this one leaves the selection up to the visitor. Once a user has selected
        a theme, the choice is stored in their <a href="http://msdn.microsoft.com/en-us/library/system.web.profile">profile</a> and
        restored upon their next visit. </p>
      <p>Implementing the theme picker functionality required the introduction
        of a common base class for all pages in the application. You can find
        the <em>PageBase</em> class in the <em>App_Code</em> directory of the
        sample application. Rather than having to manually configure every page
        to inherit from this class in the <code>@Page</code> directive, the <code>pageBaseType</code> attribute
        of the <code>pages</code> configuration
        element in <em>web.config</em> is used:</p>
      <p><code>&lt;pages pageBaseType=&quot;PageBase&quot; /&gt;</code></p>
      <p>This way, all pages automatically inherit from <code>PageBase</code> rather
        than from the default <code>System.Web.UI.Page</code>. Take a look at
        the code in <em>PageBase.cs</em> as well as the code-behind file of the
        master page (<em>AppMaster.master.cs</em>) to see how dynamic theme selection
        works.</p>
      <p>While selection of the preferred theme is up to the user, you can influence
        the default theme which will applied when the user first visits your
        site. Simply find the following section in <em>web.config</em> and change the
        value in bold to the name of the desired theme.</p>
      <p><code>&lt;profile enabled=&quot;true&quot;&gt;<br />
&nbsp;&nbsp;&lt;properties&gt;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&lt;add name=&quot;StylesheetTheme&quot; defaultValue=&quot;<strong>Red</strong>&quot; allowAnonymous=&quot;true&quot; /&gt;<br />
&nbsp;&nbsp;&lt;/properties&gt;<br />
&lt;/profile&gt;</code></p>
      <h3><a name="fluid" id="fluid"></a>Fluid, but not really</h3>
      <p>As described in the introduction to this template, the content of a
        page, though essentially fluid, will never extend beyond a comfortable
        reading width &#8212; regardless of the width of the user's browser
        window. This behavior is achieved by taking advantage of a very clever
        CSS layout technique named the <em>Jello
        Mold</em> and invented by <a href="http://uwmike.com/">Mike Purvis</a>.
        Mike has written an <a href="http://www.positioniseverything.net/articles/jello-expo.html">in-depth
        article</a> explaining the inner workings of the technique. This article
        is highly recommended reading if you plan to make major layout changes
        to the template. </p>
      <h3>Menu</h3>
      <p>The main menu is an instance of the ASP.NET <code>Menu</code> control
        which<code></code> derives
        the page information from the <em>web.sitemap</em> file in the site root
        directory. If you add new pages to the site, make sure you also place
        corresponding entries in the sitemap so the pages will be displayed correctly
        in the menu. </p>
      <p>This template doesn't contain any breadcrumbs since personal sites seldom
        reach a page hierarchy deep enough to actually require breadcrumbs. </p>
      <p>Note: dynamic submenu items for the menu are not supported in this
        release of the template.</p>
      <h3>Accessibility</h3>
      <p>The contact form found in <em>Contact.aspx</em> is in compliance with <a href="http://www.w3.org/TR/WAI-WEBCONTENT/checkpoint-list.html">Priority
          1 checkpoints</a> of the <a href="http://www.w3.org/TR/WAI-WEBCONTENT/">W3C
          Web Content Accessibility Guidelines (WCAG 1.0</a>) as well as <a href="http://www.section508.gov/index.cfm?FuseAction=Content&amp;ID=12#Web">&sect; 1194.22
          of Section 508</a>. Use the techniques shown there for your own forms
          as well, so they'll be accessible for site visitors with disabilities.</p>
      <h3>Database</h3>
      <p>The template includes a SQL Server Express version of the <dfn>pubs</dfn> sample
        database for displaying the list of books on the <em>Publications.aspx</em> page.
        You may have to grant read and write permissions on the<em> pubs.mdf</em> file
        located in the application's <em>App_Data</em> directory to the ASP.NET
        process account (ASPNET on IIS 5.x, NETWORK SERVICE on IIS 6) if you
        encounter errors when trying to view the <em>Publications.aspx</em> page.</p>
      <p>If you don't want to use the SQL Express database, simply change the
      connection string in the <em>connectionStrings</em> section of the <em>web.config</em>      file to point to a different destination.</p>
      <h3>Designer support </h3>
      <p>Since the template's current theme is set dynamically as explained <a href="#themes">above</a> ,
        the web form designer in Visual&nbsp;Studio&nbsp;2005 and Visual&nbsp;Web&nbsp;Developer&nbsp;Express&nbsp;2005
        has no way of determining which theme to apply at design time, so there
        is no designer support initially. </p>
      <p>However, it is possible
          to temporarily set a theme while you work in the designer and then
        remove the instruction before deploying the finished application. Simply
        add the following code to the <em>web.config</em> file below the <code>system.web</code> node:</p>
      <p><code>&lt;pages styleSheetTheme=&quot;Brown&quot; /&gt;</code> </p>
      <p>This will set the default theme for use during design time. Please note
        that dynamic theme selection will not work if you preview the pages in
        the browser while the above instruction is contained in <em>web.config</em>.
        Remove the code when you're ready to deploy and theme selection will
        work as expected again.</p>
      <h2>Template structure</h2>
      <p>The first thing you'll probably notice when inspecting the master page
        of this template is a set of nested <code>div</code>s below the <code>body</code> tag
        called <em>sizer</em>,
        <em>expander</em> and <em>wrapper</em>. These are necessary to make the
        semi-fuid layout (the <em>Jello Mold</em>, see <a href="#fluid">above</a>)
        work. The remaining
        <code>div</code> elements structure the actual page content. Their names
        indicate their purpose so you should be able to find your way around
        the element hierarchy pretty quickly. </p>
      <p>The <em>sidebar</em> is floated to the right and  neatly fits in the
        243px right margin  of the <em>content</em> div. </p>
      <p>The look of each theme is achieved by a combination of background colors
        and background images that are assigned to specific <code>div</code> elements
      of the master page. See the style sheet for further details. </p>
      <h2>Customizing the template </h2>
      <p>Modifying a template's design to suit your needs is done almost exclusively
        in the CSS and .skin files of a theme. The recommended approach to customizing
        a theme is to make a copy of the one that most closely resembles the
        look you're going for in the <em>App_Themes</em> directory and give it
        a new name. The main areas of customization of this template are: personal
        information, colors, background images and, of course, the page content.</p>
      <h3>Personal information </h3>
      <p>The name of the site owner as well as the (optional) slogan is set in
        <em>ownername</em> div of the master page, additional information can
        be provided in the <em>ownerinfo</em> <code>div</code>. Don't forget
        to put an appropriate copyright notice in the <em>footer</em> div.</p>
      <h3>Images</h3>
      <p>The images used to create the design of each theme are stored in the <em>Images</em> subfolder
        of the theme. Some images have very specific widths or heights to make
        them fit into the layout. If you want to stay on the safe side when editing
        the supplied images in a graphics program, try not to change any image
        dimensions. Note that this warning only applies to images used for layout
        purposes, such as background-tiles. There is no restriction on modifying
        pictures used in the page contents, of course.</p>
      <h4>Page content </h4>
      <p>Before you start to add content to the pages of your themed application
        it is a good idea to study the sample pages provided with each template
        as well as the master page. Sections that require specific markup are
        commented and contain instructions on what the markup should look like
        so it will actually pick up the styles set in the style sheet and the
        skin file. </p>
</div>

</div>
</asp:Content>
